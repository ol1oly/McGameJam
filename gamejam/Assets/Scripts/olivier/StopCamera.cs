using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class StopCamera : MonoBehaviour
{
    [SerializeField] private GameObject toStop; // assign main camera in inspector

    [SerializeField] private GameObject Witch;

    [SerializeField] private Transform witchPositionCamera;
    [SerializeField] private float followSpeed = 5f;
    private SpriteRenderer sr;

    private bool reachedPosition = false;


    private bool cameraAttached = true;
    private Vector3 offset;


    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

        // initial offset between camera and witch
        offset = toStop.transform.position - witchPositionCamera.position;

        StartCoroutine(HandleCameraMovement());
    }

    IEnumerator HandleCameraMovement()
    {

        bool following = false;

        while (true)
        {
            if (!following)
            {
                // Start following if Witch enters the trigger
                if (Witch != null && witchPositionCamera.position.x <= Witch.transform.position.x)
                {
                    following = true;
                }
            }
            else
            {
                // Follow the Witch
                FollowWitch();

                // Stop following when sprite becomes visible
                if (sr.isVisible)
                {
                    following = false;
                }
            }

            yield return null;
        }
    }


    private void FollowWitch()
    {
        Vector3 targetPos = Witch.transform.position + offset;
        toStop.transform.position = Witch.transform.position + offset;

    }
}
