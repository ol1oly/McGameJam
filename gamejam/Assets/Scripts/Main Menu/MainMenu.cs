using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadGame()
    {
        // load game -- first scene (currently general scene)
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        // quit game
        Application.Quit();
        Debug.Log("quit");
    }
}
