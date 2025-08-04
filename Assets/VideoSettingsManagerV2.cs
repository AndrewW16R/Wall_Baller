using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VideoSettingsManagerV2 : MonoBehaviour
{
   // public TMP_Dropdown resDropDown;
   // public Toggle fullScreenToggle;

    public string screenRes;
    public int selectedWidth;
    public int selectedHeight;

    public bool isFullScreen;


    public GameObject audioSourceObjectSfxOn;
    public AudioSource audioSourceSfxOn; //plays when setting a game setting to on
    public GameObject audioSourceObjectSfxOff;
    public AudioSource audioSourceSfxOff;  //Plays when setting a game setting to off

    /*Resolution[] AllResolutions;
    int selectedResolution;
    List<Resolution> SelectedResolutionList = new List<Resolution>();*/

    // Start is called before the first frame update
    void Start()
    {
        InitializeVideoSettings();

        audioSourceObjectSfxOn = GameObject.Find("AudioSource_SfxConfirm");
        audioSourceSfxOn = audioSourceObjectSfxOn.GetComponent<AudioSource>();

        audioSourceObjectSfxOff = GameObject.Find("AudioSource_SfxBack");
        audioSourceSfxOff = audioSourceObjectSfxOff.GetComponent<AudioSource>();

        //isFullScreen = true;
        /*  AllResolutions = Screen.resolutions;

          List<string> resolutionStringList = new List<string>();
          string newRes;
          foreach (Resolution res in AllResolutions)
          {
              newRes = res.width.ToString() + " x " + res.height.ToString();
              if(!resolutionStringList.Contains(newRes))
              {
                  resolutionStringList.Add(newRes);
                  SelectedResolutionList.Add(res);
              }

          }

          resDropDown.AddOptions(resolutionStringList); */
    }

    

   /* public void ChangeResolution()
    {
        selectedResolution = resDropDown.value;
        Screen.SetResolution(SelectedResolutionList[selectedResolution].width, SelectedResolutionList[selectedResolution].height, isFullScreen);
    }*/

    /*public void ChangeFullScreen()
    {
        isFullScreen = fullScreenToggle.isOn;
        Screen.SetResolution(selectedWidth, selectedHeight, isFullScreen);
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScreenDisplay()
    {
        Screen.SetResolution(selectedWidth, selectedHeight, isFullScreen);
    }


    public void ToggleFullScreen()
    {
        if(isFullScreen == true)
        {
            SetFullScreenOff();
        }
        else
        {
            SetFullScreenOn();
        }
    }


    public void SetFullScreenOn()
    {
        isFullScreen = true;
        PlayerPrefs.SetString("FullScreen", "On");
        PlaySfxPositive();
        UpdateScreenDisplay();
    }

    public void SetFullScreenOff()
    {
        isFullScreen = false;
        PlayerPrefs.SetString("FullScreen", "Off");
        PlaySfxNegative();
        UpdateScreenDisplay();
    }

    //16:9 Resolutions

    public void SetResolution640x360()
    {
        Screen.SetResolution(640, 360, isFullScreen);
        selectedWidth = 640;
        selectedHeight = 360;
        PlayerPrefs.SetInt("SelectedResWidth", selectedWidth);
        PlayerPrefs.SetInt("SelectedResHeight", selectedHeight);
        screenRes = ("640x360");
        PlayerPrefs.SetString("SelectedScreenRes", screenRes);
    }

    public void SetResolution1280x720()
    {
        Screen.SetResolution(1280, 720, isFullScreen);
        selectedWidth = 1280;
        selectedHeight = 720;
        PlayerPrefs.SetInt("SelectedResWidth", selectedWidth);
        PlayerPrefs.SetInt("SelectedResHeight", selectedHeight);
        screenRes = ("1280x720");
        PlayerPrefs.SetString("SelectedScreenRes", screenRes);
    }

    public void SetResolution1366x768()
    {
        Screen.SetResolution(1366, 768, isFullScreen);
        selectedWidth = 1366;
        selectedHeight = 768;
        PlayerPrefs.SetInt("SelectedResWidth", selectedWidth);
        PlayerPrefs.SetInt("SelectedResHeight", selectedHeight);
        screenRes = ("1366x768");
        PlayerPrefs.SetString("SelectedScreenRes", screenRes);
    }

    public void SetResolution1600x900()
    {
        Screen.SetResolution(1600, 900, isFullScreen);
        selectedWidth = 1600;
        selectedHeight = 900;
        PlayerPrefs.SetInt("SelectedResWidth", selectedWidth);
        PlayerPrefs.SetInt("SelectedResHeight", selectedHeight);
        screenRes = ("1600x900");
        PlayerPrefs.SetString("SelectedScreenRes", screenRes);
    }

    public void SetResolution1920x1080()
    {
        Screen.SetResolution(1920, 1080, isFullScreen);
        selectedWidth = 1920;
        selectedHeight = 1080;
        PlayerPrefs.SetInt("SelectedResWidth", selectedWidth);
        PlayerPrefs.SetInt("SelectedResHeight", selectedHeight);
        screenRes = ("1920x1080");
        PlayerPrefs.SetString("SelectedScreenRes", screenRes);
    }

    public void SetResolution2560x1440()
    {
        Screen.SetResolution(2560, 1440, isFullScreen);
        selectedWidth = 2560;
        selectedHeight = 1440;
        PlayerPrefs.SetInt("SelectedResWidth", selectedWidth);
        PlayerPrefs.SetInt("SelectedResHeight", selectedHeight);
        screenRes = ("2560x1440");
        PlayerPrefs.SetString("SelectedScreenRes", screenRes);
    }

    //4:3 Resolutions

    public void SetResolution320x240()
    {
        Screen.SetResolution(320, 240, isFullScreen);
        selectedWidth = 320;
        selectedHeight = 240;
        PlayerPrefs.SetInt("SelectedResWidth", selectedWidth);
        PlayerPrefs.SetInt("SelectedResHeight", selectedHeight);
        screenRes = ("320x240");
        PlayerPrefs.SetString("SelectedScreenRes", screenRes);
    }

    public void SetResolution640x480()
    {
        Screen.SetResolution(640, 480, isFullScreen);
        selectedWidth = 640;
        selectedHeight = 480;
        PlayerPrefs.SetInt("SelectedResWidth", selectedWidth);
        PlayerPrefs.SetInt("SelectedResHeight", selectedHeight);
        screenRes = ("640x480");
        PlayerPrefs.SetString("SelectedScreenRes", screenRes);
    }

    public void SetResolution800x600()
    {
        Screen.SetResolution(800, 600, isFullScreen);
        selectedWidth = 800;
        selectedHeight = 600;
        PlayerPrefs.SetInt("SelectedResWidth", selectedWidth);
        PlayerPrefs.SetInt("SelectedResHeight", selectedHeight);
        screenRes = ("800x600");
        PlayerPrefs.SetString("SelectedScreenRes", screenRes);
    }

    public void SetResolution1024x768()
    {
        Screen.SetResolution(1024, 768, isFullScreen);
        selectedWidth = 1024;
        selectedHeight = 768;
        PlayerPrefs.SetInt("SelectedResWidth", selectedWidth);
        PlayerPrefs.SetInt("SelectedResHeight", selectedHeight);
        screenRes = ("1024x768");
        PlayerPrefs.SetString("SelectedScreenRes", screenRes);
    }

    public void SetResolution1152x864()
    {
        Screen.SetResolution(1152, 864, isFullScreen);
        selectedWidth = 1152;
        selectedHeight = 864;
        PlayerPrefs.SetInt("SelectedResWidth", selectedWidth);
        PlayerPrefs.SetInt("SelectedResHeight", selectedHeight);
        screenRes = ("1152x864");
        PlayerPrefs.SetString("SelectedScreenRes", screenRes);
    }

    public void SetResolution2048x1536()
    {
        Screen.SetResolution(2048, 1536, isFullScreen);
        selectedWidth = 2048;
        selectedHeight = 1536;
        PlayerPrefs.SetInt("SelectedResWidth", selectedWidth);
        PlayerPrefs.SetInt("SelectedResHeight", selectedHeight);
        screenRes = ("2048x1536");
        PlayerPrefs.SetString("SelectedScreenRes", screenRes);
    }

    public void InitializeVideoSettings() //Sets up video settings if player has not done so yet, then applies video settings to the game
    {
        if (PlayerPrefs.GetString("FullScreen") == "")
        {
            PlayerPrefs.SetString("FullScreen", "On");
            isFullScreen = true;
        }


        if((PlayerPrefs.GetString("screenRes") == ""))
        {
            SetResolution1920x1080();
        }

        UpdateScreenDisplay();
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
