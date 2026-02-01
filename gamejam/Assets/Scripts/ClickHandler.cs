using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class ClickHandler : MonoBehaviour, IClickable
{
    [SerializeField]
    private UnityEvent _clicked;
    

    [SerializeField]
    private bool _isPickupable = false;

    public void OnClick()
    {
         if (_isPickupable)
        {
            CrowInventory crow = FindObjectOfType<CrowInventory>();
            if (crow != null)
            {
                crow.TryPickup(gameObject);
            }
        }
        _clicked?.Invoke();
    }
}