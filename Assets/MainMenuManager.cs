using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class MainMenuManager : MonoBehaviour
{

    public GameObject playButton;
    public GameObject howToPlayButton;
    public GameObject controlsButton;
    public GameObject settingsButton;
    public GameObject quitButton;

    
    public GameObject controlsCanvas;

    public GameObject settingsCanvas;
    public GameObject gameSettingsPg;
    public GameObject videoSettingsPg;
    public GameObject audioSettingsPg;

    public GameObject movementTypePg;
    public GameObject difficultySelectPg;

    public TMP_Text textScreenShakeToggleButton;
    public TMP_Text textHitboxDisplayToggleButton;
    public TMP_Text textAimIndicatorToggleButton;
    public TMP_Text textRightWallAnimationToggleButton;

    public GameObject trainingModesCanvas;
    public GameObject howToPlayCanvas;
    public GameObject tutorialSelectCanvas;
    public GameObject tutorialBasicCanvas;
    public GameObject tutorialIntermediateCanvas;
    public GameObject tutorialAdvancedCanvas;

    public Scene sceneToLoad;

    public GameObject playerPrefManagerObject;
    public GameSettingsSaveSystem gameSettingsSaveSystem;

    public bool enableCursorOnStart;

    public UnityEvent onDisableTrainingModesCanvas; //Event used to ensure allcanvases withint the How to play Menus are disabled

    // Start is called before the first frame update
    void Start()
    {

        if (onDisableTrainingModesCanvas == null)
        {
            onDisableTrainingModesCanvas = new UnityEvent();
        }
        
        ButtonsEnabled(true);
        ToggleHowToPlayCanvas(false);
        ToggleTutorialSelectCanvas(false);
        ToggleTutorialBasicCanvas(false);
        ToggleTutorialIntermediateCanvas(false);
        ToggleTutorialAdvancedCanvas(false);
        ToggleControlsCanvas(false);
        ToggleSettingsCanvas(false);
        ToggleMovementTypePg(false);
        ToggleDifficultySelectPg(false);

        playerPrefManagerObject = GameObject.Find("PlayerPrefManager");
        gameSettingsSaveSystem = playerPrefManagerObject.GetComponent<GameSettingsSaveSystem>();

        UpdateScreenShakeToggleDisplay();
        UpdateHitboxDisplayToggleDisplay();

        ToggleCursor(enableCursorOnStart);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ButtonsEnabled(bool isEnabled)
    {
        playButton.SetActive(isEnabled);
        howToPlayButton.SetActive(isEnabled);
        controlsButton.SetActive(isEnabled);
        quitButton.SetActive(isEnabled);
    }

    public void ToggleCursor(bool isEnabled)
    {
        if (isEnabled == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void QuitGame()
    {
        Debug.Log("Game Closing...");
        Application.Quit();
    }


    public void ToggleControlsCanvas(bool isEnabled)
    {
        controlsCanvas.SetActive(isEnabled);
    }

    public void ToggleSettingsCanvas(bool isEnabled)
    {
        settingsCanvas.SetActive(isEnabled);
    }

    public void ToggleGameSettingsPg(bool isEnabled)
    {
        gameSettingsPg.SetActive(isEnabled);
    }

    public void ToggleVideoSettingsPg(bool isEnabled)
    {
        videoSettingsPg.SetActive(isEnabled);
    }

    public void ToggleAudioSettingsPg(bool isEnabled)
    {
        audioSettingsPg.SetActive(isEnabled);
    }

    public void ToggleMovementTypePg(bool isEnabled)
    {
        movementTypePg.SetActive(isEnabled);
    }

    public void ToggleDifficultySelectPg(bool isEnabled)
    {
        difficultySelectPg.SetActive(isEnabled);
    }

    public void UpdateScreenShakeToggleDisplay() //Setting up string in GameSettingSaveSysten to modify the text in the toggle button to match the current ScreenShake setting
    {
        if (gameSettingsSaveSystem.screenShakeToggle == "On")
        {
            textScreenShakeToggleButton.text = "ON";
        }
        else
        {
            textScreenShakeToggleButton.text = "OFF";
        }
        //textScreenShakeToggleButton.text = gameSettingsSaveSystem.screenShakeToggle;
    }

    public void UpdateHitboxDisplayToggleDisplay() //Setting up string in GameSettingSaveSysten to modify the text in the toggle button to match the current HitboxDisplay setting
    {
        if(gameSettingsSaveSystem.hitboxDisplayToggle == "On")
        {
            textHitboxDisplayToggleButton.text = "ON";
        }
        else
        {
            textHitboxDisplayToggleButton.text = "OFF";
        }
        //textHitboxDisplayToggleButton.text = gameSettingsSaveSystem.hitboxDisplayToggle;
    }

    public void UpdateAimIndicatorToggleDisplay() //Setting up string in GameSettingSaveSysten to modify the text in the toggle button to match the current AimIndicator setting
    {
        if (gameSettingsSaveSystem.aimIndicatorToggle == "On")
        {
            textAimIndicatorToggleButton.text = "ON";
        }
        else
        {
            textAimIndicatorToggleButton.text = "OFF";
        }
    }

    public void UpdateRightWallAnimationToggleDisplay() //Setting up string in GameSettingSaveSysten to modify the text in the toggle button to match the current RightWallAnimation setting
    {
        if (gameSettingsSaveSystem.rightWallAnimationToggle == "On")
        {
            textRightWallAnimationToggleButton.text = "ON";
        }
        else
        {
            textRightWallAnimationToggleButton.text = "OFF";
        }
    }

    public void ToggleHowToPlayCanvas(bool isEnabled)
    {
        howToPlayCanvas.SetActive(isEnabled);
    }

    public void ToggleTrainingModesCanvas(bool isEnabled)
    {
        trainingModesCanvas.SetActive(isEnabled);

        if (isEnabled == false)
        {
            onDisableTrainingModesCanvas.Invoke();
        }
    }


    public void ToggleTutorialSelectCanvas(bool isEnabled)
    {
        tutorialSelectCanvas.SetActive(isEnabled);
    }

    public void ToggleTutorialBasicCanvas(bool isEnabled)
    {
        tutorialBasicCanvas.SetActive(isEnabled);
    }

    public void ToggleTutorialIntermediateCanvas(bool isEnabled)
    {
        tutorialIntermediateCanvas.SetActive(isEnabled);
    }

    public void ToggleTutorialAdvancedCanvas(bool isEnabled)
    {
        tutorialAdvancedCanvas.SetActive(isEnabled);
    }
}
