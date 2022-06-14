using UnityEngine;
using UnityEngine.Audio;
using System;
using System.Collections;
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;
    
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Play();
    }

    public IEnumerator FadeOut(string name, float FadeTime)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        AudioSource audioSource = s.source;
        float startVolume = audioSource.volume;
 
        while (audioSource.volume > 0) {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
 
            yield return null;
        }
 
        audioSource.Stop();
        audioSource.volume = startVolume;
    }

    public IEnumerator FadeIn(string name, float FadeTime)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        AudioSource audioSource = s.source;
        audioSource.volume = 0;
        audioSource.Play();
        float targetVolume = 1;
        while (audioSource.volume < targetVolume) {
            audioSource.volume += targetVolume * Time.deltaTime / FadeTime;

            yield return null;
        }
 
        //audioSource.Stop();
        audioSource.volume = targetVolume;
    }
}
