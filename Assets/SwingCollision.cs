using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingCollision : MonoBehaviour
{

    public int swingTotalDuration;
    public int swingStartupDuration;
    public int swingActiveDuration;
    public int swingEndlagDuration;
    public int ballExpGain;

    public float horizontalPower;
    public float verticlePower;
    public bool isHorizontalPowerMulplicative;

    public bool collidedBall;

    public GameObject ballObject;
    public Ball activeBall;

    public GameObject swingStalenessObject;
    public SwingStaleness swingStaleness;

    // Start is called before the first frame update
    void Awake()
    {
       
    }
    
    void Start()
    {
        collidedBall = false;

        ballObject = GameObject.FindWithTag("Ball");
        activeBall = ballObject.GetComponent<Ball>();

        swingStalenessObject = GameObject.FindWithTag("Player");
        swingStaleness = swingStalenessObject.GetComponent<SwingStaleness>();

        gameObject.SetActive(false);

        swingTotalDuration = swingStartupDuration + swingActiveDuration + swingEndlagDuration;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject == ballObject)
        {
            
            ballObject = col.gameObject;
           

            if (collidedBall == false) //if the ball has not already collided with this hitbox
            {
                swingStaleness.SwingLogUpdate(); //Updates log of previous 5 swings
                swingStaleness.SwingLogCheck(); //Counts reoccurences of swings for the past 5 swings to inform swing staleness
                swingStaleness.CalculateStaleness(); //determines what the staleness multiplier for the next collision will be

                activeBall.UpdateBallVelocity(horizontalPower, verticlePower, isHorizontalPowerMulplicative, swingStaleness.staleMult);
                activeBall.AddBallExp(ballExpGain);
                collidedBall = true;
            }
        }
    }
}
