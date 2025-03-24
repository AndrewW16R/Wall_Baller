using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

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

    public Text textScreenShakeToggleButton;
    public Text textHitboxDisplayToggleButton;

    public GameObject howToPlayCanvas;
    public GameObject tutorialSelectCanvas;
    public GameObject tutorialBasicCanvas;
    public GameObject tutorialIntermediateCanvas;
    public GameObject tutorialAdvancedCanvas;

    public Scene sceneToLoad;

    public GameObject playerPrefManagerObject;
    public GameSettingsSaveSystem gameSettingsSaveSystem;

    public UnityEvent onDisableHowToPlayCanvas; //Event used to ensure allcanvases withint the How to play Menus are disabled

    // Start is called before the first frame update
    void Start()
    {

        if (onDisableHowToPlayCanvas == null)
        {
            onDisableHowToPlayCanvas = new UnityEvent();
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
        textScreenShakeToggleButton.text = gameSettingsSaveSystem.screenShakeToggle;
    }

    public void UpdateHitboxDisplayToggleDisplay() //Setting up string in GameSettingSaveSysten to modify the text in the toggle button to match the current HitboxDisplay setting
    {
        textHitboxDisplayToggleButton.text = gameSettingsSaveSystem.hitboxDisplayToggle;
    }

    public void ToggleHowToPlayCanvas(bool isEnabled)
    {
        howToPlayCanvas.SetActive(isEnabled);

        if(isEnabled==false)
        {
            onDisableHowToPlayCanvas.Invoke();
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
