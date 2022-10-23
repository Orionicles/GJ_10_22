using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public AudioSource effectSource, musicSrc;

    void Awake()
    {
        //foreach (Sound s in sounds)
        //{
        //    s.source.clip = s.clip;

        //    s.source.volume = s.volume;
        //    s.source.pitch = s.pitch;
        //    s.source.loop = s.loop;
        //    s.source.spatialBlend = s.SpatialBlend;
        //    s.source.maxDistance = s.MaxDistance;
        //    s.source.rolloffMode = AudioRolloffMode.Custom;
        //}
    }

    //Plays a sound effect using the name of the sound -- Only use for Music
    //Example: FindObjectOfType<Audio Manager>().Play(�SoundNmae�);
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        musicSrc.clip = s.clip;
        musicSrc.Play();
        //s.source.Play();
    }

    public void PlayRandom(string[] randomSounds)
    {
        int soundIndex = UnityEngine.Random.Range(0, randomSounds.Length - 1);
        Sound s = Array.Find(sounds, sound => sound.name == randomSounds[soundIndex]);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    /// <summary>
    /// Use for sound fxs
    /// </summary>
    /// <param name="name"></param>
    public void PlayOneShot(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        AudioClip clip = s.clip;
        effectSource.clip = s.clip;
        effectSource.PlayOneShot(clip);

        //s.source.PlayOneShot(clip);
    }

    public void RandomPlayOneShot(string[] randomSounds)
    {
        int soundIndex = UnityEngine.Random.Range(0, randomSounds.Length - 1);
        Sound s = Array.Find(sounds, sound => sound.name == randomSounds[soundIndex]);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        AudioClip clip = s.clip;
        s.source.PlayOneShot(clip);
    }

    //Stops playing a sound effect using the name of the sound
    //Example: FindObjectOfType<Audio Manager>().Stop(�SoundName�);
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }

    //Sets the volume of a sound effect
    //Example: FindObjectOfType<Audio Manager>().setVolume(�SoundName�, 1);
    public void setVolume(string name, float volume)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.volume = volume;
    }

    //Checks to see if a sound with a specific name is currently playing
    //Example: FindObjectOfType<Audio Manager>().isPlaying(�SoundName�);
    public bool isPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
        }
        return s.source.isPlaying;
    }
}