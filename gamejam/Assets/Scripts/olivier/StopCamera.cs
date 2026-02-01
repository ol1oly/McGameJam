using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class StopCamera : MonoBehaviour
{
    [SerializeField] private GameObject toStop; // assign main camera in inspector
    private SpriteRenderer sr;
    private bool cameraAttached = false;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        if (!cameraAttached && sr.isVisible)
        {
            AttachCamera();
        }
    }

    private void AttachCamera()
    {
        cameraAttached = true;

        // Attach camera but keep its world position, rotation, and scale
        toStop.transform.SetParent(transform, true);
    }
}
