using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class BreakRope : MonoBehaviour, IClickable
{

    private Level2CrowMovement crow;
    void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;

        crow = FindObjectOfType<Level2CrowMovement>();
    }

    public void OnClick()
    {
        HingeJoint2D hinge = GetComponent<HingeJoint2D>();
        hinge.enabled = false;

        crow.getAnim().SetTrigger("Interact");


    }
}