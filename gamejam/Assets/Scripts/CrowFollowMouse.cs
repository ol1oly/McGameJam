using UnityEngine;

// public class CrowFollowMouse : MonoBehaviour
// {
//     [SerializeField] private float speed = 4f;

//     private MouseInputProvider mouse;
//     private Rigidbody2D rb;

//     void Awake()
//     {
//         mouse = FindObjectOfType<MouseInputProvider>();
//         rb = GetComponent<Rigidbody2D>();
//     }

//     void FixedUpdate()
//     {
//         Vector2 toMouse = mouse.WorldPosition - rb.position;

//         if (toMouse.sqrMagnitude < 0.01f)
//         {
//             rb.linearVelocity = Vector2.zero;
//             return;
//         }

//         Vector2 dir = toMouse.normalized;
//         rb.linearVelocity = dir * speed;
//     }
// }

public class CrowFollowMouse : MonoBehaviour
{
    [SerializeField] private float speed = 4f;

    private MouseInputProvider mouse;
    private Rigidbody2D rb;

    void Awake()
    {
        mouse = FindObjectOfType<MouseInputProvider>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 toMouse = mouse.WorldPosition - rb.position;

        if (toMouse.sqrMagnitude < 0.01f)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        Vector2 dir = toMouse.normalized;
        rb.linearVelocity = dir * speed;
    }
}