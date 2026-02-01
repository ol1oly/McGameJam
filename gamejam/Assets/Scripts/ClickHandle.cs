using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class ClickHandler : MonoBehaviour
{
    [SerializeField]
    private bool _hasToBeInRange;
    private bool _isInRange;
    [SerializeField]
    private UnityEvent _clicked;

    private MouseInputProvider _mouse;
    private BoxCollider2D _collider;
    private IClickable _clickable;
    private GameObject crow;
    private GameObject player;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
        _mouse = FindObjectOfType<MouseInputProvider>();
        _mouse.Clicked += MouseOnClicked;

        _clickable = GetComponent<IClickable>();
    }
    public void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnDestroy()
    {
        if (_mouse != null)
            _mouse.Clicked -= MouseOnClicked;
    }

    private void MouseOnClicked()
    {
        if (_collider.bounds.Contains(_mouse.WorldPosition))
        {
            if (!_hasToBeInRange)
            {
                _clickable?.OnClick();
                _clicked?.Invoke();
            }
            else
            {
                player.GetComponent<PlayerMovement>().SetMoveToTarget(true, transform);
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("what tag trigger?" + col.gameObject.tag);
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Near the object");
            _clickable?.OnClick();
            _clicked?.Invoke();

            _isInRange = true;
            player.GetComponent<PlayerMovement>().SetMoveToTarget(false, null);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            _isInRange = false;
        }
    }
}
//using UnityEngine;
//using UnityEngine.Events;

//[RequireComponent(typeof(BoxCollider2D))]
//public class ClickHandler : MonoBehaviour
//{
//    [SerializeField]
//    private UnityEvent _clicked;

//    public void HandleClick()
//    {
//        _clicked?.Invoke();
//    }
//}