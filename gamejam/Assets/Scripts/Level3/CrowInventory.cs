using UnityEngine;
using UnityEngine.InputSystem;

public class CrowInventory : MonoBehaviour
{
    public Transform beakPosition; // Where carried items appear
    public GameObject carriedObject = null;
    public KeyCode dropKey = KeyCode.Space; // Or change to click

    void Update()
    {
        // Keep carried object at beak
        if (carriedObject != null && beakPosition != null)
        {
            carriedObject.transform.position = beakPosition.position;
        }

        // Drop with spacebar
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Drop();
        }
    }

    public void TryPickup(GameObject obj)
    {
        if (carriedObject != null)
        {
            Debug.Log("Already carrying something!");
            return;
        }

        carriedObject = obj;
        Debug.Log("Picked up: " + obj.name);

        // Disable physics
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
        }

        // Disable collider
        Collider2D col = obj.GetComponent<Collider2D>();
        if (col != null)
        {
            col.enabled = false;
        }
    }

    public void Drop()
    {
        if (carriedObject == null) return;

        Debug.Log("Dropped: " + carriedObject.name);

        // Enable physics
        Rigidbody2D rb = carriedObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

        // Enable collider
        Collider2D col = carriedObject.GetComponent<Collider2D>();
        if (col != null)
        {
            col.enabled = true;
        }

        // Call special drop logic
        PickupableObjects pickup = carriedObject.GetComponent<PickupableObjects>();
        if (pickup != null)
        {
            pickup.OnDrop();
        }

        carriedObject = null;
    }
}