using UnityEngine;
using UnityEngine.InputSystem;

public class DropTest : MonoBehaviour
{
    [SerializeField] private bool isTesting = false;
    public GameObject objectToDrop; //drag in here 
    
    void Update()
    {
        /*
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            TestDrop();
        }
        */

           if (isTesting && Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            TestDrop();
        }
    }
    
    public void TestDrop()
    {
        if (objectToDrop != null)
        {
            
            Rigidbody2D rb = objectToDrop.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.bodyType= RigidbodyType2D.Dynamic; //wasnt there btw
                rb.simulated = true;
                rb.gravityScale = 2f;
            }

             Debug.Log("Dropped object!"+objectToDrop.name);

            PickupableObjects pickup = objectToDrop.GetComponent<PickupableObjects>();
            if (pickup != null)
            {
                pickup.OnDrop();
            }

           
        }
    }
}