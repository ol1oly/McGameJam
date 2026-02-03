using UnityEngine;

public class Lantern : MonoBehaviour
{
    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Interact()
    {
        
    }
  private bool isClosed = false;
    public void InteractAnim()
    {
        Debug.Log("Interact Light");
        if (!isClosed)
        {
            Debug.LogWarning("Light up");
            isClosed = true;
            anim.SetTrigger("Interact");
        }
        
    }
    public void SetClosed(bool closed)
    {
        Debug.Log("is closed = "+closed);
        isClosed = closed;
    }
}
