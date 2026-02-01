using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject girl;
    public void GirlEscape()
    {
        girl.SetActive(true);
    }
}
