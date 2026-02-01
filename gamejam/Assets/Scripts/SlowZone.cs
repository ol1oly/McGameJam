using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public class SlowZone : MonoBehaviour
{
    public float speedChange = 1;  // multiply it by this

    public float timeToChange = 1;

    void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }
}
