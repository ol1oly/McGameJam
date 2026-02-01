using UnityEngine;

public class guardStart : MonoBehaviour
{
    [SerializeField] private Villager villager;
    public void StartPatrolling(){
        villager.SetStartPatrol();
        
    }
    public void SetWalk()
    {
        villager.SetCurrentState(VillagerState.Walking);
    }
    public void SetIdle()
    {
        villager.SetCurrentState(VillagerState.Idle);
    }
}
