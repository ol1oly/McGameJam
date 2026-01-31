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
    public IEnumerator RandomMovementCoroutine()
    {
        while (true)
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
    }

    public void RandomChoice()
    {
        
    }
    public void Check()
    {
        //TODO: Anis coding part
    }
    public void Walk()
    {
        Debug.Log("Walking");
        anim.SetTrigger("Walk");
        rb.linearVelocity = new Vector2(direction == 0 ? -moveSpeed : moveSpeed, rb.linearVelocityY);
    }
    public void Idle()
    {
        Debug.Log("Idle");
        anim.SetTrigger("Idle");
        rb.linearVelocity = new Vector2(0, rb.linearVelocityY);
    }
}
