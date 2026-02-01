using UnityEngine;

public class MoneyBag : MonoBehaviour
{
    public string guardTag = "TorchGuard";
    public float attractionRadius = 15f;
    private bool hasBeenActivated = false;

    private bool isBeingHeld = false;
    public UnityEngine.Vector2 holdOffset = new UnityEngine.Vector2(0.5f, 0.3f);

    public void OnDropped()
    {
        if(hasBeenActivated && !isBeingHeld) return;

        hasBeenActivated = true;
        isBeingHeld = false;

        Debug.Log("💰 Money bag dropped! Attracting greedy guard🤑🤑🤑...");//type shit

        GameObject[] guards = GameObject.FindGameObjectsWithTag(guardTag);
        GameObject closest = FindClosestInRadius(guards);

        if(closest != null)
        {
            AttractableObject attractor=closest.GetComponent<AttractableObject>();
            if(attractor != null)
            {
                attractor.AttractTo(transform);
                Debug.Log("Guard attracted to money");
            }
        }
    }


    public void GetPickedUpByGuard(Transform guard)
    {
        isBeingHeld = true;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if(rb != null)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.linearVelocity = UnityEngine.Vector2.zero; //was og velocity but obsolete wada wada wada
        }


        Collider2D[] colliders = GetComponents<Collider2D>();
        foreach (var col in colliders)
        {
            col.enabled = false;
        }

        transform.SetParent(guard);
        transform.localPosition = holdOffset;

        Debug.Log("Money picked up by guard!🤑🤑🤑🤑🤑🤑🤑🤑🤑🤑🤑🤑🤑🤑🤑");

    }

    public void GetPlacedByGuard(UnityEngine.Vector2 position)
    {
        isBeingHeld = false;
        hasBeenActivated = false; //reset so attraction can be on again 

        transform.SetParent(null);
        transform.position = position;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if(rb != null)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

        Collider2D[] colliders = GetComponents<Collider2D>();
        foreach(var col in colliders)
        {
            col.enabled = true;
        }

        Debug.Log("Money placed down by guard - can be picked up again!");
    }

    private GameObject FindClosestInRadius(GameObject[] objects)
    {
        GameObject closest = null;
        float minDistance = attractionRadius;

        foreach(GameObject obj in objects)
        {
            float distance = UnityEngine.Vector2.Distance(transform.position, obj.transform.position);
            if(distance < minDistance)
            {
                minDistance = distance;
                closest = obj;
            }
        }
        return closest;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attractionRadius);     
    }

}
