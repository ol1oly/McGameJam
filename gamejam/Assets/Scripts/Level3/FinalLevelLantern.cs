using System.Collections;
using UnityEngine;

public class FinalLevelLantern : MonoBehaviour
{
    public GameObject oilSpillPrefab;

    public Vector2 spillOffset = new Vector2(1f, -0.5f); //relative pos to lantern
    private bool hasSpilled = false;


    public void onPecked()
    {
        if (hasSpilled) return;

        hasSpilled = true;
        Debug.Log("Lanter tipped! Oil spilling...");

        if (oilSpillPrefab != null)
        {
            oilSpillPrefab.SetActive(true);
        }

        transform.rotation = Quaternion.Euler(0, 0, 90);
        transform.position = new Vector2(52.5f, -8.65f);
        Collider2D col = GetComponent<Collider2D>();

        if (col != null)
        {
            col.enabled = false;
        }
    }

}
