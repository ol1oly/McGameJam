using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PushBackZone : MonoBehaviour
{
    public PushBackZoneData data;




    public Rigidbody2D own;                 // your own Rigidbody2D



    private Dictionary<Collider2D, int> entryCounts = new();

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!(other.CompareTag("Player") || other.CompareTag("ennemy"))) return;
        Rigidbody2D rb = other.attachedRigidbody;
        if (rb == null) return;

        // Own push: mostly right, with small upward component
        Vector2 pushDirection = (own.gameObject.transform.position - rb.gameObject.transform.position).normalized;
        /*pushDirection.y += data.upwardComponent;
        pushDirection = pushDirection.normalized;*/
        pushDirection = new Vector2(pushDirection.x, data.upwardComponent).normalized;

        float forceAmount = Mathf.Min(data.strength, data.maxForce);

        if (!CanApplyToCollider(other))
            return;
        own.linearVelocity = pushDirection * forceAmount;
    }

    bool CanApplyToCollider(Collider2D col)
    {
        if (!entryCounts.TryGetValue(col, out int count))
            count = 0;

        count++;
        entryCounts[col] = count;

        return count <= data.maxEntriesPerCollider;
    }



}
