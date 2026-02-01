// using System.Collections;
// using UnityEngine;

// public class Villager : MonoBehaviour
// {
//     private Animator anim;
//     private Rigidbody2D rb;
//     [SerializeField] private float moveSpeed = 1f;
//     [SerializeField] private GameObject limitGuard;
//     private VillagerState currentState = VillagerState.Walking;
//     private float directionFactor = 1f;

//     void Start()
//     {
//         anim = GetComponent<Animator>();
//         rb = GetComponent<Rigidbody2D>();
//         StartCoroutine(RandomMovementCoroutine());

//     }
//     public void SetCurrentState(VillagerState state)
//     {
//         if(currentState == VillagerState.Stun) return;
//         currentState = state;
//     }
//     public void SetCurrentStateBack()
//     {
//         currentState = VillagerState.Idle;
//         StopAllCoroutines();
//         StartCoroutine(RandomMovementCoroutine());
//     }

//     public IEnumerator RandomMovementCoroutine()
//     {
//         while (currentState!=VillagerState.Checking)
//         {
//             yield return new WaitForSeconds(Random.Range(2, 5));
//             RandomMovement();
//         }
        
//     }
//     private int direction = 0;
//     private bool hasLimit = true;
//     public void RandomMovement()
//     {
//         if(currentState == VillagerState.Checking) return;
//         int choice = Random.Range(0, 2);
//         hasLimit = true;
//         switch (choice)
//         {
//             case 0:
//                 currentState = VillagerState.Idle;
//                 break;
//             case 1:
//                 SetWalk();
//                 break;
//             default:
//                 currentState = VillagerState.Idle;
//                 break;
//         }
//     }

//     public void SetWalk()
//     {
//         currentState = VillagerState.Walking;
//         direction = Random.Range(0, 2); // 0 = left, 1 = right
//     }
//     void Update()
//     {
//         if(currentState == VillagerState.Stun)
//         {
//             Stun();
//         }else if(currentState == VillagerState.Checking)
//         {
//             Check();
            
//         }else if(currentState == VillagerState.Walking)
//         {
//             Walk();
//         }
//         else if(currentState == VillagerState.Idle)
//         {
//             Idle();
//         }
//         else
//         {
            
//         }
//         AnimationVillager();
//     }
//     public void Stun()
//     {
//         rb.linearVelocity = new Vector2(0, rb.linearVelocityY);
//         rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
//         anim.SetTrigger("Stun");
//         StopAllCoroutines();
//     }
//     public void RandomChoice()
//     {
        
//     }
//     public void Check()
//     {
//         //Debug.Log("Checking...");
//         //TODO: Anis coding part
//     }
    
//     private void AnimationVillager()
//     {
//         float speed = rb.linearVelocity.magnitude;
//         anim.SetFloat("speed", speed);
        
//         if (rb.linearVelocity.x > 0)
//         {
//             directionFactor = 1f;
//         }
//         else if(rb.linearVelocity.x < 0)
//         {
//             directionFactor = -1f;
//         }
//         transform.localScale = new Vector3(directionFactor, transform.localScale.y,transform.localScale.z);
//     }
//     public void Walk()
//     {
//         //Debug.Log("Walk...");
//         rb.linearVelocity = new Vector2(directionFactor * moveSpeed, rb.linearVelocityY);
//         if(transform.position.x < limitGuard.transform.position.x)
//         {
//             directionFactor = 1;
//         }
//     }
//     public void Idle()
//     {
//         //Debug.Log("Idle...");
//         rb.linearVelocity = new Vector2(0, rb.linearVelocityY);
//     }
//     public void OnCollisionEnter2D(Collision2D other)
//     {
//         directionFactor = direction == 0 ? 1 : 0; // Reverse direction
//     }
// }
using System.Collections;
using UnityEngine;

public class Villager : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    [SerializeField] private float moveSpeed = 1f;

    [Header("Movement Limits")]
    [SerializeField] private Transform leftLimit;
    [SerializeField] private Transform rightLimit;
    private bool hasLimit = true;

    private VillagerState currentState = VillagerState.Walking;

    // 1 = right, -1 = left
    private int direction = 1;

    private float directionFactor = 1f;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        StartCoroutine(RandomMovementCoroutine());
    }

    void Update()
    {
        switch (currentState)
        {
            case VillagerState.Stun:
                Stun();
                break;

            case VillagerState.Checking:
                Check();
                break;

            case VillagerState.Walking:
                // movement handled in FixedUpdate
                break;

            case VillagerState.Idle:
                Idle();
                break;
        }

        UpdateAnimation();
    }

    void FixedUpdate()
    {
        if (currentState == VillagerState.Walking)
        {
            Walk();
        }
    }

    // =========================
    // State Management
    // =========================

    public void SetCurrentState(VillagerState state)
    {
        if (currentState == VillagerState.Stun) return;
        currentState = state;
    }

    public void SetCurrentStateBack()
    {
        currentState = VillagerState.Idle;
        StopAllCoroutines();
        StartCoroutine(RandomMovementCoroutine());
    }

    // =========================
    // Random Behavior
    // =========================

    private IEnumerator RandomMovementCoroutine()
    {
        while (currentState != VillagerState.Checking)
        {
            yield return new WaitForSeconds(Random.Range(2f, 5f));
            RandomMovement();
        }
    }

    private void RandomMovement()
    {
        if (currentState == VillagerState.Checking) return;

        int choice = Random.Range(0, 2);

        if (choice == 0)
        {
            currentState = VillagerState.Idle;
        }
        else
        {
            SetWalk();
        }
    }

    private void SetWalk()
    {
        currentState = VillagerState.Walking;
        direction = Random.Range(0, 2) == 0 ? -1 : 1;
    }

    // =========================
    // Actions
    // =========================

    private void Walk()
    {
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocityY);

        // Right limit → go left
        if (transform.position.x >= rightLimit.position.x)
        {
            direction = -1;
        }
        // Left limit → go right
        else if (transform.position.x <= leftLimit.position.x)
        {
            direction = 1;
        }
    }

    private void Idle()
    {
        rb.linearVelocity = new Vector2(0f, rb.linearVelocityY);
    }

    private void Stun()
    {
        rb.linearVelocity = Vector2.zero;
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        anim.SetTrigger("Stun");
        StopAllCoroutines();
    }

    private void Check()
    {
        // TODO: checking logic
    }

    // =========================
    // Animation
    // =========================

    private void UpdateAnimation()
    {
        anim.SetFloat("speed", Mathf.Abs(rb.linearVelocity.x));

        if (rb.linearVelocity.x > 0)
            directionFactor = 1f;
        else if (rb.linearVelocity.x < 0)
            directionFactor = -1f;

        transform.localScale = new Vector3(
            directionFactor,
            transform.localScale.y,
            transform.localScale.z
        );
    }

    // =========================
    // Collisions
    // =========================

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Flip direction once on collision
        direction *= -1;
    }
}