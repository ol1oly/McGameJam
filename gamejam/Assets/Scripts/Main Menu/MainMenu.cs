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
    public void LoadTutorial()
    {
        // load tutorial scene 
        SceneManager.LoadScene(2);
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }
}
