using UnityEngine;

public class PickupableObjects : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public bool isPickedUp = false;

   public void OnPickUp()
{
        isPickedUp = true;
        Debug.Log(gameObject.name + "was picked up!");

        Collider2D col = GetComponent<Collider2D>();
        if(col != null)
        {
            col.enabled = false;
        }
    }

    public void OnDrop()
    {
        isPickedUp = false;
        Debug.Log(gameObject.name + "was dropped!");

        Collider2D col = GetComponent<Collider2D>();
        if(col!= null)
        {
            col.enabled = true;
        }

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if(rb!= null)
        {
            rb.simulated = true; //gravity physics
        }
    }
}
