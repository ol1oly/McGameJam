using UnityEngine;

public class AudioGirl : MonoBehaviour
{

    public void playStepSound()
    {
        AudioManager.instance.playRandomSound(AudioManager.instance.Stepsounds);
    }
}
