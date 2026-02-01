using UnityEngine;
using System.Collections.Generic;

using System.Linq;
using System.Collections;

public class AudioManager : MonoBehaviour
{

    [Range(0f, 1f)] public float musicVolume = 0.2f;


    public static AudioManager instance;
    public AudioSource audioSourcePrefab;



    private List<AudioSource> audioSources = new List<AudioSource>();


    [SerializeField] private List<Sound> sounds = new List<Sound>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            DontDestroyOnLoad(gameObject);

            subscribe();

            string name = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            Debug.Log(name + " is the current scene");

        }
        else Destroy(gameObject);




    }

    /// <summary>
    /// entering a new scene
    /// </summary>
    /// <param name="scene"> true for the game scene, false for main menu scene</param>

    private void OnDisable()
    {
        unsubscribe();
    }

    private AudioSource GetAvailableSource()
    {
        foreach (AudioSource source in audioSources)
        {

            if (source != null && !source.isPlaying) return source;
        }
        AudioSource Source = Instantiate(audioSourcePrefab, transform);
        DontDestroyOnLoad(Source);
        audioSources.Add(Source);
        return Source;
    }


    public void PlaySound(string clipName)
    {
        //if(clipName.Equals("PlayerDeath")) battleTheme.mute = true;
        Sound clip = sounds.FirstOrDefault(s => s.name.Contains(clipName));
        if (clip != null)
        {
            AudioSource source = GetAvailableSource();

            if (clip.loop)
            {
                source.loop = true;
                source.clip = clip.clip;
                source.Play();
                source.volume = 0;
                StartCoroutine(FadeAudio(source, clip.fadeInTime, clip.volume));
                return;
            }
            source.PlayOneShot(clip.clip);
            source.volume = 0;
            StartCoroutine(FadeAudio(source, clip.fadeInTime, clip.volume));
        }
    }




    public void subscribe()
    {

    }

    public void unsubscribe()
    {

    }



    public IEnumerator FadeAudio(AudioSource audioSource, float fadeDuration, float endVolume)
    {

        float startVolume = audioSource.volume;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.unscaledDeltaTime;
            float percentage = elapsedTime / fadeDuration;

            //Debug.Log("the volume is "  + volume + " the fade duration " + fadeDuration);
            //float t = Mathf.SmoothStep(0f, 1f, elapsedTime / fadeDuration);
            float t = elapsedTime / fadeDuration;   // 0 → 1
            audioSource.volume = Mathf.Lerp(startVolume, endVolume, Mathf.Pow(t, 3.5f));

            //audioSource.volume = Mathf.Lerp(startVolume, endVolume, percentage);
            //audioSource.volume = volume;

            yield return null;
        }

        audioSource.volume = endVolume;

    }

    public void StopMusic(string clipName, float fadeDuration = 0f)
    {
        foreach (AudioSource source in audioSources)
        {
            if (source == null) continue;
            if (!source.loop) continue;
            if (source.clip == null) continue;
            if (source.clip.name != clipName) continue;

            if (fadeDuration > 0f)
                StartCoroutine(FadeOutAndStop(source, fadeDuration));
            else
                source.Stop();
        }
    }

    private IEnumerator FadeOutAndStop(AudioSource source, float duration)
    {
        yield return StartCoroutine(FadeAudio(source, duration, 0f));
        source.Stop();
    }
}
