using UnityEngine;
using UnityEngine.SceneManagement;

public class Girl : MonoBehaviour
{   
    [SerializeField] private Animator girlAnim;
    [SerializeField] private GameObject guard;
    public void NextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex + 1);
    }
    public void StartEnemy()
    {
        guard.SetActive(true);
    }
    public void ChangeToIdle()
    {
        girlAnim.SetTrigger("Idle");
    }
}