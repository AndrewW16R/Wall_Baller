using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UniversalAudioManager : MonoBehaviour
{

    public AudioMixer audioMixer;

    const string mixerMaster = "MasterVolumeMixer"; //used to refer to the volume set within the master mixer
    const string mixerMusic = "MusicVolumeMixer"; //used to refer to the volume set within the music mixer
    const string mixerEffects = "EffectsVolumeMixer"; //used to refer to the volume set within the effects mixer

    public float masterVolumeValue; //will be set by volume playerprefs, will be applied to modify the master mixer's actual volume output
    public float musicVolumeValue; //will be set by volume playerprefs, will be applied to modify the music mixer's actual volume output
    public float effectsVolumeValue; //will be set by volume playerprefs, will be applied to modify the effects mixer's actual volume output

    public void SetMasterMixerAudio()
    {
        masterVolumeValue = PlayerPrefs.GetFloat("MasterVolume");
        audioMixer.SetFloat(mixerMaster, Mathf.Log10(masterVolumeValue) *20); //Formats volume value to work as intend with the auido mixer
    }

    public void SetMusicMixerAudio()
    {
        musicVolumeValue = PlayerPrefs.GetFloat("MusicVolume");
        audioMixer.SetFloat(mixerMusic, Mathf.Log10(musicVolumeValue) * 20); //Formats volume value to work as intend with the auido mixer
    }

    public void SetEffectsMixerAudio()
    {
        effectsVolumeValue = PlayerPrefs.GetFloat("EffectsVolume");
        audioMixer.SetFloat(mixerEffects, Mathf.Log10(effectsVolumeValue) * 20); //Formats volume value to work as intend with the auido mixer
    }

    public void SetAllMixerAudio()
    {
        SetMasterMixerAudio();
        SetMusicMixerAudio();
        SetEffectsMixerAudio();
    }

    // Start is called before the first frame update
    void Start()
    {
        //InitializeMixerAudio();
        SetAllMixerAudio();
    }

    public void InitializeMixerAudio()
    {
        if(PlayerPrefs.GetString("HasVisitedAudioSetting") == "")
        {
            PlayerPrefs.SetFloat("MasterVolume", 0.7f);
            PlayerPrefs.SetFloat("MusicVolume", 0.7f);
            PlayerPrefs.SetFloat("EffectsVolume", 0.7f);
        }

        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
