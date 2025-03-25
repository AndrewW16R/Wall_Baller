using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VideoSettingsManager : MonoBehaviour
{
    public TMP_Dropdown resDropDown;
    public Toggle fullScreenToggle;

    Resolution[] AllResolutions;
    bool IsFullScreen;
    int selectedResolution;
    List<Resolution> SelectedResolutionList = new List<Resolution>();

    // Start is called before the first frame update
    void Start()
    {
        IsFullScreen = true;
        AllResolutions = Screen.resolutions;

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

        resDropDown.AddOptions(resolutionStringList);
    }

    public void ChangeResolution()
    {
        selectedResolution = resDropDown.value;
        Screen.SetResolution(SelectedResolutionList[selectedResolution].width, SelectedResolutionList[selectedResolution].height, IsFullScreen);
    }

    public void ChangeFullScreen()
    {
        IsFullScreen = fullScreenToggle.isOn;
        Screen.SetResolution(SelectedResolutionList[selectedResolution].width, SelectedResolutionList[selectedResolution].height, IsFullScreen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
