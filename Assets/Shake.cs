using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public float duration01 = 1f; //By modifying this field in the inspector, the duration for the light shake can be changed
    public float duration02 = 1f; //By modifying this field in the inspector, the duration for the Heavy shake can be changed
    public AnimationCurve curve01; //sets intensity of shake over time
    public AnimationCurve curve02; //sets intensity of shake over time

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

    public void ActivateShake01() //Light ScreenShake is activated 
    {
        if(shakeToggle == "On") //ScreenShake will only activate if ScreenShakeToggle is turned on
        {
            StartCoroutine(Shaking01());
        }
    }

    public void ActivateShake02() //Heavy ScreenShake is activated
    {
        if (shakeToggle == "On") //ScreenShake will only activate if ScreenShakeToggle is turned on
        {
            StartCoroutine(Shaking02());
        }
    }

    IEnumerator Shaking01() //Light ScreenShake takes place
    {
        Vector3 startPosition = transform.position; //saves starting position
        float elapsedTime = 0f; //sets elapsed time to zero

        while (elapsedTime < duration01) //Shake occurs while the elapsed time is less than the set duration for the light screenshake
        {
            //Debug.Log(elapsedTime);
            elapsedTime += Time.deltaTime;

            float strength = curve01.Evaluate(elapsedTime / duration01);
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.position = startPosition;
    }

    IEnumerator Shaking02() //Heavy ScreenShake takes place
    {
        Vector3 startPosition = transform.position; //saves starting position
        float elapsedTime = 0f; //sets elapsed time to zero

        while (elapsedTime < duration02) //Shake occurs while the elapsed time is less than the set duration for the heavy screenshake
        {
            elapsedTime += Time.deltaTime;
            float strength = curve02.Evaluate(elapsedTime / duration02);
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.position = startPosition; //Sets Camera back to starting position from before the ScreenShake once the ScreenShake is over
    }

    public void GetScreenShakeToggle() //Gets screensShake Toggle setting from the GameSettingsSaveSystemScreen
    {
        shakeToggle = gameSettingsSaveSystem.screenShakeToggle;
    }
}
