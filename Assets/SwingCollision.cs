using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwingCollision : MonoBehaviour
{
    //Each swing hitbox is a child gameobject of the player gameobject. This script is attatched to each swing hitbox gameobject

    public int swingTotalDuration; //the total number of frames the swing this swing active for
    public int swingStartupDuration; //The number of startup frames the swing has, period of time the player character is not actionable,before the hitbox becomes active
    public int swingActiveDuration; //the number of active frames the swing has (the period of time which the hitbox itself is active)
    public int swingEndlagDuration; //the number of recovery frames this swing has, period of time the player character is not actionable, after the hitbox is active
    public int ballExpGain; //How much exp the ball gains upon colliding with this swing
    public float hitStopPower; //A rating which helps calculate how much hitstop occurs upon the swing colliding with the ball. The current ball level is also considered when determining the amount of hitstop.

    public float horizontalPower; //How much speed does this swing add to the ball ontop of the ball's current base speed
    public float verticlePower; //How steep of a verticle angle which the ball is sent at upon colliding with this swing
    public bool isHorizontalPowerMulplicative; //if set to true, the ball's base speed will be multiplied by the swing's horizontal power instead of the horizontal power being added to the ball's base speed.

    public bool collidedBall; //Set to true if this swing has collided with the ball while active. Prevents the same swing from hitting the ball multiple times. 

    public GameObject ballObject;
    public Ball activeBall;

    public GameObject swingStalenessObject;
    public SwingStaleness swingStaleness;

    public UnityEvent onCollisionEvent;//Event that is called upon the ball colliding with this swing. Usally used to activate SFX/VFX and update the availability of a swing cancel

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

        if(onCollisionEvent == null)
        {
            onCollisionEvent = new UnityEvent();//Event that is called upon the ball colliding with this swing. Usally used to activate SFX/VFX and update the availability of a swing cancel
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject == ballObject)//if the ball gameobject enters the swing hitbox
        {
            
            ballObject = col.gameObject;
           

            if (collidedBall == false) //if the ball has not already collided with this hitbox
            {
                swingStaleness.SwingLogUpdate(); //Updates log of previous 6 swings
                swingStaleness.SwingLogCheck(); //Counts reoccurences of swings for the past 6 swings to inform swing staleness
                swingStaleness.CalculateStaleness(); //determines what the staleness multiplier for the next collision/levelup will be

                activeBall.currentBallHitStop = hitStopPower;//Assigns the swing's hitstop power
                activeBall.UpdateBallVelocity(horizontalPower, verticlePower, isHorizontalPowerMulplicative, swingStaleness.staleMultSpeed);//Ball velocity is updated based on the swing which collided with it
                activeBall.AddBallExp(ballExpGain);//adds exp to ball

                onCollisionEvent.Invoke();

               
                activeBall.BallShakeProcess();
                activeBall.HitStopProcess();
                activeBall.ActivateTimer();//If the timer has not already started, start the timer. Mainly used by first swing that collides with the ball
                collidedBall = true;

                
            }
        }
    }
}
