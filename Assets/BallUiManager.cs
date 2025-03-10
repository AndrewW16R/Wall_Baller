using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BallUiManager : MonoBehaviour
{

    public Ball activeBall;
    public GameObject ballObject;

    private GameObject playerObject;
    private SwingStaleness swingStaleness;
    public PlayerMovement playerMovement;

    public GameObject gameManagerObject;
    public GameManager gameManager;
    public Timer timer;

    public Text textBallSpeed;
    public Text textBallLevel;
    public Text textBallExp;
    public Text textStyle;
    public Text textTimer;
    public Text textDashAvailable;

    public float actualBallSpeed;
    public int displayBallSpeed;

    public float displayTimer;

    // Start is called before the first frame update
    void Start()
    {
        ballObject = GameObject.FindWithTag("Ball");
        activeBall = ballObject.GetComponent<Ball>();

        playerObject = GameObject.FindWithTag("Player");
        swingStaleness = playerObject.GetComponent<SwingStaleness>();
        playerMovement = playerObject.GetComponent<PlayerMovement>();

        gameManagerObject = GameObject.Find("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();
        timer = gameManagerObject.GetComponent<Timer>();

        textStyle.text = "STYLE: TBD";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        textBallLevel.text = "BALL LVL: " + activeBall.ballLevel.ToString();
        textBallExp.text = "BALL EXP: " + activeBall.ballExp.ToString();
        CalculateDisplaySpeed();
        textBallSpeed.text = "BALL SPEED: " + displayBallSpeed.ToString();
        CalculateStyle();
        //CalculateDisplayTime();
        displayTimer = timer.currentTime;
        textTimer.text = "TIME: " + displayTimer.ToString("##.##");
        CalculateDashAvailability();

    }

    public void CalculateDisplaySpeed() //Takes the actual Ball horizontal speed and converts it to a cleaner whole number to be displayed in the UI
    {
        actualBallSpeed = activeBall.rb.velocity.x;
        actualBallSpeed = Mathf.Round(actualBallSpeed * 10.0f) * 0.1f;
        actualBallSpeed = actualBallSpeed * 10;
        if (actualBallSpeed < 0)
        {
            actualBallSpeed = actualBallSpeed * -1;
        }
        displayBallSpeed = (int)actualBallSpeed;
    }

    public void CalculateStyle()
    {
        if (swingStaleness.prevStaleRating <= 1)
        {
            textStyle.text = "STYLE: FRESH!!!";
        }
        else if (swingStaleness.prevStaleRating == 2)
        {
            textStyle.text = "STYLE: COOL!";
        }
        else if (swingStaleness.prevStaleRating == 3)
        {
            textStyle.text = "STYLE: MEH...";
        }
        else if (swingStaleness.prevStaleRating == 4)
        {
            textStyle.text = "STYLE: STALE";
        }
        else if (swingStaleness.prevStaleRating == 5)
        {
            textStyle.text = "STYLE: WACK";
        }
    }

     public void CalculateDisplayTime()
    {
        if (gameManager.isGameOver == false)
        {
            displayTimer = timer.currentTime;
        }
        else if (gameManager.isGameOver == true)
        {
            displayTimer = 0.0f;
        }
    }

    public void ManualSetTimer(float seconds)
    {
        displayTimer = seconds;
        textTimer.text = "TIME: " + displayTimer.ToString();
    }

    public void CalculateDashAvailability()
    {
        if(playerMovement.dashesAvailable >= 1)
        {
            textDashAvailable.text = "Dash Available: Yes"; 
        }
        else
        {
            textDashAvailable.text = "Dash Available: No";
        }
    }

}
