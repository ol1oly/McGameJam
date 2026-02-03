using UnityEngine;

public class AdjustSpeedForCatch : MonoBehaviour
{
    [SerializeField] private ForceBasedMovement hunter;  // this object
    [SerializeField] private ForceBasedMovement witch; // target object
    [SerializeField] private float timeToCatch = 2f;

    void Awake()
    {
        AdjustSpeed();
    }

    [ContextMenu("Adjust Speed to Catch")]
    private void AdjustSpeed()
    {
        if (hunter == null)
        {
            Debug.LogError($"{nameof(hunter)} is not assigned on {name}");
            return;
        }

        if (witch == null)
        {
            Debug.LogError($"{nameof(witch)} is not assigned on {name}");
            return;
        }

        if (timeToCatch <= 0f)
        {
            Debug.LogError($"{nameof(timeToCatch)} must be greater than 0 on {name}");
            return;
        }
        float TargetX = witch.GetComponent<BoxCollider2D>().bounds.min.x;
        float HunterX = hunter.GetComponent<BoxCollider2D>().bounds.max.x;
        float distance = Mathf.Abs(TargetX - HunterX);
        float requiredSpeed = witch.maxSpeed + (distance / timeToCatch);

        hunter.maxSpeed = requiredSpeed;

        Debug.Log($"Adjusted {hunter.name} speed to {requiredSpeed} to catch {witch.name} in {timeToCatch} seconds.");
        Debug.Log("witchX: " + TargetX + " HunterX: " + HunterX);
    }
}
