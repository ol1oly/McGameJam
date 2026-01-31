using UnityEngine;

public class CrowFollowMouse : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    [SerializeField] private MouseInputProvider mouse;

    void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            mouse.WorldPosition,
            speed * Time.deltaTime
        );
    }
}