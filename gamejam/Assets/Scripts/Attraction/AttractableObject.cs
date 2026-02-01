using UnityEngine;

public class AttractableObject : MonoBehaviour
{

    public float moveSpeed = 2f;
    public string attractionTag = "Attraction"; //what can attract the obj
    private Transform attractionTarget;
    private bool isAttracted = false;
    private Vector2 originalPosition; //vecteur (i,j) par rapport a og pos?
    private bool shouldReturnToOriginal = false;
    private Villager villager;
    private Rigidbody2D rb;
    [SerializeField]private GameObject lightLantern;
    
    void Start()
    {
        originalPosition = transform.position; //huh
        villager = GetComponent<Villager>();
    }
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
    if (isAttracted && attractionTarget != null)
    {
        float deltaX = attractionTarget.position.x - rb.position.x;
        
        if (Mathf.Abs(deltaX) < 0.1f)
        {
            rb.linearVelocity = Vector2.zero;
            OnReachedAttraction();
            return;
        }
        //Debug.Log("HeyX+" + rb.linearVelocity.x);
        float dir = Mathf.Sign(deltaX);
        rb.linearVelocity = new Vector2(dir * moveSpeed, rb.linearVelocity.y);
    }
    else if (shouldReturnToOriginal)
    {
        float deltaX = originalPosition.x - rb.position.x;

        if (Mathf.Abs(deltaX) < 0.1f)
        {
            rb.linearVelocity = Vector2.zero;
            Returned();
            Debug.Log("HeyX+" + rb.linearVelocity.x);
            return;
        }

        float dir = Mathf.Sign(deltaX);
        rb.linearVelocity = new Vector2(dir * moveSpeed, rb.linearVelocity.y);
        Debug.Log("HeyX+" + rb.linearVelocity.x);
    }
}
    
    public void SetChecking()
    {
        villager.SetCurrentState(VillagerState.Checking);
    }
    



    public void AttractTo(Transform target)
    {
        originalPosition = transform.position;
        attractionTarget = target;
        isAttracted = true;
        shouldReturnToOriginal = false;
        Debug.LogWarning(gameObject.name + "is now attracted to"+target.name);
        
    }

    public void StopAttraction(bool returnToStart = false)
    {
        isAttracted = false;
        attractionTarget = null;
        
        
        Debug.LogWarning("stop attraction");
        
    }
    private void Returned()
    {
        villager.SetCurrentStateBack();
        shouldReturnToOriginal = false;
    }
    private void OnReachedAttraction()
    {
        Debug.Log(gameObject.name + "reached the attraction point!");
        StopAttraction(true);
        villager.gameObject.GetComponent<Animator>().SetTrigger("Check");
        rb.linearVelocity = new Vector2(0, rb.linearVelocityY);
    }
    [SerializeField] private float waitBeforeReturning = 2f;
    public void StartReturn()
    {
        shouldReturnToOriginal = true;
        lightLantern.GetComponent<Animator>().SetTrigger("Relight");
        lightLantern.GetComponent<Lantern>().SetClosed(false);
    }
}
