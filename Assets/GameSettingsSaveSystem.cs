using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettingsSaveSystem : MonoBehaviour
{
    public string screenShakeToggle; //String which will hold what the ScreenShake PlayerPref is set to. This string makes it easier to apply/transfer the screenShake setting into the Shake script
    public string hitboxDisplayToggle; //String which will hold what the HitboxVisible PlayerPref is set to. This string makes it easier to apply/transfer the screenShake setting into other scripts
    public string aimIndicatorToggle;
    public string rightWallAnimationToggle;

    public GameObject audioSourceObjectSfxOn;
    public AudioSource audioSourceSfxOn; //plays when setting a game setting to on
    public GameObject audioSourceObjectSfxOff;
    public AudioSource audioSourceSfxOff;  //Plays when setting a game setting to off

    // Start is called before the first frame update
    void Start()
    {
        audioSourceObjectSfxOn = GameObject.Find("AudioSource_SfxConfirm");
        audioSourceSfxOn = audioSourceObjectSfxOn.GetComponent<AudioSource>();

        audioSourceObjectSfxOff = GameObject.Find("AudioSource_SfxBack");
        audioSourceSfxOff = audioSourceObjectSfxOff.GetComponent<AudioSource>();

        InitializeGameSettings(); //when game is first opened (sets default settings)
        LoadScreenShakeToggle(); //sets the screenShakeToggle string to whatever the ScreenShake PlayerPref is.
        LoadHitboxDisplayToggle(); //sets the hitboxDisplay Toggle string to whatever the HitboxDisplay PlayerPref is.
        LoadAimIndicatorToggle(); //sets the aimIndicatorToggle string to whatever the ScreenShake PlayerPref is.
        LoadRightWallAnimationToggle(); //sets the rightWallAnimationToggle string to whatever the ScreenShake PlayerPref is.
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetScreenShakeToOn() //Sets the screenshake PlayerPref to "On"
    {
        PlayerPrefs.SetString("ScreenShake", "On");
        PlayerPrefs.Save();
    }

    public void SetScreenShakeToOff() //Sets the screenshake PlayerPref to "Off"
    {
        PlayerPrefs.SetString("ScreenShake", "Off");
        PlayerPrefs.Save();
    }

    public void ToggleScreenShake() //Makes the ScreenShake PlayerPref toggle between "On" or "Off", this method is called whenever the ScreenShake toggle button is pressed in the settings menu
    {
        if (PlayerPrefs.GetString("ScreenShake") == "On")
        {
            PlayerPrefs.SetString("ScreenShake", "Off");
            PlaySfxNegative();
        }
        else if (PlayerPrefs.GetString("ScreenShake") == "Off")
        {
            PlayerPrefs.SetString("ScreenShake", "On");
            PlaySfxPositive();
        }

        PlayerPrefs.Save();

        LoadScreenShakeToggle();

    }

    public void LoadScreenShakeToggle() //sets the screenShakeToggle string to whatever the ScreenShake PlayerPref is.
    {
        screenShakeToggle = PlayerPrefs.GetString("ScreenShake");
    }


    public void SetHitboxDisplayToOn() //Sets the HitboxDisplay PlayerPref to "On"
    {
        PlayerPrefs.SetString("HitboxDisplay", "On");
        PlayerPrefs.Save();
    }

    public void SetHitboxDisplayToOff() //Sets the HitboxDisplay PlayerPref to "Off"
    {
        PlayerPrefs.SetString("HitboxDisplay", "Off");
        PlayerPrefs.Save();
    }

    public void ToggleHitboxDisplay() //Makes the HitboxDisplay PlayerPref toggle between "On" or "Off", this method is called whenever the HitboxDisplay toggle button is pressed in the settings menu
    {
        if (PlayerPrefs.GetString("HitboxDisplay") == "On")
        {
            PlayerPrefs.SetString("HitboxDisplay", "Off");
            PlaySfxNegative();
        }
        else if (PlayerPrefs.GetString("HitboxDisplay") == "Off")
        {
            PlayerPrefs.SetString("HitboxDisplay", "On");
            PlaySfxPositive();
        }

        PlayerPrefs.Save();

        LoadHitboxDisplayToggle();
    }

    public void LoadHitboxDisplayToggle() //sets the hitboxDisplayToggle string to whatever the HitboxDisplay PlayerPref is.
    {
        hitboxDisplayToggle = PlayerPrefs.GetString("HitboxDisplay");
    }
    

    public void SetAimIndicatorToOn() //Sets the AimIndicator PlayerPref to "On"
    {
        PlayerPrefs.SetString("AimIndicator", "On");
        PlayerPrefs.Save();
    }

    public void SetAimIndicatorToOff() //Sets the AimIndicator PlayerPref to "Off"
    {
        PlayerPrefs.SetString("AimIndicator", "Off");
        PlayerPrefs.Save();
    }

    public void ToggleAimIndicator() //Makes the AimIndicator PlayerPref toggle between "On" or "Off", this method is called whenever the AimIndicator toggle button is pressed in the settings menu
    {
        if (PlayerPrefs.GetString("AimIndicator") == "On")
        {
            PlayerPrefs.SetString("AimIndicator", "Off");
            PlaySfxNegative();
        }
        else if (PlayerPrefs.GetString("AimIndicator") == "Off")
        {
            PlayerPrefs.SetString("AimIndicator", "On");
            PlaySfxPositive();
        }

        PlayerPrefs.Save();

        LoadAimIndicatorToggle();
    }

    public void LoadAimIndicatorToggle() //sets the aimIndicatorToggle string to whatever the AimIndicator PlayerPref is.
    {
        aimIndicatorToggle = PlayerPrefs.GetString("AimIndicator");
    }


    public void SetRightWallAnimationToOn() //Sets the RightWallAnimation PlayerPref to "On"
    {
        PlayerPrefs.SetString("RightWallAnimation", "On");
        PlayerPrefs.Save();
    }

    public void SetRightWallAnimationToOff() //Sets the RightWallAnimation PlayerPref to "Off"
    {
        PlayerPrefs.SetString("RightWallAnimation", "Off");
        PlayerPrefs.Save();
    }

    public void ToggleRightWallAnimation() //Makes the RightWallAnimation PlayerPref toggle between "On" or "Off", this method is called whenever the RightWallAnimation toggle button is pressed in the settings menu
    {
        if (PlayerPrefs.GetString("RightWallAnimation") == "On")
        {
            PlayerPrefs.SetString("RightWallAnimation", "Off");
            PlaySfxNegative();
        }
        else if (PlayerPrefs.GetString("RightWallAnimation") == "Off")
        {
            PlayerPrefs.SetString("RightWallAnimation", "On");
            PlaySfxPositive();
        }

        PlayerPrefs.Save();

        LoadRightWallAnimationToggle();
    }

    public void LoadRightWallAnimationToggle() //sets the rightWallAnimationToggle string to whatever the RightWallAnimation PlayerPref is.
    {
        rightWallAnimationToggle = PlayerPrefs.GetString("RightWallAnimation");
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

        if (PlayerPrefs.GetString("AimIndicator") == "")
        {
            PlayerPrefs.SetString("AimIndicator", "On");
            LoadAimIndicatorToggle();
        }

        if (PlayerPrefs.GetString("RightWallAnimation") == "")
        {
            PlayerPrefs.SetString("RightWallAnimation", "Off");
            LoadHitboxDisplayToggle();
        }
        PlayerPrefs.Save();
    }

    public void SetToDefaultSettings()
    {
        PlayerPrefs.SetString("ScreenShake", "On");
        LoadScreenShakeToggle();

        PlayerPrefs.SetString("HitboxDisplay", "Off");
        LoadHitboxDisplayToggle();

        PlayerPrefs.SetString("AimIndicator", "On");
        LoadAimIndicatorToggle();

        PlayerPrefs.SetString("RightWallAnimation", "Off");
        LoadRightWallAnimationToggle();

        PlayerPrefs.Save();

    }

    public void PlaySfxPositive()
    {
        audioSourceSfxOn.Play();
    }

    public void PlaySfxNegative()
    {
        audioSourceSfxOff.Play();
    }
}
