using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public GameObject playButton;
    public GameObject howToPlayButton;
    public GameObject controlsButton;
    public GameObject quitButton;

    public GameObject howToPlayPg01;
    public GameObject howToPlayPg02;
    public GameObject howToPlayPg03;

    public GameObject howToPlayCanvas;
    public GameObject controlsCanvas;
    public Scene sceneToLoad;

    // Start is called before the first frame update
    void Start()
    {
        ButtonsEnabled(true);
        ToggleHowToPlayCanvas(false);
        ToggleControlsCanvas(false);

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
}