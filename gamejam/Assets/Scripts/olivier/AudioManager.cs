using UnityEngine;
using System.Collections.Generic;

using System.Linq;
using System.Collections;
using UnityEditor;
using System;

public class AudioManager : MonoBehaviour
{

    [Range(0f, 1f)] public float musicVolume = 0.2f;


    public static AudioManager instance;
    public AudioSource audioSourcePrefab;



    private List<AudioSource> audioSources = new List<AudioSource>();




    [SerializeField] public List<Sound> sounds = new List<Sound>();
    [SerializeField] public List<Sound> Cawksounds = new List<Sound>();

    [SerializeField] public List<Sound> flapsounds = new List<Sound>();

    [SerializeField] public List<Sound> Stepsounds = new List<Sound>();

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

        Sound clip = sounds.FirstOrDefault(s => s.name.Equals(clipName));

        if (clip != null)
        {

            AudioSource source = GetAvailableSource();
            if (clip.playOneShot)
            {
                source.PlayOneShot(clip.clip, clip.volume);
                return;
            }

            source.loop = clip.loop;
            source.clip = clip.clip;
            source.pitch = clip.pitch;
            source.Play();
            source.volume = 0;
            StartCoroutine(FadeAudio(source, clip.fadeInTime, clip.volume));
            return;

        }
    }

    public void PlaySound(Sound sound)
    {
        if (sound == null)
        {
            Debug.LogError("the sound is null");
            return;
        }

        AudioSource source = GetAvailableSource();
        if (sound.playOneShot)
        {
            source.PlayOneShot(sound.clip, sound.volume);
            return;
        }

        source.loop = sound.loop;
        source.clip = sound.clip;
        source.pitch = sound.pitch;
        source.Play();
        source.volume = 0;
        StartCoroutine(FadeAudio(source, sound.fadeInTime, sound.volume));
        return;
    }






    public void subscribe()
    {

    }

    public void unsubscribe()
    {

    }
    public void playRandomSound(List<Sound> sounds)
    {
        if (sounds == null || sounds.Count == 0) return;

        Sound clip = sounds[UnityEngine.Random.Range(0, sounds.Count)];

        PlaySound(clip);
    }

    public void PlaySound(Sound sound, Action fn)
    {
        if (sound == null)
        {
            Debug.LogError("the sound is null");
            return;
        }
        AudioSource source = GetAvailableSource();

        source.loop = sound.loop;
        source.clip = sound.clip;
        source.pitch = sound.pitch;

        double start = AudioSettings.dspTime;
        source.PlayScheduled(AudioSettings.dspTime);
        source.volume = 0;


        if (!Mathf.Approximately(sound.fadeInTime, 0))
        {
            StartCoroutine(FadeAudio(source, sound.fadeInTime, sound.volume));
        }
        else
            source.volume = sound.volume;


        double endTime = start + sound.clip.length;
        StartCoroutine(InvokeAtDspTime(endTime, fn));

        return;
    }
    IEnumerator InvokeAtDspTime(double time, Action fn)
    {
        while (AudioSettings.dspTime < time)
            yield return null;

        fn?.Invoke();
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


    public float GetSoundLength(string name)
    {
        // Find the sound in your sounds list
        Sound sound = sounds.FirstOrDefault(s => s.name == name);
        if (sound != null && sound.clip != null)
        {
            return sound.clip.length; // duration in seconds
        }

        return -1f; // not found
    }


}
