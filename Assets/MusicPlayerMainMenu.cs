using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerMainMenu : MonoBehaviour
{
    public AudioClip menuMusicIntro;
    public AudioClip menuMusicLoop;

    public GameObject audioSourceObjectIntro;
    public AudioSource audioSourceIntro;
    public GameObject audioSourceObjectLoop;
    public AudioSource audioSourceLoop;

    public GameObject audioSettingsManagerObject;
    public AudioSettingsManager audioSettingsManager;

    public float masterVolumeValue;
    public float musicVolumeValue;
    public float playedMenuMusicVolume;

    // Start is called before the first frame update
    void Start()
    {
        audioSourceObjectIntro = GameObject.Find("AudioSourceIntro");
        audioSourceIntro = audioSourceObjectIntro.GetComponent<AudioSource>();

        audioSourceObjectLoop = GameObject.Find("AudioSourceLoop");
        audioSourceLoop = audioSourceObjectLoop.GetComponent<AudioSource>();

        audioSettingsManagerObject = GameObject.Find("AudioSourceIntro");
        audioSourceIntro = audioSourceObjectIntro.GetComponent<AudioSource>();

        PlayMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateMusicVolume() //updates the volume at which the menu music is played at.
    {
        audioSettingsManager.GetPlayedVolumes();

        playedMenuMusicVolume = audioSettingsManager.playedMusicVolume;

        audioSourceIntro.volume = playedMenuMusicVolume;
    }

    public void ApplyMusicVolume()
    {

    }

    public void PlayMusic()
    {
        audioSourceIntro.clip = menuMusicIntro;
        audioSourceLoop.clip = menuMusicLoop;

        audioSourceIntro.Play();
        audioSourceLoop.PlayDelayed(audioSourceIntro.clip.length);
    }
}
