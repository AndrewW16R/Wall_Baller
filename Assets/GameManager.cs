using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public bool isGameOver; //True if in game over state
    public bool isGamePaused; //True if game is paused
    

    public GameObject gameOverZoneObject; //Trigger volume that initiates a game over if the ball collides with it
    public GameOverZone gameOverZone;

    public GameObject gameOverMenu; //Menu that displays when the player reaches a game over
    private string currentSceneName;

    public GameObject menuCanvasGroup;
    public MenuManager menuManager;

    public GameObject ballUiCanvasObject; //Ui on top of screen that displays details about the status of the ball and the player
    public BallUiManager ballUiManager;

    public GameObject gameUiCanvasObject; //Ui on top of screen that displays details about the status of the ball and the player
    public GameUiManager gameUiManager;

    public GameObject ballObject;
    public Ball activeBall; //getting ball info to share with UI elements

    public Timer timer; //The timer which counts down to a game over

    public float ballSpeed;
    public int ballLevel;
    public int ballExp;
    public float ballHitStop;
    
    public float levelHitStop;
    public float totalHitStop;

    public bool hitStopActive; //if hitstop is currently active, set to true

    public float hitStopThreshHoldForExtraFX; //If the total hitstop from a swing is greater than this float, the onBigSwingHitStopEvent is triggered

    public UnityEvent onBigSwingHitStopEvent; //Event triggers when a swing which causes a large amount of hitstop occurs
    public UnityEvent onGameOverEvent; //Event triggers when a game over occurs

    // Start is called before the first frame update
    void Start()
    {
        SetTimeScale(1);

        isGameOver = false;
        UpdateGamePausedFlag(false);
        UpdateCursorVisibility(false);

        hitStopActive = false;

        gameOverZoneObject = GameObject.FindWithTag("GameOverZone");
        gameOverZone = gameOverZoneObject.GetComponent<GameOverZone>();

        menuCanvasGroup = GameObject.Find("MenuCanvasGroup");
        menuManager = menuCanvasGroup.GetComponent<MenuManager>();

        ballUiCanvasObject = GameObject.Find("BallUiCanvas");
        ballUiManager = ballUiCanvasObject.GetComponent<BallUiManager>();

        gameUiCanvasObject = GameObject.Find("GameUiCanvas");
        gameUiManager = gameUiCanvasObject.GetComponent<GameUiManager>();

        ballObject = GameObject.FindWithTag("Ball");
        activeBall = ballObject.GetComponent<Ball>();

        timer = GetComponent<Timer>(); //Timer script should be on the GameManager GameObject

        currentSceneName = SceneManager.GetActiveScene().name;

        if (onBigSwingHitStopEvent == null)
        {
            onBigSwingHitStopEvent = new UnityEvent();
        }

        if (onGameOverEvent == null)
        {
            onGameOverEvent = new UnityEvent();
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
    } //Sets the time scale of the game, usually to zero for hitstop and pausing the game

    public void ActivateGameOver()
    {
        Cursor.visible = true;
        menuManager.GetPrefSettingsText();
        menuManager.ToggleGameOverMenu(true);
        isGameOver = true;
        onGameOverEvent.Invoke();
        ballUiManager.ManualSetTimer(0.0f);
        gameUiManager.ManualSetTimer(0.0f);
        SetTimeScale(0);
    }//Is called to initate a game over

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


    }//Called in Update, is actively checking to see if the player inputs the button to pause or unpause

    public void UpdateGamePausedFlag(bool gamePausedUpdate)//Sets flag to let the rest of the code know if the game is currently paused or not
    {
        isGamePaused = gamePausedUpdate;
    }

    public void GetBallInfo() //Retrieves current info about the ball gameobject, this info is mostly used to calculate the proper amount of hitstop
    {
        ballSpeed = activeBall.rb.velocity.x;
        ballLevel = activeBall.ballLevel;
        ballExp = activeBall.ballExp;
        ballHitStop = activeBall.currentBallHitStop; //Ball hitstop if determined from what swing collided with the ball
    }

    public void UpdateCursorVisibility(bool isCursorVisible) //Sets the cursor to visible or invisible, usually set to visible when menus (Pause,gameover,ect) are active and set to invisible during gameplay
    {
        Cursor.visible = isCursorVisible;
    }

    public void CalculateHitStop() //Calculates the total amount of hitstop to apply based on the ball's current level and the swing which collided with it
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

    public void ApplyHitStop(float duration) //Applies the hitstop which was previously calculated
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

    IEnumerator HitStopWait(float duration) //Time is stopped for the duration that is determined by the calculated hitstop
    {
        hitStopActive = true;
        yield return new WaitForSecondsRealtime(duration);
        SetTimeScale(1.0f);
        hitStopActive = false;
    }
}
