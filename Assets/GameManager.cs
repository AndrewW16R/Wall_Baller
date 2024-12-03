using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;
    public bool isGamePaused;

    //public GameObject playerObject;
    //public PlayerMovement playerMovement;
    //public PlayerSwing playerSwing;

    

    public GameObject gameOverZoneObject;
    public GameOverZone gameOverZone;

    public GameObject gameOverMenu;
    private string currentSceneName;

    public GameObject menuCanvasGroup;
    public MenuManager menuManager;

    public GameObject ballObject;
    public Ball activeBall; //getting ball info to share with UI elements

    public float ballSpeed;
    public int ballLevel;
    public int ballExp;

    // Start is called before the first frame update
    void Start()
    {
        SetTimeScale(1);

        isGameOver = false;
        UpdateGamePausedFlag(false);
        UpdateCursorVisibility(false);

        //playerObject = GameObject.FindWithTag("Player");
        //playerMovement = playerObject.GetComponent<PlayerMovement>();
        //playerSwing = playerObject.GetComponent<PlayerSwing>();

        gameOverZoneObject = GameObject.FindWithTag("GameOverZone");
        gameOverZone = gameOverZoneObject.GetComponent<GameOverZone>();

        menuCanvasGroup = GameObject.Find("MenuCanvasGroup");
        menuManager = menuCanvasGroup.GetComponent<MenuManager>();

        ballObject = GameObject.FindWithTag("Ball");
        activeBall = ballObject.GetComponent<Ball>();

        currentSceneName = SceneManager.GetActiveScene().name;


    }

    // Update is called once per frame
    void Update()
    {
        PauseGameCheck();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(currentSceneName);
    }

    public void SetTimeScale(float timescale)
    {
        Time.timeScale = timescale;
    }

    public void ActivateGameOver()
    {
        Cursor.visible = true;
        menuManager.ToggleGameOverMenu(true);
        isGameOver = true;
        SetTimeScale(0);
    }

    public void PauseGameCheck()
    {
        if(isGameOver == true)
        {
            return;
        }

        if (Input.GetButtonDown("Pause"))
        {
            if(isGamePaused == false)
            {
                menuManager.TogglePauseMenu(true);
                UpdateCursorVisibility(true);
                UpdateGamePausedFlag(true);
                SetTimeScale(0);
            }
            else
            {
                SetTimeScale(1);
                UpdateCursorVisibility(false);
                menuManager.ClearPauseMenus();
                UpdateGamePausedFlag(false);
                
            }
        }


    }

    public void UpdateGamePausedFlag(bool gamePausedUpdate)
    {
        isGamePaused = gamePausedUpdate;
    }

    public void GetBallInfo()
    {
        ballSpeed = activeBall.rb.velocity.x;
        ballLevel = activeBall.ballLevel;
        ballExp = activeBall.ballExp;
    }

    public void UpdateCursorVisibility(bool isCursorVisible)
    {
        Cursor.visible = isCursorVisible;
    }
}
