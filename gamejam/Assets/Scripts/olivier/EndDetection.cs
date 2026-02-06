using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


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
#if UNITY_EDITOR
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
#endif
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ennemy"))
        {
            Debug.Log("you lost in: " + Time.timeSinceLevelLoad + " seconds");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (collision.gameObject.CompareTag("success"))
        {
            Debug.Log("you won in: " + Time.timeSinceLevelLoad + " seconds");
            SceneManager.LoadScene("level-3");
        }

    }


}
