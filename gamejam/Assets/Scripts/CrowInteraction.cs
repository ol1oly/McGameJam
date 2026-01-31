using UnityEngine;

public class CrowInteraction : MonoBehaviour
{
    private IClickable currentInteractable;
    private ClickHandler currentClickHandle;
    // [SerializeField] private MouseInputProvider mouse;
    private MouseInputProvider mouse;

    void Awake()
    {
        mouse = FindObjectOfType<MouseInputProvider>();
    }

    void OnEnable()
    {
        mouse.Clicked += TryInteract;
    }

    void OnDisable()
    {
        mouse.Clicked -= TryInteract;
    }

    private void TryInteract()
    {
        currentInteractable?.OnClick();
        currentClickHandle?.HandleClick();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        currentInteractable = other.GetComponent<IClickable>();
        currentClickHandle = other.GetComponent<ClickHandler>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<IClickable>() == currentInteractable || other.GetComponent<ClickHandler>() == currentClickHandle)
        {
            currentInteractable = null;
            currentClickHandle = null;
        }
    }
}