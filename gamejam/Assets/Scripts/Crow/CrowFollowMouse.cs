using UnityEngine;

public class CrowFollowMouse : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    [SerializeField] private Transform offset;
    private MouseInputProvider mouse;
    private Rigidbody2D rb;
    private Collider2D col;




    void Awake()
    {
        mouse = FindObjectOfType<MouseInputProvider>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    void FixedUpdate()
    {
        Vector2 toMouse = mouse.WorldPosition - (Vector2)offset.position;

        // Flip based on horizontal direction
        if (toMouse.x != 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Sign(toMouse.x); // -1 or 1
            transform.localScale = scale;
        }

        // Approximate collider "radius"
        float stopDistance = col.bounds.extents.magnitude / 2;

        if (toMouse.magnitude <= stopDistance)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        rb.linearVelocity = toMouse.normalized * speed;
    }
}