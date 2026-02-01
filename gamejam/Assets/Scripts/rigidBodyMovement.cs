using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ForceBasedMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public float moveSpeed = 5f;         // force multiplier
    public float maxVelocity = 8f;       // cap velocity

    Vector2 moveDirection;

    void Update()
    {
        // Example: automatic movement to the right
        moveDirection = Vector2.right; // can replace with AI/pathfinding or player input
    }

    void FixedUpdate()
    {
        // Apply movement force
        rb.AddForce(moveDirection * moveSpeed, ForceMode2D.Force);

        // Limit velocity without cancelling other forces
        if (rb.linearVelocity.magnitude > maxVelocity)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxVelocity;
        }
    }
}
