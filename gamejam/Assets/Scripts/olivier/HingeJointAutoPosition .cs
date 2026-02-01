using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(SpriteRenderer))]
public class HingeJointAutoPosition : MonoBehaviour
{
    public HingeJoint2D topHinge;
    public HingeJoint2D bottomHinge;

    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void OnValidate()
    {


        if (sr == null) return;
        if (topHinge == null || bottomHinge == null) return;

        // Get the world-space size of the sprite
        Vector2 size = sr.bounds.size;

        // Set hinge anchors in local space
        Vector3 localTop = new Vector3(0, size.y / 2f, 0);
        Vector3 localBottom = new Vector3(0, -size.y / 2f, 0);

        topHinge.connectedAnchor = transform.InverseTransformPoint(transform.position + localTop);
        bottomHinge.connectedAnchor = transform.InverseTransformPoint(transform.position + localBottom);
    }

}
