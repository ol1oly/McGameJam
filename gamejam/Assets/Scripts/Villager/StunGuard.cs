using System.Collections;
using UnityEngine;

public class StunGuard : MonoBehaviour
{
    [SerializeField] private float timeToOpenDoor = 2f;
    [SerializeField] private GameObject door;
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
        StartCoroutine(WaitForStunToGetOut());
    }
    
    IEnumerator WaitForStunToGetOut()
    {
        yield return new WaitForSeconds(timeToOpenDoor);
        door.GetComponent<Animator>().SetTrigger("Open");
    }
    
}
