using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    AudioManager manager;

    public string level1Music;
    public string level2Music;
    public string level3Music;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = AudioManager.instance;
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == null) return;
        Debug.Log(sceneName);
        if (sceneName.Contains("1"))
        {
            manager.PlaySound(level1Music);
        }
        else if (sceneName.Contains("2"))
        {
            manager.PlaySound(level2Music);
        }
        else
        {
            manager.PlaySound(level3Music);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
