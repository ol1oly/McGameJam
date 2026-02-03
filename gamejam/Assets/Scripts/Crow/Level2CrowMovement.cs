using UnityEngine;
using UnityEngine.InputSystem;
public class Level2CrowMovement : MonoBehaviour
{
    [SerializeField] private float speed = 4f;

    [SerializeField] private Transform imageOffset;

    SpriteRenderer[] renderers;

    private Animator anim;
    private SpriteRenderer sr;

    //private MouseInputProvider mouse;
    void Awake()//
    {
        //mouse = FindObjectOfType<MouseInputProvider>();
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        renderers = GetComponentsInChildren<SpriteRenderer>();
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

        // Compute target relative to imageOffset
        Vector2 targetPosition = mouseWorldPosition - (Vector2)imageOffset.position;

        if (Mathf.Abs(targetPosition.x) > 0.05f)
        {
            bool flip = targetPosition.x < 0;
            foreach (var r in renderers)
            {
                r.flipX = flip;
            }
        }
        Vector3 targetLocal = transform.parent.InverseTransformPoint(mouseWorldPosition); // now local
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetLocal, speed * 0.20f * Time.deltaTime);
        // Smoothly move crow toward target
    }


    public Animator getAnim() { return anim; }

    void playRandomFlapSound()
    {
        AudioManager.instance.playRandomSound(AudioManager.instance.flapsounds);
    }


}