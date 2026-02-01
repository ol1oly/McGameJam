using UnityEngine;

public class StunGuard : MonoBehaviour
{
    
    private GameObject guard;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Guard"))
        {
            guard = collision.gameObject;
            GetStunned();
        }
    }
    
    void GetStunned()
    {
        Debug.Log(gameObject.name + " got stunned!");
        guard.GetComponent<Villager>().SetCurrentState(VillagerState.Stun);
    }
    
}
