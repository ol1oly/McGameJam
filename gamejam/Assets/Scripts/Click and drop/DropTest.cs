using UnityEngine;
using UnityEngine.InputSystem;

public class DropTest : MonoBehaviour
{
    public GameObject objectToDrop; //drag in here 
    
    void Update()
    {
        /*
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            TestDrop();
        }
        */

           if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            TestDrop();
        }
    }
    
    void TestDrop()
    {
        if (objectToDrop != null)
        {
            Rigidbody2D rb = objectToDrop.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.simulated = true;
                rb.gravityScale = 2f;
            }
            
            Debug.Log("Dropped object!");
        }
    }
}