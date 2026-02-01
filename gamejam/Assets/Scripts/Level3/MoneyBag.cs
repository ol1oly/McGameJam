using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class MoneyBag : MonoBehaviour
{
    public string guardTag = "TorchGuard";
    public float attractionRadius = 15f;
    private bool hasBeenActivated = false;

    public void OnDropped()
    {
        if(hasBeenActivated) return;

        hasBeenActivated = true;

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
