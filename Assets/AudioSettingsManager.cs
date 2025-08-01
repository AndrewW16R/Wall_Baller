using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSettingsManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    public float masterVolume;
    public float musicVolume;
    public float effectsVolume;
    public float playedMusicVolume;
    public float playedEffectsVolume;

    public string hasVisitedAudioSettings;

    public GameObject masterVolumeBar0;
    public GameObject masterVolumeBar10;
    public GameObject masterVolumeBar20;
    public GameObject masterVolumeBar30;
    public GameObject masterVolumeBar40;
    public GameObject masterVolumeBar50;
    public GameObject masterVolumeBar60;
    public GameObject masterVolumeBar70;
    public GameObject masterVolumeBar80;
    public GameObject masterVolumeBar90;
    public GameObject masterVolumeBar100;

    public GameObject musicVolumeBar0;
    public GameObject musicVolumeBar10;
    public GameObject musicVolumeBar20;
    public GameObject musicVolumeBar30;
    public GameObject musicVolumeBar40;
    public GameObject musicVolumeBar50;
    public GameObject musicVolumeBar60;
    public GameObject musicVolumeBar70;
    public GameObject musicVolumeBar80;
    public GameObject musicVolumeBar90;
    public GameObject musicVolumeBar100;

    public GameObject effectsVolumeBar0;
    public GameObject effectsVolumeBar10;
    public GameObject effectsVolumeBar20;
    public GameObject effectsVolumeBar30;
    public GameObject effectsVolumeBar40;
    public GameObject effectsVolumeBar50;
    public GameObject effectsVolumeBar60;
    public GameObject effectsVolumeBar70;
    public GameObject effectsVolumeBar80;
    public GameObject effectsVolumeBar90;
    public GameObject effectsVolumeBar100;

    public GameObject universalAudioManagerObject;
    public UniversalAudioManager universalAudioManager;

    void Awake()
    {
        hasVisitedAudioSettings = PlayerPrefs.GetString("HasVisitedAudioSettings");
    }

    // Start is called before the first frame update
    void Start()
    {
        universalAudioManagerObject = GameObject.Find("UniversalAudioManager");
        universalAudioManager = universalAudioManagerObject.GetComponent<UniversalAudioManager>();

        //PlayerPrefs.SetString("HasVisitedAudioSettings", "");  // Used for testing if the initializing of the audio settings works as intended. indicates that player has not visited audio settings
        
        InitializeAudioSettings();
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

        masterVolume = PlayerPrefs.GetFloat("MasterVolume");
        musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        effectsVolume = PlayerPrefs.GetFloat("EffectsVolume");

        PlayerPrefs.Save();
    }

    public void IncreaseMasterVolume()
    {
        if (masterVolume < 1.0f)
        {
            masterVolume = masterVolume + 0.1f;
        }


        masterVolume = Mathf.Round(masterVolume * 10.0f) * 0.1f; // Rounds volume setting to the Tenths place

        PlayerPrefs.SetFloat("MasterVolume", masterVolume);

        PlayerPrefs.Save();

        UpdateMasterVolumeDisplayBar();
    }

    public void DecreaseMasterVolume()
    {
        if (masterVolume > 0.0f)
        {
            masterVolume = masterVolume - 0.1f;
        }

        masterVolume = Mathf.Round(masterVolume * 10.0f) * 0.1f; // Rounds volume setting to the Tenths place

        if (masterVolume <= 0.0)
        {
            masterVolume = 0.0001f; //Volume value must be set very low as opposed absolute zero in order to cooperate with the audio mixer
        }

        PlayerPrefs.SetFloat("MasterVolume", masterVolume);

        PlayerPrefs.Save();

        UpdateMasterVolumeDisplayBar();
    }

    public void IncreaseMusicVolume()
    {
        if (musicVolume < 1.0f)
        {
            musicVolume = musicVolume + 0.1f;
        }

        musicVolume = Mathf.Round(musicVolume * 10.0f) * 0.1f; // Rounds volume setting to the Tenths place

        PlayerPrefs.SetFloat("MusicVolume", musicVolume);

        PlayerPrefs.Save();

        UpdateMusicVolumeDisplayBar();
    }

    public void DecreaseMusicVolume()
    {
        if (musicVolume > 0.0f)
        {
            musicVolume = musicVolume - 0.1f;
        }

        musicVolume = Mathf.Round(musicVolume * 10.0f) * 0.1f; // Rounds volume setting to the Tenths place

        if (musicVolume <= 0.0)
        {
            musicVolume = 0.0001f; //Volume value must be set very low as opposed absolute zero in order to cooperate with the audio mixer
        }

        PlayerPrefs.SetFloat("MusicVolume", musicVolume);

        PlayerPrefs.Save();

        UpdateMusicVolumeDisplayBar();
    }

    public void IncreaseEffectsVolume()
    {
        if (effectsVolume < 1.0f)
        {
            effectsVolume = effectsVolume + 0.1f;
        }

        effectsVolume = Mathf.Round(effectsVolume * 10.0f) * 0.1f; // Rounds volume setting to the Tenths place

        PlayerPrefs.SetFloat("EffectsVolume", effectsVolume);

        PlayerPrefs.Save();

        UpdateEffectsVolumeDisplayBar();
    }

    public void DecreaseEffectsVolume()
    {
        if (effectsVolume > 0.0f)
        {
            effectsVolume = effectsVolume - 0.1f;
        }

        effectsVolume = Mathf.Round(effectsVolume * 10.0f) * 0.1f; // Rounds volume setting to the Tenths place

        if (effectsVolume <= 0.0)
        {
            effectsVolume = 0.0001f; //Volume value must be set very low as opposed absolute zero in order to cooperate with the audio mixer
        }

        PlayerPrefs.SetFloat("EffectsVolume", effectsVolume);


        PlayerPrefs.Save();

        UpdateEffectsVolumeDisplayBar();
    }

    public void UpdateMasterVolumeDisplayBar()
    {
        masterVolumeBar0.SetActive(false);
        masterVolumeBar10.SetActive(false);
        masterVolumeBar20.SetActive(false);
        masterVolumeBar30.SetActive(false);
        masterVolumeBar40.SetActive(false);
        masterVolumeBar50.SetActive(false);
        masterVolumeBar60.SetActive(false);
        masterVolumeBar70.SetActive(false);
        masterVolumeBar80.SetActive(false);
        masterVolumeBar90.SetActive(false);
        masterVolumeBar100.SetActive(false);

        if (masterVolume == 0.0f || masterVolume == 0.0001f)
        {
            masterVolumeBar0.SetActive(true);
        }
        else if (masterVolume == 0.1f)
        {
            masterVolumeBar10.SetActive(true);
        }
        else if (masterVolume == 0.2f)
        {
            masterVolumeBar20.SetActive(true);
        }
        else if (masterVolume == 0.3f)
        {
            masterVolumeBar30.SetActive(true);
        }
        else if (masterVolume == 0.4f)
        {
            masterVolumeBar40.SetActive(true);
        }
        else if (masterVolume == 0.5f)
        {
            masterVolumeBar50.SetActive(true);
        }
        else if (masterVolume == 0.6f)
        {
            masterVolumeBar60.SetActive(true);
        }
        else if (masterVolume == 0.7f)
        {
            masterVolumeBar70.SetActive(true);
        }
        else if (masterVolume == 0.8f)
        {
            masterVolumeBar80.SetActive(true);
        }
        else if (masterVolume >= 0.89f && masterVolume <= 0.91f)
        {
            masterVolumeBar90.SetActive(true);
        }
        else if (masterVolume == 1.0f)
        {
            masterVolumeBar100.SetActive(true);
        }

        GetPlayedVolumes();
    }

    public void UpdateMusicVolumeDisplayBar()
    {
        musicVolumeBar0.SetActive(false);
        musicVolumeBar10.SetActive(false);
        musicVolumeBar20.SetActive(false);
        musicVolumeBar30.SetActive(false);
        musicVolumeBar40.SetActive(false);
        musicVolumeBar50.SetActive(false);
        musicVolumeBar60.SetActive(false);
        musicVolumeBar70.SetActive(false);
        musicVolumeBar80.SetActive(false);
        musicVolumeBar90.SetActive(false);
        musicVolumeBar100.SetActive(false);

        if (musicVolume == 0.0f || musicVolume == 0.0001f)
        {
            musicVolumeBar0.SetActive(true);
        }
        else if (musicVolume == 0.1f)
        {
            musicVolumeBar10.SetActive(true);
        }
        else if (musicVolume == 0.2f)
        {
            musicVolumeBar20.SetActive(true);
        }
        else if (musicVolume == 0.3f)
        {
            musicVolumeBar30.SetActive(true);
        }
        else if (musicVolume == 0.4f)
        {
            musicVolumeBar40.SetActive(true);
        }
        else if (musicVolume == 0.5f)
        {
            musicVolumeBar50.SetActive(true);
        }
        else if (musicVolume == 0.6f)
        {
            musicVolumeBar60.SetActive(true);
        }
        else if (musicVolume == 0.7f)
        {
            musicVolumeBar70.SetActive(true);
        }
        else if (musicVolume == 0.8f)
        {
            musicVolumeBar80.SetActive(true);
        }
        else if (musicVolume >= 0.89f && musicVolume <= 0.91)
        {
            musicVolumeBar90.SetActive(true);
        }
        else if (musicVolume >= 1.0f)
        {
            musicVolumeBar100.SetActive(true);
        }

        GetPlayedVolumes();
    }

    public void UpdateEffectsVolumeDisplayBar()
    {
        effectsVolumeBar0.SetActive(false);
        effectsVolumeBar10.SetActive(false);
        effectsVolumeBar20.SetActive(false);
        effectsVolumeBar30.SetActive(false);
        effectsVolumeBar40.SetActive(false);
        effectsVolumeBar50.SetActive(false);
        effectsVolumeBar60.SetActive(false);
        effectsVolumeBar70.SetActive(false);
        effectsVolumeBar80.SetActive(false);
        effectsVolumeBar90.SetActive(false);
        effectsVolumeBar100.SetActive(false);

        if (effectsVolume == 0.0f || effectsVolume == 0.0001f)
        {
            effectsVolumeBar0.SetActive(true);
        }
        else if (effectsVolume == 0.1f)
        {
            effectsVolumeBar10.SetActive(true);
        }
        else if (effectsVolume == 0.2f)
        {
            effectsVolumeBar20.SetActive(true);
        }
        else if (effectsVolume == 0.3f)
        {
            effectsVolumeBar30.SetActive(true);
        }
        else if (effectsVolume == 0.4f)
        {
            effectsVolumeBar40.SetActive(true);
        }
        else if (effectsVolume == 0.5f)
        {
            effectsVolumeBar50.SetActive(true);
        }
        else if (effectsVolume == 0.6f)
        {
            effectsVolumeBar60.SetActive(true);
        }
        else if (effectsVolume == 0.7f)
        {
            effectsVolumeBar70.SetActive(true);
        }
        else if (effectsVolume == 0.8f)
        {
            effectsVolumeBar80.SetActive(true);
        }
        else if (effectsVolume >= 0.89f && effectsVolume <= 0.91f)
        {
            effectsVolumeBar90.SetActive(true);
        }
        else if (effectsVolume == 1.0f)
        {
            effectsVolumeBar100.SetActive(true);
        }

        GetPlayedVolumes();
    }

    public void InitializeAudioSettings() //Sets intial audio settings if they have not been set before
    {


        if(PlayerPrefs.GetString("HasVisitedAudioSettings") == "" && hasVisitedAudioSettings == "")
        {
            SetAudioSettingsToDefault();

            HasVisitedAudioSettingsFlag();
        }

        PlayerPrefs.Save();

        //GetPlayedVolumes();

    }

    public void SetAudioSettingsToDefault()
    {
        PlayerPrefs.SetFloat("MasterVolume", 0.7f);
        masterVolume = PlayerPrefs.GetFloat("MasterVolume");
        UpdateMasterVolumeDisplayBar();

        PlayerPrefs.SetFloat("MusicVolume", 0.7f);
        musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        UpdateMusicVolumeDisplayBar();

        PlayerPrefs.SetFloat("EffectsVolume", 0.7f);
        effectsVolume = PlayerPrefs.GetFloat("EffectsVolume");
        UpdateEffectsVolumeDisplayBar();

        PlayerPrefs.Save();

        //GetPlayedVolumes();
    }

    public void UpdateAllAudioDisplayBars()
    {
        UpdateMasterVolumeDisplayBar();
        UpdateMusicVolumeDisplayBar();
        UpdateEffectsVolumeDisplayBar();
    }

    public void HasVisitedAudioSettingsFlag() //Signals that the player has visited the audio settings page before. This information is needed to determine if the audio settings need to be initialized
    {
        PlayerPrefs.SetString("HasVisitedAudioSettings","True");
        hasVisitedAudioSettings = PlayerPrefs.GetString("HasVisitedAudioSettings");
    }
}
