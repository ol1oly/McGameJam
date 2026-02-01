using UnityEngine;

public class Lantern : MonoBehaviour
{
    public GameObject oilSpillPrefab;

    public Vector2 spillOffset = new Vector2(1f, -0.5f); //relative pos to lantern
    private bool hasSpilled = false;


    public void onPecked()
    {
        if(hasSpilled) return;

        hasSpilled = true;
        Debug.Log("Lanter tipped! Oil spilling...");

        if(oilSpillPrefab != null)
        {
            Vector2 spillPosition = (Vector2)transform.position + spillOffset;
            Instantiate(oilSpillPrefab, spillPosition, Quaternion.identity);
        }

        transform.rotation = Quaternion.Euler(0,0,90);

        Collider2D col = GetComponent<Collider2D>();

        if(col != null)
        {
            col.enabled = false;
        }
    }
}
