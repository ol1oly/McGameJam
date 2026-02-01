using UnityEngine;
using UnityEngine.InputSystem;
public class Level2CrowMovement : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    //private MouseInputProvider mouse;
    void Awake()
    {
        //mouse = FindObjectOfType<MouseInputProvider>();
    }
    void Update()
    {
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        transform.position = Vector2.MoveTowards(
            transform.position,
            mouseWorldPos, speed * Time.deltaTime);
    }
}