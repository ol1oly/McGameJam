using UnityEngine;

public class FallingObject : MonoBehaviour, IClickable
{

    public Rigidbody2D body;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    //public void Fall()
    //{
    //    body.isKinematic = false;
    //}
    public void OnClick()
    {
        body.isKinematic = false;

    }

}
