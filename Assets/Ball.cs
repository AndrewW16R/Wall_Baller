using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ball : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    private CircleCollider2D coll;

    public int ballSpeed;
    public int ballLevel;
    public int ballExp;
    public int speedcap;

    // Start is called before the first frame update
    void Start()
    {
        //Gets Rigidbody2D component from gameobject
        rb = GetComponent<Rigidbody2D>();

        //Gets CircleCollider2D component from gameobject
        coll = GetComponent<CircleCollider2D>();

        ballSpeed = 0; //the ball's current speed
        ballLevel = 0; //The Ball's current level
        ballExp = 0; //How much experience the ball has, ball levels up once reaching 10 exp and then 10 exp from ballExp is subtracted
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateBallVelocity(float xVel, float yVel)
    {
        rb.velocity = new Vector2(rb.velocity.x + xVel, rb.velocity.y + yVel);
        //rb.AddForce(new Vector2( 5, 10f), ForceMode2D.Impulse);
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
}
