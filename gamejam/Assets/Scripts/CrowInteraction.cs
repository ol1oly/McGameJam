using System.Collections.Generic;
using UnityEngine;

public class CrowInteraction : MonoBehaviour
{
    private readonly List<IClickable> currentInteractables = new();
    private MouseInputProvider mouse;
    private GameObject currentHover;

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
        for (int i = 0; i < currentInteractables.Count; i++)
        {
            currentInteractables[i].OnClick();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var clickables = other.GetComponents<IClickable>();
        if (clickables.Length == 0) return;

        currentHover = other.gameObject;
        currentInteractables.Clear();
        currentInteractables.AddRange(clickables);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (currentHover != other.gameObject) return;

        currentHover = null;
        currentInteractables.Clear();
    }
}
