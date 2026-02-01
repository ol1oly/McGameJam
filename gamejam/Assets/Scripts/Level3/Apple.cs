using UnityEngine;

public class Apple : MonoBehaviour
{
    public bool IsFallen = false;
    public void onPecked()
    {
        if (IsFallen) return;

        IsFallen = true;

        transform.rotation = Quaternion.Euler(0, 0, 90);
        transform.position = transform.position + new Vector3(- .5f, -.4f);
        Collider2D col = GetComponent<Collider2D>();

        if (col != null)
        {
            col.enabled = false;
        }
    }
}
