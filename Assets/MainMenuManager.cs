using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    public GameObject playButton;
    public GameObject howToPlayButton;
    public GameObject controlsButton;
    public GameObject settingsButton;
    public GameObject quitButton;

    public GameObject howToPlayPg01;
    public GameObject howToPlayPg02;
    public GameObject howToPlayPg03;

    public GameObject howToPlayCanvas;
    public GameObject controlsCanvas;

    public GameObject settingsCanvas;
    public GameObject gameSettingsPg;
    public GameObject videoSettingsPg;
    public GameObject audioSettingsPg;

    public GameObject movementTypePg;
    public GameObject difficultySelectPg;

    public Text textScreenShakeToggleButton;
    public Text textHitboxDisplayToggleButton;

    public Scene sceneToLoad;

    public GameObject playerPrefManagerObject;
    public GameSettingsSaveSystem gameSettingsSaveSystem;

    // Start is called before the first frame update
    void Start()
    {
        ButtonsEnabled(true);
        ToggleHowToPlayCanvas(false);
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

    public void ToggleHowToPlayCanvas(bool isEnabled)
    {
        howToPlayCanvas.SetActive(isEnabled);
    }

    public void ToggleHowToPlayPg01(bool isEnabled)
    {
        howToPlayPg01.SetActive(isEnabled);
    }

    public void ToggleHowToPlayPg02(bool isEnabled)
    {
        howToPlayPg02.SetActive(isEnabled);
    }

    public void ToggleHowToPlayPg03(bool isEnabled)
    {
        howToPlayPg03.SetActive(isEnabled);
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
}
