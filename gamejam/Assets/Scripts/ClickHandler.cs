using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class ClickHandler : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _clicked;

    public void HandleClick()
    {
        _clicked?.Invoke();
        Debug.Log("salut");
    }
}