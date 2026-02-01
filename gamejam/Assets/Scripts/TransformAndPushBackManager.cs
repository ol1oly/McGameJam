using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class TransformAndPushBackManager : MonoBehaviour
{
    [Header("PushBack Zones Root")]
    public GameObject pushBackZonesRoot;

    [Header("PushBack Parameters")]
    public float strength = 1f;
    public float upwardComponent = 0.2f;
    public float velocityMultiplier = 1f;
    public float maxForce = 20f;
    public float forceOnOther = 3f;

    public ForceMode2D modePlayer = ForceMode2D.Force;
    public ForceMode2D modeBox = ForceMode2D.Impulse;

    [Header("Transforms to Reset")]
    public List<Transform> transformsToReset;

    // Store starting values
    private List<Vector3> startPositions = new List<Vector3>();
    private List<Quaternion> startRotations = new List<Quaternion>();
    private List<Vector3> startScales = new List<Vector3>();

    private PushBackZone[] pushBackZones;



    public Rigidbody2D[] rbs;

    public void ResetRigidbodies()
    {
        for (int i = 0; i < rbs.Length; i++)
        {
            Rigidbody2D rb = rbs[i];
            if (rb == null) continue;

            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }

    void Start()
    {
        // Save initial transform values
        foreach (var t in transformsToReset)
        {
            startPositions.Add(t.position);
            startRotations.Add(t.rotation);
            startScales.Add(t.localScale);
        }

        // Find all PushBackZone components in the root GameObject
        if (pushBackZonesRoot != null)
        {
            pushBackZones = pushBackZonesRoot.GetComponentsInChildren<PushBackZone>();
        }
        if (pushBackZonesRoot != null)
        {
            rbs = pushBackZonesRoot.GetComponentsInChildren<Rigidbody2D>();
        }
    }

    void Update()
    {
        // Reset all transforms to their starting values
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            ResetTransforms();
            ResetRigidbodies();

        }

        // Update all PushBackZones to match current parameters
        if (pushBackZones != null)
        {
            foreach (var zone in pushBackZones)
            {
                if (zone == null) continue;

                zone.strength = strength;
                zone.upwardComponent = upwardComponent;
                zone.velocityMultiplier = velocityMultiplier;
                zone.maxForce = maxForce;
                //zone.slowDownScale = forceOnOther;
                zone.modeBox = modeBox;
                zone.modePlayer = modePlayer;
            }
        }
    }

    // Resets all transforms to their start values
    public void ResetTransforms()
    {
        for (int i = 0; i < transformsToReset.Count; i++)
        {
            if (transformsToReset[i] == null) continue;

            transformsToReset[i].position = startPositions[i];
            transformsToReset[i].rotation = startRotations[i];
            transformsToReset[i].localScale = startScales[i];
        }
    }
}
