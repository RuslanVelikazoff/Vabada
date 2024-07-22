using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private const string PLAYER_PREFS_SOUND_VOLUME = "SoundVolume";
    private const string PLAYER_PREFS_MUSIC_VOLUME = "MusicVolume";

    public Sound[] sounds;

    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            if (s.name == "Theme")
            {
                s.source.volume = s.volume = PlayerPrefs.GetFloat(PLAYER_PREFS_MUSIC_VOLUME, 0f);
            }
            else
            {
                s.source.volume = s.volume = PlayerPrefs.GetFloat(PLAYER_PREFS_SOUND_VOLUME, 0f);
            }

            s.source.loop = s.loop;
        }
        
        Play("Theme");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
        }
        
        s.source.Play();
    }

    public void SetSoundVolume(float volume)
    {
        PlayerPrefs.SetFloat(PLAYER_PREFS_SOUND_VOLUME, volume);
        
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            if (s.name == "Theme")
            {
                continue;
            }
            else
            {
                s.source.volume = s.volume = PlayerPrefs.GetFloat(PLAYER_PREFS_SOUND_VOLUME);
            }

            s.source.loop = s.loop;
        }
    }

    public void SetMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat(PLAYER_PREFS_MUSIC_VOLUME, volume);
        
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            if (s.name == "Theme")
            {
                s.source.volume = s.volume = PlayerPrefs.GetFloat(PLAYER_PREFS_MUSIC_VOLUME);
            }

            s.source.loop = s.loop;
        }
    }

    public float GetSoundVolume()
    {
        return PlayerPrefs.GetFloat(PLAYER_PREFS_SOUND_VOLUME);
    }

    public float GetMusicVolume()
    {
        return PlayerPrefs.GetFloat(PLAYER_PREFS_MUSIC_VOLUME);
    }
}
