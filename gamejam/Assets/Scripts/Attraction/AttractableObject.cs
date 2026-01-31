using JetBrains.Annotations;
using NUnit.Framework;
using UnityEngine;

public class AttractableObject : MonoBehaviour
{

    public float moveSpeed = 2f;
    public string attractionTag = "Attraction"; //what can attract the obj

     private Transform attractionTarget;
    private bool isAttracted = false;
    private Vector2 originalPosition; //vecteur (i,j) par rapport a og pos?
    private bool shouldReturnToOriginal = false;


    
    void Start()
    {
        originalPosition = transform.position; //huh
    }


    void Update()
    {
        if(isAttracted && attractionTarget != null)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                attractionTarget.position,
                moveSpeed * Time.deltaTime
            );

            if(Vector2.Distance(transform.position, attractionTarget.position) < 0.1f)
            {
                OnReachedAttraction();
            }else if (shouldReturnToOriginal)
            {
                transform.position = Vector2.MoveTowards(
                    transform.position, 
                    originalPosition, 
                    moveSpeed * Time.deltaTime
                );//aka moves back
            }
        }
    }



     public void AttractTo(Transform target)
    {
        attractionTarget = target;
        isAttracted = true;
        shouldReturnToOriginal = false;
        Debug.Log(gameObject.name + "is now attracted to"+target.name);
        
    }

    public void StopAttraction(bool returnToStart = false)
    {
        isAttracted = false;
        attractionTarget = null;
        shouldReturnToOriginal = returnToStart;
    }

    private void OnReachedAttraction()
    {
        Debug.Log(gameObject.name + "reached the attraction point!");
        //custom stuff can be added here lad
        StopAttraction();
    }

    //aka we make something attracted to something and potentially call funcs inbetween
}
