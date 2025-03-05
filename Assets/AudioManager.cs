using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

public class AudioManager : MonoBehaviour
{

    public AudioClip swingHitLight01;
    public AudioClip swingHitLight02;
    public AudioClip swingHitHeavy01;
    public AudioClip swingHitHeavy02;

    public AudioClip ballBounce01;
    public AudioClip ballBounce02;
    public AudioClip ballBounceHighSpeed01;
    public AudioClip ballBounceHighSpeed02;

    public AudioClip glassFirstHit;
    public AudioClip glassSecondHit;

    public AudioClip jumpGround;
    public AudioClip jumpAir;
    public AudioClip dash;

    public AudioClip ballLevelUp;

    public AudioClip bigHitStop;
    public AudioClip gameOver;

    public GameObject audioSourceObject01;
    public AudioSource audioSource01;

    public GameObject audioSourceObject02;
    public AudioSource audioSource02;

    public GameObject audioSourceObject03;
    public AudioSource audioSource03;

    public GameObject audioSourceObject04;
    public AudioSource audioSource04;

    public GameObject audioSourceObject05;
    public AudioSource audioSource05;

    public int soundRngResult;


    // Start is called before the first frame update
    void Start()
    {
        audioSourceObject01 = GameObject.Find("AudioSource01");
        audioSource01= audioSourceObject01.GetComponent<AudioSource>();

        audioSourceObject02 = GameObject.Find("AudioSource02");
        audioSource02 = audioSourceObject02.GetComponent<AudioSource>();

        audioSourceObject03 = GameObject.Find("AudioSource03");
        audioSource03 = audioSourceObject03.GetComponent<AudioSource>();

        audioSourceObject04 = GameObject.Find("AudioSource04");
        audioSource04 = audioSourceObject04.GetComponent<AudioSource>();

        audioSourceObject05 = GameObject.Find("AudioSource05");
        audioSource05 = audioSourceObject05.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SoundRngRoll()
    {
        soundRngResult = 0;
        soundRngResult = Random.Range(0, 10);
    }

    public void PlayLightSwingSFX()
    {
        SoundRngRoll();
        if (soundRngResult >= 0 && soundRngResult <= 4)
        {
            audioSource01.clip = swingHitLight01;
            //Debug.Log("Sound 1");
        }
        else if (soundRngResult >= 5 && soundRngResult <= 9)
        {
            audioSource01.clip = swingHitLight02;
            //Debug.Log("Sound 2");
        }

        audioSource01.Play();
    }


    public void PlayHeavySwingSFX()
    {
        SoundRngRoll();
        if (soundRngResult >= 0 && soundRngResult <= 4)
        {
            audioSource01.clip = swingHitHeavy01;
        }
        else if (soundRngResult >= 5 && soundRngResult <= 9)
        {
            audioSource01.clip = swingHitHeavy02;
        }

        audioSource01.Play();
    }

    public void PlayGlassFirstHitSFX()
    {
        audioSource04.clip = glassFirstHit;
        audioSource04.Play();
    }

    public void PlayGlassSecondHitSFX()
    {
        audioSource04.clip = glassSecondHit;
        audioSource04.Play();
    }

    public void PlayBallBounceSFX()
    {
        SoundRngRoll();
        if (soundRngResult >= 0 && soundRngResult <= 4)
        {
            audioSource03.clip = ballBounce01;
        }
        else if (soundRngResult >= 5 && soundRngResult <= 9)
        {
            audioSource03.clip = ballBounce02;
        }

        audioSource03.Play();
    }

    public void PlayBallBounceHighSpeedSFX()
    {
        SoundRngRoll();
        if (soundRngResult >= 0 && soundRngResult <= 4)
        {
            audioSource03.clip = ballBounceHighSpeed01;
        }
        else if (soundRngResult >= 5 && soundRngResult <= 9)
        {
            audioSource03.clip = ballBounceHighSpeed02;
        }

        audioSource03.Play();
    }

    public void PlayBallLevelUpSFX()
    {
        audioSource03.clip = ballLevelUp;
        audioSource03.Play();
    }

    public void PlayBigHitStopSFX()
    {
        audioSource05.clip = bigHitStop;
        audioSource05.Play();
    }

    public void PlayJumpGroundSFX()
    {
        audioSource02.clip = jumpGround;
        audioSource02.Play();
    }

    public void PlayJumpAirSFX()
    {
        audioSource02.clip = jumpAir;
        audioSource02.Play();
    }

    public void PlayDashSFX()
    {
        audioSource02.clip = dash;
        audioSource02.Play();
    }

    public void PlayGameOverSFX()
    {
        audioSource05.clip = gameOver;
        audioSource05.Play();
    }
}
