using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class ClickHandler : MonoBehaviour, IClickable
{
    [SerializeField]
    private UnityEvent _clicked;


    public void OnClick()
    {
        _clicked?.Invoke();
    }
}