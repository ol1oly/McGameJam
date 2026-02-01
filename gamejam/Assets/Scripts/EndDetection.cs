using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public class EndDetection : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ennemy"))
        {
            Debug.Log("you lost");
        }

        if (collision.gameObject.CompareTag("success"))
        {
            Debug.Log("you won");
        }

    }


}
