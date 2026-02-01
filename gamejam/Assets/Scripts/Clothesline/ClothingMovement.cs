using Unity.VisualScripting;
using UnityEngine;

public class ClothingMovement : MonoBehaviour//, IClickable

{
    private GameObject clothing;

    private float speed = 20f;
    private bool isMoving;
    private Vector2 originalPos;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Awake()
    {

        clothing = GameObject.FindWithTag("Clothing");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private bool isFalling = false;
    [SerializeField] private float translationAmount = 2f;
    public void moveRight(float maxRight)
    {
        if (!isFalling)
        {
            if (transform.position.x < maxRight - translationAmount - 0.5) {
                transform.Translate((Vector2.right) * (translationAmount));
            }
        }
        //isMoving = clothing.GetComponent<FallingObject>().body.isKinematic;
        // stop moving at the end of the clothesline
        
       
    }
    

    public void moveLeft(float maxLeft)
    {
        if (!isFalling)
        {
            if (transform.position.x > maxLeft + translationAmount + 0.5) {
                transform.Translate(Vector2.left * translationAmount);
            }
        }
        // isMoving = clothing.GetComponent<FallingObject>().body.isKinematic;
        // // stop moving at the end of the clothesline
        // if (transform.position.x > maxLeft + translationAmount + 0.5&& isMoving)
        // {
        //     transform.Translate((Vector2.left) * (translationAmount));
        // }
    }
    public void SetFalling(bool pFalling)
    {
        isFalling = pFalling;
    }
    public void Reset()
    {
        isFalling = false;
        gameObject.transform.position = originalPos;
        rb.simulated = true;
        rb.gravityScale = 0f;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        if (!collision.gameObject.CompareTag("Guard"))
        {
            Reset();
        }
        else
        {
            Destroy(gameObject);
        }
    }

   
}

