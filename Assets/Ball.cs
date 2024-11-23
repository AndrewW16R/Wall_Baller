using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ball : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    private CircleCollider2D coll;

    public float ballSpeed;
    public int ballLevel;
    public int ballExp;
    public float speedCap;
    public float speedMin;
    public float speedCapIncreasePerLevel;
    Transform ballTransform;

    public float launchAngle;
    float angleInRadians;
    float xForce;
    float yForce;

    Vector3 vel;

    // Start is called before the first frame update
    void Start()
    {
        //Gets Rigidbody2D component from gameobject
        rb = GetComponent<Rigidbody2D>();

        //Gets CircleCollider2D component from gameobject
        coll = GetComponent<CircleCollider2D>();

        ballTransform = GetComponent<Transform>();

        //ballSpeed = 1f; //the ball's current speed
        ballLevel = 1; //The Ball's current level
        ballExp = 0; //How much experience the ball has, ball levels up once reaching 10 exp and then 10 exp from ballExp is subtracted
    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity = ballSpeed * (rb.velocity.normalized);
    }

    public void UpdateBallVelocity(float xVel, float yVel)
    {
        //rb.velocity = new Vector2(rb.velocity.x + xVel, rb.velocity.y + yVel);
        //transform.eulerAngles = Vector3.forward * 20;
        //rb.SetRotation(20f);
        //rb.AddForce(new Vector3( 0, 0, 5), ForceMode2D.Force);
        //rb.velocity = ballSpeed * (rb.velocity.normalized);

        /*if(rb.velocity.x < 0)
        {
            rb.velocityX = rb.velocity.x * -1;
        }
        rb.velocityX = rb.velocity.x + xVel;
        */


        /*
        vel = rb.velocity; //vector 3 vairable is set to velocity
        vel.x = ballSpeed + xVel; //set x velocity to ball speed + added ball power

        if(vel.x >= speedCap) //if the ball speed would exceed the current speed cap when the new velocity is applied, set the new velocity to apply to equal the speed cap.
        {
            vel.x = speedCap;
        }

        vel.y = yVel;
        rb.velocity = vel;

        ballSpeed = vel.x;
        */
        ballSpeed = ballSpeed + xVel;

        angleInRadians = launchAngle * Mathf.Deg2Rad;
        xForce = ballSpeed * Mathf.Cos(angleInRadians);
        yForce = ballSpeed * Mathf.Sin(angleInRadians);

        rb.AddForce(new Vector2(xForce, yForce), ForceMode2D.Impulse);
        
    }

    public void AddBallExp(int expAmount)
    {
        ballExp = ballExp + expAmount;
        Debug.Log("Ball EXP = " + ballExp);

        if (ballExp >= 10)
        {
            LevelUpBall();
        }
    }

    public void LevelUpBall()
    {
        ballLevel = ballLevel + 1;
        ballExp = ballExp - 10;
        UpdateSpeedCap();
    }

    public void UpdateSpeedCap()
    {
        speedCap = speedCap + speedCapIncreasePerLevel;
    }

    public void LaunchBallDirection()
    {
        
    }
}
