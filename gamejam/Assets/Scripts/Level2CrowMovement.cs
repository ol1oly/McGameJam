using UnityEngine;
using UnityEngine.InputSystem;
public class Level2CrowMovement : MonoBehaviour
{
    [SerializeField] private float speed = 4f;

    [SerializeField] private Transform imageOffset;


    private Animator anim;
    private SpriteRenderer sr;

    //private MouseInputProvider mouse;
    void Awake()
    {
        //mouse = FindObjectOfType<MouseInputProvider>();
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    void LateUpdate()
    {
        anim.SetFloat("Speed", speed);
        // Get mouse world position
        moveInDirection();


    }

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            getAnim().SetTrigger("Interact");
            AudioManager.instance.playRandomSound(AudioManager.instance.Cawksounds);
        }

        if (Mouse.current != null && Mouse.current.rightButton.wasPressedThisFrame)
        {
            Debug.Log("caw soujd");
            AudioManager.instance.playRandomSound(AudioManager.instance.Cawksounds);
        }
    }

    void moveInDirection()
    {
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());


        Vector2 targetPosition = mouseWorldPosition - ((Vector2)transform.position - ((Vector2)transform.position - (Vector2)imageOffset.position));

        if (Mathf.Abs(targetPosition.x) > 0.05) sr.flipX = targetPosition.x < 0;

        // Smoothly move crow toward target
        transform.position += Vector3.MoveTowards(
            Vector3.zero,
            targetPosition,
            speed * Time.deltaTime
        );
    }

    public Animator getAnim() { return anim; }

    void playRandomFlapSound()
    {
        AudioManager.instance.playRandomSound(AudioManager.instance.flapsounds);
    }


}