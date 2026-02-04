using UnityEngine;
using UnityEngine.InputSystem;

public class AudioCrow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current != null && Mouse.current.rightButton.wasPressedThisFrame)
        {
            Debug.Log("caw sound");
            AudioManager.instance.playRandomSound(AudioManager.instance.Cawksounds);
        }
    }

    void playRandomFlapSound()
    {
        AudioManager.instance.playRandomSound(AudioManager.instance.flapsounds);
    }

}
