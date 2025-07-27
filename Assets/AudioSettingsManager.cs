using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettingsManager : MonoBehaviour
{
    public float masterVolume;
    public float musicVolume;
    public float effectsVolume;
    public float playedMusicVolume;
    public float playedEffectsVolume;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetPlayedVolumes()
    {
        if (musicVolume > masterVolume)
        {
            playedMusicVolume = masterVolume;
        }
        else
        {
            playedMusicVolume = musicVolume;
        }

        if (effectsVolume > masterVolume)
        {
            playedEffectsVolume = masterVolume;
        }
        else
        {
            playedEffectsVolume = musicVolume;
        }

        PlayerPrefs.SetFloat("PlayedMusicVolume", playedMusicVolume);
        PlayerPrefs.SetFloat("PlayedEffectsVolume", playedEffectsVolume);
    }

    public void IncreaseMasterVolume()
    {
        if (masterVolume < 1.0f)
        {
            masterVolume = masterVolume + 0.1f;
        }

        PlayerPrefs.SetFloat("MasterVolume", masterVolume);
    }

    public void DecreaseMasterVolume()
    {
        if (masterVolume > 0.0f)
        {
            masterVolume = masterVolume - 0.1f;
        }

        PlayerPrefs.SetFloat("MasterVolume", masterVolume);
    }

    public void IncreaseMusicVolume()
    {
        if (musicVolume < 1.0f)
        {
            musicVolume = musicVolume + 0.1f;
        }

        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
    }

    public void DecreaseMusicVolume()
    {
        if (musicVolume > 0.0f)
        {
            musicVolume = musicVolume - 0.1f;
        }

        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
    }

    public void IncreaseEffectsVolume()
    {
        if (effectsVolume < 1.0f)
        {
            effectsVolume = effectsVolume + 0.1f;
        }

        PlayerPrefs.SetFloat("EffectsVolume", effectsVolume);
    }

    public void DecreaseEffectsVolume()
    {
        if (effectsVolume > 0.0f)
        {
            effectsVolume = effectsVolume - 0.1f;
        }

        PlayerPrefs.SetFloat("EffectsVolume", effectsVolume);
    }
}
