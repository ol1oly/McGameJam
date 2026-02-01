using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ForceBasedMovement : MonoBehaviour
{
    private Rigidbody2D body;

    [Header("Movement")]
    public float maxSpeed = 8f;
    public float minimumSpeed = 1f;
    public Vector2 movementDirection = Vector2.right;

    [Header("Slowdown")]
    public float slowdownMultiplier = 0.8f;
    public int maxSlowdownStacks = 3;

    private int slowdownZonesInside;
    private float currentSpeed;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        currentSpeed = maxSpeed;
        slowdownZonesInside = 0;
    }

    void FixedUpdate()
    {
        body.linearVelocity = movementDirection * currentSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PushBackZone>(out _))
        {
            slowdownZonesInside++;
            RecalculateSpeed();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<PushBackZone>(out _))
        {
            slowdownZonesInside = Mathf.Max(0, slowdownZonesInside - 1);
            RecalculateSpeed();
        }
    }

    private void RecalculateSpeed()
    {
        int appliedStacks = Mathf.Min(slowdownZonesInside, maxSlowdownStacks);
        currentSpeed = maxSpeed * Mathf.Pow(slowdownMultiplier, appliedStacks);
        currentSpeed = Mathf.Max(currentSpeed, minimumSpeed);
    }
}
