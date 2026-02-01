using UnityEngine;
using UnityEngine.InputSystem;
public class Level2CrowMovement : MonoBehaviour
{
    [SerializeField] private float speed = 4f;

    [SerializeField] private Transform imageOffset;
    //private MouseInputProvider mouse;
    void Awake()
    {
        //mouse = FindObjectOfType<MouseInputProvider>();
    }
    void LateUpdate()
    {
        // Get mouse world position
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        // Compute target position relative to the parent so the offset stays correct

        Vector2 targetPosition = mouseWorldPosition - ((Vector2)transform.position - ((Vector2)transform.position - (Vector2)imageOffset.position));


        // Smoothly move crow toward target
        transform.position += Vector3.MoveTowards(
            Vector3.zero,
            targetPosition,
            speed * Time.deltaTime
        );
    }
}