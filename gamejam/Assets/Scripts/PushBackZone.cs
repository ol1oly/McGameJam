using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PushBackZone : MonoBehaviour
{
    public float strength = 1f;             // own force multiplier
    public float upwardComponent = 0.2f;    // fraction of upward push
    public float velocityMultiplier = 1f;
    public float maxForce = 20f;

    public float slowDownScale = 0.8f;         // force applied to other rigidbody

    public Rigidbody2D own;                 // your own Rigidbody2D

    public ForceMode2D modePlayer = ForceMode2D.Force;
    public ForceMode2D modeBox = ForceMode2D.Force;

    void OnTriggerStay2D(Collider2D other)
    {
        if (!(other.CompareTag("Player") || other.CompareTag("ennemy"))) return;
        Rigidbody2D rb = other.attachedRigidbody;
        if (rb == null) return;

        // Own push: mostly right, with small upward component
        Vector2 pushDirection = (own.gameObject.transform.position - rb.gameObject.transform.position).normalized;

        float forceAmount = strength;
        forceAmount = Mathf.Min(forceAmount, maxForce);
        own.AddForce(pushDirection * forceAmount, modeBox);


        rb.AddForce(Vector2.left * slowDownScale, modePlayer);
    }

}
