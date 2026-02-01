using Unity.VisualScripting;
using UnityEngine;

public class ClothingMovement : MonoBehaviour//, IClickable

{
    //public Rigidbody2D body;

    //[Header("Gravity")]
    //public float baseGravity = 2f;
    //public float maxFallSpeed = 18f;
    //public float fallSpeedMultiplier = 2f;
    //float horizontalMovement;
    private GameObject clothing;

    private float speed = 20f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    //void Awake()
    //{

    //    body = GetComponent<Rigidbody2D>();
    //}
    void Awake()
    {

        clothing = GameObject.FindWithTag("Clothing");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void moveRight(float maxRight)
    {
        // stop moving at the end of the clothesline
        if (transform.position.x < maxRight - 0.5) {
            //transform.Translate((Vector2.right) * (Time.deltaTime * speed * 5));
            transform.Translate((Vector2.right) * (2));
        }
       
    }

    public void moveLeft(float maxLeft)
    {
        // stop moving at the end of the clothesline
        if (transform.position.x > maxLeft + 0.5)
        {
            //transform.Translate((Vector2.left) * (Time.deltaTime * speed * 5));
            transform.Translate((Vector2.left) * (2));
        }
    }

    //public void OnClick()
    //{
    //    clothing.GetComponent<FallingObject>().Fall();
    //}
    // drop clothing/object when clicked
    //public void OnClick()
    //{
    ////    Debug.Log("OnClickClothes");
    ////    // gravity
    ////    //Vector2 newVelocity = new Vector2(horizontalMovement * speed, body.linearVelocity.y);
    ////    //body.linearVelocity = newVelocity;

    ////    //if (body.linearVelocity.y < 0)
    ////    //{
    ////    //    body.gravityScale = baseGravity * fallSpeedMultiplier;  // fall increasingly faster
    ////    //    body.linearVelocity = new Vector2(body.linearVelocity.x, Mathf.Max(body.linearVelocity.y, -maxFallSpeed));
    ////    //}
    ////    //else
    ////    //{
    ////    //    body.gravityScale = baseGravity;
    ////    //}
    //    //body.isKinematic = false;
    //}
}

