
using UnityEngine;



[CreateAssetMenu(fileName = "NewSound", menuName = "Audio/Sound")]
public class Sound : ScriptableObject
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 0.5f;

    [Range(0.1f, 3f)]
    public float pitch = 1f;

    public bool loop = false;

    [Range(0f, 30f)]
    public float fadeInTime = 0f;

    public bool playOneShot = true;
}
