using UnityEngine;

public class DropCloth : MonoBehaviour
{
    
    public void Drop(GameObject objectToDrop)
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

            objectToDrop.GetComponent<ClothingMovement>().SetFalling(true);
        }
    }
}