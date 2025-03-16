using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettingsSaveSystem : MonoBehaviour
{
    public string screenShakeToggle;


    // Start is called before the first frame update
    void Start()
    {
        InitializeGameSettings();
        LoadScreenShakeToggle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetScreenShakeToOn()
    {
        PlayerPrefs.SetString("ScreenShake", "On");
    }

    public void SetScreenShakeToOff()
    {
        PlayerPrefs.SetString("ScreenShake", "Off");
    }

    public void ToggleScreenShake()
    {
        if (PlayerPrefs.GetString("ScreenShake") == "On")
        {
            PlayerPrefs.SetString("ScreenShake", "Off");
        }
        else if (PlayerPrefs.GetString("ScreenShake") == "Off")
        {
            PlayerPrefs.SetString("ScreenShake", "On");
        }
        LoadScreenShakeToggle();
    }

    public void LoadScreenShakeToggle()
    {
        screenShakeToggle = PlayerPrefs.GetString("ScreenShake");
    }

    public void SetHitboxDisplayToOn()
    {
        PlayerPrefs.SetString("HitboxDisplay", "On");
    }

    public void SetHitboxDisplayToOff()
    {
        PlayerPrefs.SetString("HitboxDisplay", "Off");
    }

    public void InitializeGameSettings() //when game is first opened (sets default settings)
    {
        if(PlayerPrefs.GetString("ScreenShake") == "")
        {
            PlayerPrefs.SetString("ScreenShake", "On");
            LoadScreenShakeToggle();
        }

        if(PlayerPrefs.GetString("HitboxDisplay") == "")
        {
            PlayerPrefs.SetString("HitboxDisplay", "Off");
        }
    }
}
