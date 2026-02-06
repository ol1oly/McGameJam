using UnityEngine;

[CreateAssetMenu(fileName = "PushBackZoneData", menuName = "Gameplay/PushBackZoneData")]
public class PushBackZoneData : ScriptableObject
{
    public float strength = 1f;
    public float upwardComponent = 0.2f;
    public float velocityMultiplier = 1f;
    public float maxForce = 20f;
    public int maxEntriesPerCollider = 2;
}