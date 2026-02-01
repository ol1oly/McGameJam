using UnityEngine;
using UnityEngine.SceneManagement;

public class Girl : MonoBehaviour
{
    public void NextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex + 1);
    }
}