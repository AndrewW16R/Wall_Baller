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

    // Start is called before the first frame update
    void Start()
    {
        audioSourceObjectIntro = GameObject.Find("AudioSourceIntro");
        audioSourceIntro = audioSourceObjectIntro.GetComponent<AudioSource>();

        audioSourceObjectLoop = GameObject.Find("AudioSourceLoop");
        audioSourceLoop = audioSourceObjectLoop.GetComponent<AudioSource>();

        PlayMusic();
    }

    // Update is called once per frame
    void Update()
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
