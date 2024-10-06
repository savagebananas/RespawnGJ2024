using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;  // Singleton instance
    public AudioSource musicSource;       // Dedicated AudioSource for music
    public AudioSource sfxSource;         // Dedicated AudioSource for sound effects
    public AudioClip[] musicClips;        // Array of music clips
    public AudioClip[] soundEffects;      // Array of sound effects
    void Awake()
    {
        // Implement the singleton pattern
        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);  // Keep the AudioManager persistent across scenes
    }
    public void PlayMusic(int index)
    {
        musicSource.clip = musicClips[index];
        musicSource.Play();
    }
    public void PlaySoundEffect(int index)
    {
        sfxSource.PlayOneShot(soundEffects[index]);
    }
    public void StopMusic()
    {
        musicSource.Stop();
    }
    public void SetMusicVolume(float volume)
    {
        AudioManager.instance.musicSource.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        AudioManager.instance.sfxSource.volume = volume;
    }
}
