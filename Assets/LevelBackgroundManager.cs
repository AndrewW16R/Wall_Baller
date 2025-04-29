using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBackgroundManager : MonoBehaviour
{

    public GameObject backgroundLv0StaleObject;
    public GameObject backgroundLv1StaleObject;
    public GameObject backgroundLv2StaleObject;
    public GameObject backgroundLv3StaleObject;
    public GameObject backgroundLv4StaleObject;

    public string currentBg;


    // Start is called before the first frame update
    void Start()
    {
        backgroundLv0StaleObject = GameObject.Find("LevelBackground_Fresh");
        backgroundLv1StaleObject = GameObject.Find("LevelBackground_Cool");
        backgroundLv2StaleObject = GameObject.Find("LevelBackground_Ok");
        backgroundLv3StaleObject = GameObject.Find("LevelBackground_Meh");
        backgroundLv4StaleObject = GameObject.Find("LevelBackground_Wack");

        currentBg = "Fresh";
        BackgroundUpdate(currentBg);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackgroundUpdate(string backgroundCalled)
    {
        if (currentBg == backgroundCalled)
        {
            return;
        }
        
        if(backgroundCalled == "Fresh")
        {
            SetBackgroundFresh();
            currentBg = "Fresh";
        }
        else if (backgroundCalled == "Cool")
        {
            SetBackgroundCool();
            currentBg = "Cool";
        }
        else if (backgroundCalled == "Ok")
        {
            SetBackgroundOk();
            currentBg = "Ok";
        }
        else if (backgroundCalled == "Meh")
        {
            SetBackgroundMeh();
            currentBg = "Meh";
        }
        else if (backgroundCalled == "Wack")
        {
            SetBackgroundWack();
            currentBg = "Wack";
        }
    }

    public void SetBackgroundFresh()
    {
        backgroundLv0StaleObject.SetActive(true);
        backgroundLv1StaleObject.SetActive(false);
        backgroundLv2StaleObject.SetActive(false);
        backgroundLv3StaleObject.SetActive(false);
        backgroundLv4StaleObject.SetActive(false);
    }

    public void SetBackgroundCool()
    {
        backgroundLv0StaleObject.SetActive(false);
        backgroundLv1StaleObject.SetActive(true);
        backgroundLv2StaleObject.SetActive(false);
        backgroundLv3StaleObject.SetActive(false);
        backgroundLv4StaleObject.SetActive(false);
    }

    public void SetBackgroundOk()
    {
        backgroundLv0StaleObject.SetActive(false);
        backgroundLv1StaleObject.SetActive(false);
        backgroundLv2StaleObject.SetActive(true);
        backgroundLv3StaleObject.SetActive(false);
        backgroundLv4StaleObject.SetActive(false);
    }

    public void SetBackgroundMeh()
    {
        backgroundLv0StaleObject.SetActive(false);
        backgroundLv1StaleObject.SetActive(false);
        backgroundLv2StaleObject.SetActive(false);
        backgroundLv3StaleObject.SetActive(true);
        backgroundLv4StaleObject.SetActive(false);
    }

    public void SetBackgroundWack()
    {
        backgroundLv0StaleObject.SetActive(false);
        backgroundLv1StaleObject.SetActive(false);
        backgroundLv2StaleObject.SetActive(false);
        backgroundLv3StaleObject.SetActive(false);
        backgroundLv4StaleObject.SetActive(true);
    }
}
