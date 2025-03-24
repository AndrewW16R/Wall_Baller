using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVfx : MonoBehaviour
{

    public GameObject dashCancelVFX;
    public GameObject jumpCancelVFX;
    public float cancelVfxDuration;

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
}
