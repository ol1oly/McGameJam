using UnityEngine;


[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class activateOutline : MonoBehaviour
{

    Material outline;

    private MouseInputProvider _mouse;

    private bool isOver = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        outline = GetComponent<SpriteRenderer>().material;
        Debug.Log("hello");

    }


    void Awake()
    {
        _mouse = FindObjectOfType<MouseInputProvider>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = _mouse.WorldPosition;
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            OnMouseEnter();
        }
        else
        {
            OnMouseExit();
        }
    }

    void OnMouseEnter()
    {
        Debug.Log("enter ");
        if (!isOver) outline.SetFloat("_activeOutline", 1);
        isOver = true;
    }
    void OnMouseExit()
    {
        Debug.Log("leave");
        outline.SetFloat("_activeOutline", 0);
        if (isOver) outline.SetFloat("_activeOutline", 0);
        isOver = false;
    }


}
