using UnityEngine;

public class HorseBehavior : MonoBehaviour
{
    // States the horse can be in
    private enum HorseState
    {
        Idle,
        MovingToArea,   //going to the area after being disturbed
        Eating,         //found apple, wait time set to eating
        Waiting,        //no apple, waiting a bit with reg time
        ReturningHome   //going back to original pos
    }

    private HorseState currentState = HorseState.Idle;
    
    [Header("Movement")]
    public float moveSpeed = 3f;
    public Transform targetArea; //where the horse goes when disturbed
    private Vector2 originalPosition;
    
    [Header("Apple Detection")]
    public float appleDetectionRadius = 1f;
    public string appleTag = "Apple";
    public Apple apple;
    
    [Header("Timing")]
    public float eatingDuration = 3f;   //aplpe eating time
    public float waitDuration = 1.5f;   //reg wait time
    
    private float stateTimer = 0f;
    private GameObject foundApple = null;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        switch (currentState)
        {
            case HorseState.Idle:
                //no disturbtion yet
                break;

            case HorseState.MovingToArea:
                transform.position = Vector2.MoveTowards(
                    transform.position, 
                    targetArea.position, 
                    moveSpeed * Time.deltaTime
                );
                
                if (Vector2.Distance(transform.position, targetArea.position) < 0.2f)
                {
                    OnReachedArea();
                }
                break;


            case HorseState.Eating: //confusing but nothing needs to be done as onreachedarea already changes times
            case HorseState.Waiting:
                // Count down timer
                stateTimer -= Time.deltaTime;

                if (apple.IsFallen)
                {
                    ChangeState(HorseState.Eating);
                    return;
                }
                if (stateTimer <= 0f)
                {
                    //done eating/waiting, go home
                    ChangeState(HorseState.ReturningHome);
                }
                break;

            case HorseState.ReturningHome:
                transform.position = Vector2.MoveTowards(
                    transform.position, 
                    originalPosition, 
                    moveSpeed * Time.deltaTime
                );
                
                if (Vector2.Distance(transform.position, originalPosition) < 0.2f)
                {
                    ChangeState(HorseState.Idle);
                }
                
                break;
        }
    }

    //called when crow clicks on the horse
    public void OnDisturbed()
    {
        if (currentState == HorseState.Idle)
        {
            Debug.Log("Horse disturbed! Moving to area.");
            ChangeState(HorseState.MovingToArea);
        }
    }

    private void OnReachedArea()
    {
        Debug.Log("Horse reached the area!");
        
        //look for apple nearby
        foundApple = FindAppleNearby();
        
        if (foundApple != null)
        {
            Debug.Log("Horse found apple! Eating...");
            Destroy(foundApple); //apple gets "eaten"
            stateTimer = eatingDuration;
            ChangeState(HorseState.Eating);
        }
        else
        {
            Debug.Log("No apple found. Waiting a bit...");
            stateTimer = waitDuration;
            ChangeState(HorseState.Waiting);
        }
    }

    private GameObject FindAppleNearby()
    {
        GameObject[] apples = GameObject.FindGameObjectsWithTag(appleTag);
        
        foreach (GameObject apple in apples)
        {
            if (Vector2.Distance(transform.position, apple.transform.position) <= appleDetectionRadius)
            {
                return apple;
            }
        }
        
        return null; 
    }

    private void ChangeState(HorseState newState)
    {
        currentState = newState;
        Debug.Log("Horse state changed to: " + newState);
    }

    // Visual debugging
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, appleDetectionRadius);
        
        if (targetArea != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, targetArea.position);
        }
    }
}