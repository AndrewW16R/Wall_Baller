using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    private CircleCollider2D coll;

    public float initialBallSpeed;
    public float ballSpeed;
    public int ballLevel;
    public int ballExp;
    public float speedCapIncreasePerLevel;
    Transform ballTransform;

    public float currentBallHitStop;

    public bool timerStarted;

    public Timer timer;
    public GameManager gameManager;
    public GameObject gameManagerObject;

    public GameObject ballArtObject;
    public BallShake ballShake;

    public UnityEvent onLevelUpEvent;

    // Start is called before the first frame update
    void Start()
    {
        //Gets Rigidbody2D component from gameobject
        rb = GetComponent<Rigidbody2D>();

        //Gets CircleCollider2D component from gameobject
        coll = GetComponent<CircleCollider2D>();

        ballTransform = GetComponent<Transform>();

        ballSpeed = initialBallSpeed;
        ballLevel = 1; //The Ball's current level
        ballExp = 0; //How much experience the ball has, ball levels up once reaching 10 exp and then 10 exp from ballExp is subtracted

         gameManagerObject = GameObject.Find("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();
        timer = gameManagerObject.GetComponent<Timer>();

        ballArtObject = GameObject.Find("Ball");
        ballShake = ballArtObject.GetComponent<BallShake>();

        if (onLevelUpEvent == null)
        {
            onLevelUpEvent = new UnityEvent();
        }

        timerStarted = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(gameManager.isGamePaused == true)
        {
            Time.timeScale = 0; //After the ballshake and hitstop effects were added, there were cases when the ball would continue to move while the game was paused if the player paused during hitstop. This line of code fixes this issue
        }
    }

    public void UpdateBallVelocity(float xVel, float yVel, bool xMult, float staleMult)
    {
        if(xMult == false)
        {
            rb.velocity = new Vector2((ballSpeed + xVel) * staleMult, yVel*staleMult);
        }
        else
        {
            rb.velocity = new Vector2((ballSpeed * xVel) * staleMult, yVel*staleMult);
        }
            
    }

    public void AddBallExp(int expAmount)
    {
        ballExp = ballExp + expAmount;

        if (ballExp >= 10)
        {
            LevelUpBall();
        }
    }

    public void LevelUpBall()
    {
        ballLevel = ballLevel + 1;
        ballExp = ballExp - 10;
        timer.AddTime();
        onLevelUpEvent.Invoke();
        UpdateBallSpeed();
    }

    public void UpdateBallSpeed()
    {
         ballSpeed = ballSpeed + speedCapIncreasePerLevel;
    }

    public void HitStopProcess()
    {
        gameManager.GetBallInfo();
        gameManager.CalculateHitStop();
    }

    public void BallShakeProcess()
    {
        gameManager.GetBallInfo();
        ballShake.duration = gameManager.totalHitStop; //the duration of the ballshake will be the same duration of the hitstop

            if (gameManager.ballHitStop < ballShake.heavySwingHitStopThreshold) //uses shake curve for light swings
        {

            ballShake.ActivateShake01();
        }
            else if (gameManager.ballHitStop >= ballShake.heavySwingHitStopThreshold) //uses shake curve for heavy swings
        {
            ballShake.ActivateShake02();
        }
    }

    public void ActivateTimer()
    {
        if (timerStarted == false)
        {
            timerStarted = true;
        }
        timer.timerOn = true;
    }
}
