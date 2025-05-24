
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
    public AudioClip swingHitHeavyAirDown01;
    public AudioClip swingHitHeavyAirDown02;

    public AudioClip ballBounce01;
    public AudioClip ballBounce02;
    public AudioClip ballBounceHighSpeed01;
    public AudioClip ballBounceHighSpeed02;

    public AudioClip ceilingHit01;
    public AudioClip ceilingHit02;

    public AudioClip rightWallHit01;
    public AudioClip rightWallHit02;
    public AudioClip rightWallHit03;
    public AudioClip rightWallHit04;
    public AudioClip rightWallHit05;
    public AudioClip rightWallHit06;
    public AudioClip rightWallHit07;
    public AudioClip rightWallHit08;


    public AudioClip glassFirstHit;
    public AudioClip glassSecondHit;
    public AudioClip swingCancel;

    public AudioClip jumpGround;
    public AudioClip jumpAir;
    public AudioClip dash;

    public AudioClip ballLevelUp;

    public AudioClip dashReadyNotif;
    public AudioClip dashChargingNotif;

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

    public GameObject audioSourceObject06;
    public AudioSource audioSource06;

    public GameObject audioSourceObject07;
    public AudioSource audioSource07;

    public GameObject audioSourceObject08;
    public AudioSource audioSource08;

    public GameObject audioSourceObject09;
    public AudioSource audioSource09;

    public int soundRngResult;
    public int soundRngResultEight;


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

        audioSourceObject06 = GameObject.Find("AudioSource06");
        audioSource06 = audioSourceObject06.GetComponent<AudioSource>();

        audioSourceObject07 = GameObject.Find("AudioSource07");
        audioSource07 = audioSourceObject07.GetComponent<AudioSource>();

        audioSourceObject08 = GameObject.Find("AudioSource08");
        audioSource08 = audioSourceObject08.GetComponent<AudioSource>();

        audioSourceObject09 = GameObject.Find("AudioSource09");
        audioSource09 = audioSourceObject09.GetComponent<AudioSource>();
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

    public void SoundRngRollEight()
    {
        soundRngResultEight = 0;
        soundRngResultEight = Random.Range(0, 8);
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

    public void PlayHeavyAirDownSwingSFX()
    {
        SoundRngRoll();
        if (soundRngResult >= 0 && soundRngResult <= 4)
        {
            audioSource01.clip = swingHitHeavyAirDown01;
        }
        else if (soundRngResult >= 5 && soundRngResult <= 9)
        {
            audioSource01.clip = swingHitHeavyAirDown02;
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
        audioSource06.clip = ballLevelUp;
        audioSource06.Play();
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

    public void PlaySwingCancelSFX()
    {
        audioSource04.clip = swingCancel;
        audioSource04.Play();
    }

    public void PlayGameOverSFX()
    {
        audioSource05.clip = gameOver;
        audioSource05.Play();
    }

    public void PlayCeilingHitSFX()
    {
        SoundRngRoll();
        if (soundRngResult >= 0 && soundRngResult <= 4)
        {
            audioSource01.clip = ceilingHit01;
            //Debug.Log("Sound 1");
        }
        else if (soundRngResult >= 5 && soundRngResult <= 9)
        {
            audioSource01.clip = ceilingHit02;
            //Debug.Log("Sound 2");
        }

        audioSource01.Play();
    }

    public void PlayRightWallHitSFX()
    {
        SoundRngRollEight();
        if (soundRngResultEight == 0)
        {
            audioSource08.clip = rightWallHit01;
            //Debug.Log("Sound 1");
        }
        else if (soundRngResultEight == 1)
        {
            audioSource08.clip = rightWallHit02;
            //Debug.Log("Sound 2");
        }
        else if (soundRngResultEight == 2)
        {
            audioSource08.clip = rightWallHit03;
            //Debug.Log("Sound 3");
        }
        else if (soundRngResultEight == 3)
        {
            audioSource08.clip = rightWallHit04;
            //Debug.Log("Sound 4");
        }
        else if (soundRngResultEight == 4)
        {
            audioSource08.clip = rightWallHit05;
            //Debug.Log("Sound 5");
        }
        else if (soundRngResultEight == 5)
        {
            audioSource08.clip = rightWallHit06;
            //Debug.Log("Sound 6");
        }
        else if (soundRngResultEight == 6)
        {
            audioSource08.clip = rightWallHit07;
            //Debug.Log("Sound 7");
        }
        else if (soundRngResultEight == 7)
        {
            audioSource08.clip = rightWallHit08;
            //Debug.Log("Sound 8");
        }
        else
        {
            audioSource08.clip = rightWallHit01;
        }


        audioSource08.Play();
    }

    public void PlayDashReadySFX()
    {
        audioSource09.clip = dashReadyNotif;
        audioSource09.Play();
    }

    public void PlayDashChargingSFX()
    {
        audioSource09.clip = dashChargingNotif;
        audioSource09.Play();
    }
}
