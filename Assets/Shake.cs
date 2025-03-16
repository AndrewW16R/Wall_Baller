using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public float duration01 = 1f;
    public float duration02 = 1f;
    public AnimationCurve curve01; //sets intensity of shake over time
    public AnimationCurve curve02;

    public string shakeToggle;

    public GameObject playerPrefManagerObject;
    public GameSettingsSaveSystem gameSettingsSaveSystem;

    // Start is called before the first frame update
    void Start()
    {
        playerPrefManagerObject = GameObject.Find("PlayerPrefManager");
        gameSettingsSaveSystem = playerPrefManagerObject.GetComponent<GameSettingsSaveSystem>();
        GetScreenShakeToggle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateShake01()
    {
        if(shakeToggle == "On")
        {
            StartCoroutine(Shaking01());
        }
    }

    public void ActivateShake02()
    {
        if (shakeToggle == "On")
        {
            StartCoroutine(Shaking02());
        }
    }

    IEnumerator Shaking01()
    {
        Vector3 startPosition = transform.position; //saves starting position
        float elapsedTime = 0f; //sets elapsed time to zero

        while (elapsedTime < duration01)
        {
            //Debug.Log(elapsedTime);
            elapsedTime += Time.deltaTime;

            float strength = curve01.Evaluate(elapsedTime / duration01);
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.position = startPosition;
    }

    IEnumerator Shaking02()
    {
        Vector3 startPosition = transform.position; //saves starting position
        float elapsedTime = 0f; //sets elapsed time to zero

        while (elapsedTime < duration02)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve02.Evaluate(elapsedTime / duration02);
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.position = startPosition;
    }

    public void GetScreenShakeToggle()
    {
        shakeToggle = gameSettingsSaveSystem.screenShakeToggle;
    }
}
