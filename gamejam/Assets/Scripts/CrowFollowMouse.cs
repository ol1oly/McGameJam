using UnityEngine;

public class CrowFollowMouse : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    private MouseInputProvider mouse;
    void Awake()
    {
        mouse = FindObjectOfType<MouseInputProvider>();
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            mouse.WorldPosition,
            speed * Time.deltaTime
        );
    }
}