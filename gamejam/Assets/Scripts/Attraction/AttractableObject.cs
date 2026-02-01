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
        if (isAttracted && attractionTarget != null)
        {
            
            Vector3 pos = transform.position;
            float targetX = attractionTarget.position.x;

            pos.x = Mathf.MoveTowards(
                pos.x,
                targetX,
                moveSpeed * Time.deltaTime
            );

            transform.position = pos;

            if (Mathf.Abs(pos.x - targetX) < 0.1f)
            {
                OnReachedAttraction();
            }
        }
        else if (shouldReturnToOriginal)
        {
            Vector3 pos = transform.position;
            pos.x = Mathf.MoveTowards(
                pos.x,
                originalPosition.x,
                moveSpeed * Time.deltaTime
            );
            transform.position = pos;
        }
    }

    public void SetChecking()
    {
        //if has a villager component
        Villager villager = GetComponent<Villager>();
        if(villager != null)
        {
            villager.SetCurrentState(VillagerState.Checking);
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
        Villager villager = GetComponent<Villager>();
        if(villager != null)
        {
            villager.SetCurrentStateBack();
        }
    }

    private void OnReachedAttraction()
    {
        Debug.Log(gameObject.name + "reached the attraction point!");
        //custom stuff can be added here lad
        StopAttraction();
    }

    //aka we make something attracted to something and potentially call funcs inbetween
}
