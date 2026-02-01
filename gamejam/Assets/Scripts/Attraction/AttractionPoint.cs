using UnityEngine;

public class AttractionPoint : MonoBehaviour
{
    public string attractableTag = "Guard"; //object type this attracts
    public float attractionRadius = 5f;
    
    public bool attractOnlyOne = true; //probably useless but is straightforward
    public bool debugDrawRadius = true;

    public bool hasActivated = false;

    //can always change to be more of a "water got dropped near means attraction because its near" and nothing else

    public void Activate()//gets called when obj is dropped or wtv
    {
        if(hasActivated) return;

        // hasActivated= true;
        
        Debug.Log("Attraction activated at"+ gameObject.name);

        GameObject[] attractables = GameObject.FindGameObjectsWithTag(attractableTag);
        //keeping the list cuz might make first level easier to script / lighter

        if(attractOnlyOne){
            GameObject closest = FindClosestInRadius(attractables);
            if (closest != null)
            {
                AttractableObject attractor = closest.GetComponent<AttractableObject>();
                if (attractor != null)
                {
                    attractor.AttractTo(transform);
                    attractor.SetChecking();
                }
            }
        }
        else //aka everything (in radius) comes
        {
            foreach(GameObject obj in attractables)
            {
                if(Vector2.Distance(transform.position, obj.transform.position) <= attractionRadius)
                {
                    AttractableObject attractor = obj.GetComponent<AttractableObject>();
                    if(attractor != null)
                    {
                        attractor.AttractTo(transform); //since stuff is not longer null over there and update runs every frame attraction happens
                        attractor.SetChecking();
                    }

                }
            }
        }
    }

    private GameObject FindClosestInRadius(GameObject[] objects)
    {
        GameObject closest = null;
        float minDistance = attractionRadius;

        foreach(GameObject obj in objects)
        {
            float distance = Vector2.Distance(transform.position, obj.transform.position);

            if(distance < minDistance)
            {
                minDistance = distance;
                closest = obj;
            }
        }

        return closest;
    }


    void OnDrawGizmosSelected() //no clue what this is sounds liek visual debugging
    {
        if (debugDrawRadius)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, attractionRadius);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
