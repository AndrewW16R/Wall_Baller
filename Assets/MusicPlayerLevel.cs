using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerLevel : MonoBehaviour
{
    public AudioClip mainMusicIntro;
    public AudioClip mainMusicLoop;

    public AudioClip lastChanceMusicIntro;
    public AudioClip lastChanceMusicLoop;

    public AudioClip resultsMusicIntro;
    public AudioClip resultsMusicLoop;

    public GameObject audioSourceObjectMainIntro;
    public AudioSource audioSourceMainIntro;

    public GameObject audioSourceObjectMainLoop;
    public AudioSource audioSourceMainLoop;

    public GameObject audioSourceObjectLastChanceIntro;
    public AudioSource audioSourceLastChanceIntro;

    public GameObject audioSourceObjectLastChanceLoop;
    public AudioSource audioSourceLastChanceLoop;

    public GameObject audioSourceObjectResultsIntro;
    public AudioSource audioSourceResultsIntro;

    public GameObject audioSourceObjectResultsLoop;
    public AudioSource audioSourceResultsLoop;

    // Start is called before the first frame update
    void Start()
    {
        GetAudioSources();
        GetMusicClips();
    }

    public void GetAudioSources()
    {
        audioSourceObjectMainIntro = GameObject.Find("AudioSourceMainIntro");
        audioSourceMainIntro = audioSourceObjectMainIntro.GetComponent<AudioSource>();

        audioSourceObjectMainLoop = GameObject.Find("AudioSourceMainLoop");
        audioSourceMainLoop = audioSourceObjectMainLoop.GetComponent<AudioSource>();

        audioSourceObjectLastChanceIntro = GameObject.Find("AudioSourceLastChanceIntro");
        audioSourceLastChanceIntro = audioSourceObjectLastChanceIntro.GetComponent<AudioSource>();

        audioSourceObjectLastChanceLoop = GameObject.Find("AudioSourceLastChanceLoop");
        audioSourceLastChanceLoop = audioSourceObjectLastChanceLoop.GetComponent<AudioSource>();

        audioSourceObjectResultsIntro = GameObject.Find("AudioSourceResultsIntro");
        audioSourceResultsIntro = audioSourceObjectResultsIntro.GetComponent<AudioSource>();

        audioSourceObjectResultsLoop = GameObject.Find("AudioSourceResultsLoop");
        audioSourceResultsLoop = audioSourceObjectResultsLoop.GetComponent<AudioSource>();
    }

    public void GetMusicClips()
    {
        audioSourceMainIntro.clip = mainMusicIntro;
        audioSourceMainLoop.clip = mainMusicLoop;

        audioSourceLastChanceIntro.clip = lastChanceMusicIntro;
        audioSourceLastChanceLoop.clip = lastChanceMusicLoop;

        audioSourceResultsIntro.clip = resultsMusicIntro;
        audioSourceResultsLoop.clip = resultsMusicLoop;
    }

    public void StopAllMusic()
    {
        audioSourceMainIntro.Stop();
        audioSourceMainLoop.Stop();

        audioSourceLastChanceIntro.Stop();
        audioSourceLastChanceLoop.Stop();

        audioSourceResultsIntro.Stop();
        audioSourceResultsLoop.Stop();
    }

    public void PlayMainMusic()
    {
        audioSourceMainIntro.Play();
        audioSourceMainLoop.PlayDelayed(audioSourceMainIntro.clip.length);
    }

    public void PlayLastChanceMusic()
    {
        audioSourceLastChanceIntro.Play();
        audioSourceLastChanceLoop.PlayDelayed(audioSourceLastChanceIntro.clip.length);
    }

    public void PlayResultsMusic()
    {
        audioSourceResultsIntro.Play();
        audioSourceResultsLoop.PlayDelayed(audioSourceResultsIntro.clip.length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
