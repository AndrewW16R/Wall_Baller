using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettingsSaveSystem : MonoBehaviour
{
    public string screenShakeToggle; //String which will hold what the ScreenShake PlayerPref is set to. This string makes it easier to apply/transfer the screenShake setting into the Shake script
    public string hitboxDisplayToggle; //String which will hold what the HitboxVisible PlayerPref is set to. This string makes it easier to apply/transfer the screenShake setting into other scripts


    // Start is called before the first frame update
    void Start()
    {
        InitializeGameSettings(); //when game is first opened (sets default settings)
        LoadScreenShakeToggle(); //sets the screenShakeToggle string to whatever the ScreenShake PlayerPref is.
        LoadHitboxDisplayToggle(); //sets the hitboxDisplay Toggle string to whatever the HitboxDisplay PlayerPref is.
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetScreenShakeToOn() //Sets the screenshake PlayerPref to "On"
    {
        PlayerPrefs.SetString("ScreenShake", "On"); 
    }

    public void SetScreenShakeToOff() //Sets the screenshake PlayerPref to "Off"
    {
        PlayerPrefs.SetString("ScreenShake", "Off");
    }

    public void ToggleScreenShake() //Makes the ScreenShake PlayerPref toggle between "On" or "Off", this method is called whenever the ScreenShake toggle button is pressed in the settings menu
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

    public void LoadScreenShakeToggle() //sets the screenShakeToggle string to whatever the ScreenShake PlayerPref is.
    {
        screenShakeToggle = PlayerPrefs.GetString("ScreenShake");
    }

    public void SetHitboxDisplayToOn() //Sets the HitboxDisplay PlayerPref to "On"
    {
        PlayerPrefs.SetString("HitboxDisplay", "On");
    }

    public void SetHitboxDisplayToOff() //Sets the HitboxDisplay PlayerPref to "Off"
    {
        PlayerPrefs.SetString("HitboxDisplay", "Off");
    }

    public void ToggleHitboxDisplay() //Makes the HitboxDisplay PlayerPref toggle between "On" or "Off", this method is called whenever the HitboxDisplay toggle button is pressed in the settings menu
    {
        if (PlayerPrefs.GetString("HitboxDisplay") == "On")
        {
            PlayerPrefs.SetString("HitboxDisplay", "Off");
        }
        else if (PlayerPrefs.GetString("HitboxDisplay") == "Off")
        {
            PlayerPrefs.SetString("HitboxDisplay", "On");
        }
        LoadHitboxDisplayToggle();
    }

    public void LoadHitboxDisplayToggle() //sets the hitboxDisplayToggle string to whatever the HitboxDisplay PlayerPref is.
    {
        hitboxDisplayToggle = PlayerPrefs.GetString("HitboxDisplay");
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
            LoadHitboxDisplayToggle();
        }
    }

    public void SetToDefaultSettings()
    {
        PlayerPrefs.SetString("ScreenShake", "On");
        LoadScreenShakeToggle();

        PlayerPrefs.SetString("HitboxDisplay", "Off");
        LoadHitboxDisplayToggle();
    }
}
