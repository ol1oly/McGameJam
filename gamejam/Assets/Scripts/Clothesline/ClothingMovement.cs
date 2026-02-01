using Unity.VisualScripting;
using UnityEngine;

public class ClothingMovement : MonoBehaviour//, IClickable

{
    private GameObject clothing;

    private float speed = 20f;
    private bool isMoving;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    
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
        isMoving = clothing.GetComponent<FallingObject>().body.isKinematic;
        // stop moving at the end of the clothesline
        if (transform.position.x < maxRight - 0.5 && isMoving) {
            transform.Translate((Vector2.right) * (2));
        }
       
    }

    public void moveLeft(float maxLeft)
    {
        isMoving = clothing.GetComponent<FallingObject>().body.isKinematic;
        // stop moving at the end of the clothesline
        if (transform.position.x > maxLeft + 0.5 && isMoving)
        {
            transform.Translate((Vector2.left) * (2));
        }
    }

   
}

