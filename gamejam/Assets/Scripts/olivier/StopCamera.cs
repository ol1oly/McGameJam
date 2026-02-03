using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class StopCamera : MonoBehaviour
{
    [SerializeField] private GameObject toStop; // assign main camera in inspector

    [SerializeField] private GameObject Witch;

    [SerializeField] private Transform witchPositionCamera;

    private SpriteRenderer sr;
    private Vector3 offset;


    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

        // initial offset between camera and witch
        offset = toStop.transform.position - witchPositionCamera.position;

        StartCoroutine(HandleCameraMovement());
    }
    private enum CameraFollowState
    {
        REACHED_END,
        FOLLOWING_WITCH,
        START_LEVEL
    }


    IEnumerator HandleCameraMovement()
    {
        CameraFollowState state = CameraFollowState.START_LEVEL;


        while (true)
        {
            if (state == CameraFollowState.START_LEVEL)
            {
                if (Witch != null && witchPositionCamera.position.x <= Witch.transform.position.x)
                {
                    state = CameraFollowState.FOLLOWING_WITCH;
                }
            }
            else if (state == CameraFollowState.FOLLOWING_WITCH)
            {
                FollowWitch();
                if (sr.isVisible)
                {
                    state = CameraFollowState.REACHED_END;
                }

            }


            yield return null;
        }
    }
    private void FollowWitch()
    {
        toStop.transform.position = Witch.transform.position + offset;

    }
}
