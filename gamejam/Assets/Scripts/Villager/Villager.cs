using System.Collections;
using UnityEngine;

public class Villager : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 1f;
    private VillagerState currentState = VillagerState.Walking;
    

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(RandomMovementCoroutine());

    }
    public void SetCurrentState(VillagerState state)
    {
        currentState = state;
    }
    public void SetCurrentStateBack()
    {
        currentState = VillagerState.Idle;
        StopAllCoroutines();
        StartCoroutine(RandomMovementCoroutine());
    }

    public IEnumerator RandomMovementCoroutine()
    {
        while (currentState!=VillagerState.Checking)
        {
            yield return new WaitForSeconds(Random.Range(2, 5));
            RandomMovement();
        }
        
    }
    private int direction = 0;
    public void RandomMovement()
    {
        if(currentState == VillagerState.Checking) return;
        int choice = Random.Range(0, 2);
        switch (choice)
        {
            case 0:
                currentState = VillagerState.Idle;
                break;
            case 1:
                SetWalk();
                break;
            default:
                currentState = VillagerState.Idle;
                break;
        }
    }
    public void SetWalk()
    {
        currentState = VillagerState.Walking;
        direction = Random.Range(0, 2); // 0 = left, 1 = right
    }
    void Update()
    {
        if(currentState == VillagerState.Checking)
        {
            Check();
            
        }else if(currentState == VillagerState.Walking)
        {
            Walk();
        }
        else if(currentState == VillagerState.Idle)
        {
            Idle();
        }
        else
        {
            
        }
        AnimationVillager();
    }

    public void RandomChoice()
    {
        
    }
    public void Check()
    {
        Debug.Log("Checking...");
        //TODO: Anis coding part
    }
    private float directionFactor = 1f;
    private void AnimationVillager()
    {
        float speed = rb.linearVelocity.magnitude;
        anim.SetFloat("speed", speed);
        
        if (rb.linearVelocity.x > 0)
        {
            directionFactor = 1f;
        }
        else if(rb.linearVelocity.x < 0)
        {
            directionFactor = -1f;
        }
        transform.localScale = new Vector3(directionFactor, transform.localScale.y,transform.localScale.z);
    }
    public void Walk()
    {
        Debug.Log("Walk...");
        rb.linearVelocity = new Vector2(direction == 0 ? -moveSpeed : moveSpeed, rb.linearVelocityY);
        Debug.Log("Walk... + rb.linearVelocity.x = " + rb.linearVelocity.x);
    }
    public void Idle()
    {
        Debug.Log("Idle...");
        rb.linearVelocity = new Vector2(0, rb.linearVelocityY);
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        direction = direction == 0 ? 1 : 0; // Reverse direction
        
    }
}
