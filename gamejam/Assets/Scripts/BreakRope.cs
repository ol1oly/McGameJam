using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class BreakRope : MonoBehaviour, IClickable
{
    void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    public void OnClick()
    {
        HingeJoint2D hinge = GetComponent<HingeJoint2D>();
        hinge.enabled = false;


    }
}