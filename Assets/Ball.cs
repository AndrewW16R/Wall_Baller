using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    private CircleCollider2D coll;

    public float initialBallSpeed; //The speed the ball starts out at
    public float ballSpeed; //The ball's current base speed
    public int ballLevel; //The ball's current level
    public int ballExp; //How much exp the ball currently has (0/10)
    public float speedCapIncreasePerLevel; //How much the ball's base speed increases by with each level up
    Transform ballTransform;

    public float currentBallHitStop;//The amount of hitstop power which the ball has inherited from the swing it collided with

    public bool timerStarted;//Has the timer started? Timer waits until the ball has collided with a swing at least one time before starting

    public Timer timer;
    public GameManager gameManager;
    public GameObject gameManagerObject;

    public GameObject ballArtObject;//The gameobject which serves as a the art/visual for the ball
    public BallShake ballShake;//Script that causes the ball to visually shake upon colliding with a swing

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
            onLevelUpEvent = new UnityEvent();//Event called when ball levels up. Used to activate level up SFX
        }

        timerStarted = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(gameManager.isGamePaused == true) //Ball will not move if the game is paused
        {
            Time.timeScale = 0; //After the ballshake and hitstop effects were added, there were cases when the ball would continue to move while the game was paused if the player paused during hitstop. This line of code fixes this issue
        }
    }

    public void UpdateBallVelocity(float xVel, float yVel, bool xMult, float staleMult) //horizontal Speed added by swing, vertical speed/angle/power, is swing horizontal power mulplicative?, Multiplier applied to ball speed if speed mode in SwingStaleness is on
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

    public void AddBallExp(int expAmount) //Experience is added to the ball, amount is determined by collided swing
    {
        ballExp = ballExp + expAmount;

        if (ballExp >= 10) //If the ball's exp reaches 10, it levels up
        {
            LevelUpBall();
        }
    }

    public void LevelUpBall()//Increases the ball level by 1
    {
        ballLevel = ballLevel + 1;
        ballExp = ballExp - 10; //10 exp is subtracted from the ball whenever it levels up
        timer.AddTime(); //Calls the timer to add time
        onLevelUpEvent.Invoke();//Event used to activate associated SFX/VFX with the ball leveling up
        UpdateBallSpeed(); //Ball base speed is increased
    }

    public void UpdateBallSpeed()//Increases the ball's base speed
    {
         ballSpeed = ballSpeed + speedCapIncreasePerLevel;
    }

    public void HitStopProcess()//The GameManager gets info of the ball's current state and calculates the hitstop to be applied
    {
        gameManager.GetBallInfo();
        gameManager.CalculateHitStop();
    }

    public void BallShakeProcess()//A shaking effect is applied to the ball during hitstop when a swing collides with it. Intensity of ball shake is determined by the amount of hitstop which occurs.
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

    public void ActivateTimer()//Starts the timer if it has not been started yet
    {
        if (timerStarted == false)
        {
            timerStarted = true;
        }
        timer.timerOn = true;
    }
}
