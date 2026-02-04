using UnityEngine;

public class PositionForArrivalTime : MonoBehaviour
{
    [SerializeField] private ForceBasedMovement mover;

    [SerializeField] private Transform initialWitchPosition;

    [SerializeField] private float timeToReach = 40f;

    [ContextMenu("Position For Arrival")]
    private void PositionObject()
    {
        if (mover == null)
        {
            Debug.LogError("could not position the object: " + transform.name + " because the mover is null");
        }

        float distance = mover.maxSpeed * timeToReach;

        Vector3 newPosition = transform.position;        // keep current Y and Z
        newPosition.x = initialWitchPosition.position.x + distance; // only change X

        transform.position = newPosition;
    }

    void Start()
    {
        PositionObject();
    }
}