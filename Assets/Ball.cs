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
    public int speedCap;
    public int speedMin;
    Transform ballTransform;

    Vector3 vel;

    // Start is called before the first frame update
    void Start()
    {
        //Gets Rigidbody2D component from gameobject
        rb = GetComponent<Rigidbody2D>();

        //Gets CircleCollider2D component from gameobject
        coll = GetComponent<CircleCollider2D>();

        ballTransform = GetComponent<Transform>();

        ballSpeed = 1f; //the ball's current speed
        ballLevel = 0; //The Ball's current level
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

        vel = rb.velocity;
        vel.x = ballSpeed + xVel;
        vel.y = yVel;
        rb.velocity = vel;
        
    }

    public void AddBallExp(int expAmount)
    {
        ballExp = ballExp + expAmount;
        Debug.Log("Ball EXP = " + ballExp);
    }

    public void LevelUpBall()
    {

    }

    public void UpdateSpeedCap()
    {

    }

    public void LaunchBallDirection()
    {
        
    }
}
