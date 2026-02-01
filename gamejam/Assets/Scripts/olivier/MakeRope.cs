using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteAlways]
public class MakeRope : MonoBehaviour
{

    public Rigidbody2D topConnected;

    public Rigidbody2D bottomConnected;



    public GameObject ropeSegmentPrefab;
    [Range(1, 100)] public int segmentCount = 6;
    public bool autoRegenerate;

    float segmentLength;


    bool CacheSegmentLength()
    {
        if (ropeSegmentPrefab == null) return false;

        var sr = ropeSegmentPrefab.GetComponent<SpriteRenderer>();
        if (sr == null)
        {
            Debug.LogError("Rope segment prefab needs a SpriteRenderer");
            return false;
        }

        // Get the height of the sprite in world units
        segmentLength = sr.sprite.rect.height / sr.sprite.pixelsPerUnit * ropeSegmentPrefab.transform.localScale.y * transform.localScale.y;
        return true;
    }

    [ContextMenu("Generate Rope")]
    public void GenerateRope()
    {
        if (!CacheSegmentLength()) return;
        if (ropeSegmentPrefab == null || segmentLength <= 0f) return;

        ClearChildren();

        Rigidbody2D prevBody = null;

        for (int i = 0; i < segmentCount; i++)
        {

            Vector2 pos = transform.position + (-transform.up) * (segmentLength * i);

            GameObject seg = Instantiate(ropeSegmentPrefab, pos, transform.rotation, transform);

#if UNITY_EDITOR
            if (!Application.isPlaying)
                Undo.RegisterCreatedObjectUndo(seg, "Create Rope Segment");
#endif

            Rigidbody2D rb = seg.GetComponent<Rigidbody2D>();
            if (rb == null) rb = seg.AddComponent<Rigidbody2D>();

            HingeJoint2D hj = seg.GetComponent<HingeJoint2D>();
            if (hj == null) hj = seg.AddComponent<HingeJoint2D>();

            hj.autoConfigureConnectedAnchor = false;
            hj.anchor = Vector2.up * (0.5f);

            if (prevBody != null)
            {
                hj.connectedBody = prevBody;
                hj.connectedAnchor = Vector2.down * (0.5f);
            }
            else
            {
                hj.connectedBody = topConnected;
                hj.connectedAnchor = Vector2.zero;
            }

            prevBody = rb;
        }
        ConfigureBottomConnected(prevBody);



    }
    void ConfigureBottomConnected(Rigidbody2D prevBody)
    {
        HingeJoint2D hj = bottomConnected.GetComponent<HingeJoint2D>();
        if (hj == null) hj = bottomConnected.gameObject.AddComponent<HingeJoint2D>();

        hj.autoConfigureConnectedAnchor = false;
        hj.connectedBody = prevBody;

        // Bottom center of prevBody in world space
        Bounds prevBounds = prevBody.GetComponent<SpriteRenderer>().bounds;
        Vector2 prevBottomCenterWorld = new Vector2(prevBounds.center.x, prevBounds.min.y);

        // Convert to local positions
        hj.connectedAnchor = prevBody.transform.InverseTransformPoint(prevBottomCenterWorld);
        hj.anchor = bottomConnected.transform.InverseTransformPoint(prevBottomCenterWorld);
    }

    [ContextMenu("Clear Children")]
    void ClearChildren()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
                Undo.DestroyObjectImmediate(transform.GetChild(i).gameObject);
            else
                Destroy(transform.GetChild(i).gameObject);
#else
            Destroy(transform.GetChild(i).gameObject);
#endif
        }
    }
}
