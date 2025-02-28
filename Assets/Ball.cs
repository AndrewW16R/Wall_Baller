using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public GameManager gameManager;
    public GameObject gameManagerObject;

    public GameObject ballArtObject;
    public BallShake ballShake;

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

        ballArtObject = GameObject.Find("Ball");
        ballShake = ballArtObject.GetComponent<BallShake>();
    }

    // Update is called once per frame
    void Update()
    {
 
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
}
