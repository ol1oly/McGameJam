using UnityEngine;

public class WitchEscape : MonoBehaviour
{
    public float runSpeed = 5f;
    
    private bool isEscaping = false;
    
    public void StartEscape()
    {
        isEscaping = true;
        Debug.Log("Witch escaping!");
    }
    
    void Update()
    {
        if (isEscaping)
        {
            transform.position += Vector3.right * runSpeed * Time.deltaTime;
        }
    }
}