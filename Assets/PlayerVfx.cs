using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVfx : MonoBehaviour
{

    public GameObject dashCancelVFX;
    public GameObject jumpCancelVFX;
    public float cancelVfxDuration;

    public ParticleSystem swingLgmVfx;
    public ParticleSystem swingLgdVfx;
    public ParticleSystem swingLguVfx;
    public ParticleSystem swingHgmVfx;
    public ParticleSystem swingHgdVfx;
    public ParticleSystem swingHguVfx;

    public ParticleSystem swingLamVfx;
    public ParticleSystem swingLadVfx;
    public ParticleSystem swingLauVfx;
    public ParticleSystem swingHamVfx;
    public ParticleSystem swingHadVfx;
    public ParticleSystem swingHauVfx;

    // Start is called before the first frame update
    void Start()
    {
        dashCancelVFX.SetActive(false);
        jumpCancelVFX.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivateDashCancelVFX()
    {
        StartCoroutine(PlayDashCancelVFX());
    }

    public void ActivateJumpCancelVFX()
    {
        StartCoroutine(PlayJumpCancelVFX());
    }

    public IEnumerator PlayDashCancelVFX()//Method that actively refills dashing meter
    {
        dashCancelVFX.SetActive(true);
        yield return new WaitForSeconds(cancelVfxDuration);
        dashCancelVFX.SetActive(false);
    }

    public IEnumerator PlayJumpCancelVFX()//Method that actively refills dashing meter
    {
        jumpCancelVFX.SetActive(true);
        yield return new WaitForSeconds(cancelVfxDuration);
        jumpCancelVFX.SetActive(false);
    }

    public void PlaySwingLgmVFX()
    {
        swingLgmVfx.Play();
    }

    public void PlaySwingLgdVFX()
    {
        swingLgdVfx.Play();
    }

    public void PlaySwingLguVFX()
    {
        swingLguVfx.Play();
    }

    public void PlaySwingHgmVFX()
    {
        swingHgmVfx.Play();
    }

    public void PlaySwingHgdVFX()
    {
        swingHgdVfx.Play();
    }

    public void PlaySwingHguVFX()
    {
        swingHguVfx.Play();
    }

    public void PlaySwingLamVFX()
    {
        swingLamVfx.Play();
    }

    public void PlaySwingLadVFX()
    {
        swingLadVfx.Play();
    }

    public void PlaySwingLauVFX()
    {
        swingLauVfx.Play();
    }

    public void PlaySwingHamVFX()
    {
        swingHamVfx.Play();
    }

    public void PlaySwingHadVFX()
    {
        swingHadVfx.Play();
    }

    public void PlaySwingHauVFX()
    {
        swingHauVfx.Play();
    }


}
