using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

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
    public float ballHitStop;
    
    public float levelHitStop;
    public float totalHitStop;

    public bool hitStopActive;

    public float hitStopThreshHoldForExtraFX;

    public UnityEvent onBigSwingHitStopEvent;

    // Start is called before the first frame update
    void Start()
    {
        SetTimeScale(1);

        isGameOver = false;
        UpdateGamePausedFlag(false);
        UpdateCursorVisibility(false);

        hitStopActive = false;

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

        if (onBigSwingHitStopEvent == null)
        {
            onBigSwingHitStopEvent = new UnityEvent();
        }
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

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenuAlpha");
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
        ballHitStop = activeBall.currentBallHitStop;
    }

    public void UpdateCursorVisibility(bool isCursorVisible)
    {
        Cursor.visible = isCursorVisible;
    }

    public void CalculateHitStop()
    {
        totalHitStop = 0.0f;
        if (ballLevel >= 1 && ballLevel <= 3)
        {
            levelHitStop = 0.0f;
        }
        else if (ballLevel >= 4 && ballLevel <= 5)
        {
            levelHitStop = 0.05f;
        }
        else if(ballLevel >= 6 && ballLevel <= 8)
        {
            levelHitStop = 0.1f;
        }
        else if(ballLevel >= 9 && ballLevel <= 10)
        {
            levelHitStop = 0.15f;
        }
        else if (ballLevel >= 11)
        {
            levelHitStop = 0.2f;
        }

        totalHitStop = ballHitStop + levelHitStop; 

        if(totalHitStop >= hitStopThreshHoldForExtraFX) // if the total hitstop from a swing meets a certain amount, an extra sound effect will play to put emphasis on the impact
        {
            onBigSwingHitStopEvent.Invoke();
        }

        ApplyHitStop(totalHitStop);
    }

    public void ApplyHitStop(float duration)
    {

        if (hitStopActive == true)//HitStop will not be applied if it is already active.
        {
            return;
        }

        if (isGamePaused == false && isGameOver == false)
        {

        }


        SetTimeScale(0.0f); //stops time
        StartCoroutine(HitStopWait(duration));
    }

    IEnumerator HitStopWait(float duration)
    {
        hitStopActive = true;
        yield return new WaitForSecondsRealtime(duration);
        SetTimeScale(1.0f);
        hitStopActive = false;
    }
}
