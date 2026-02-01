using UnityEngine;

public class guardStart : MonoBehaviour
{
    [SerializeField] private Villager villager;
    [SerializeField] private GameObject crow;
    public void StartPatrolling(){
        villager.SetStartPatrol();
        crow.SetActive(true);
    }
    public void SetWalk()
    {
        villager.SetCurrentState(VillagerState.Walking);
    }
    public void SetIdle()
    {
        villager.SetCurrentState(VillagerState.Idle);
    }
    public void AppearBird()
    {
        
    }
}
