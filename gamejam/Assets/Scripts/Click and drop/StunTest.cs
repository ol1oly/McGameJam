using UnityEngine;

public class StunTest : MonoBehaviour
{
    public float stunDuration = 2f;
    private bool isStunned = false;
    private float stunTimer = 0f;
    
    void Update()
    {
        if (isStunned)
        {
            stunTimer -= Time.deltaTime;
            if (stunTimer <= 0f)
            {
                UnStun();
            }
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pickupable"))
        {
            GetStunned();
        }
    }
    
    void GetStunned()
    {
        isStunned = true;
        stunTimer = stunDuration;
        Debug.Log(gameObject.name + " got stunned!");
        
        //visual feedback
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.color = Color.yellow; //stun color
        }
        
        //stop movement if it has AttractableObject
        AttractableObject attractable = GetComponent<AttractableObject>();
        if (attractable != null)
        {
            attractable.enabled = false; // Disable movement script
        }
    }
    
    void UnStun()
    {
        isStunned = false;
        Debug.Log(gameObject.name + " recovered from stun!");
        
        // Reset color
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.color = Color.white;
        }
        
        // Re-enable movement
        AttractableObject attractable = GetComponent<AttractableObject>();
        if (attractable != null)
        {
            attractable.enabled = true;
        }
    }
}