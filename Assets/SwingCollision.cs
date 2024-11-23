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

    public bool collidedBall;

    public GameObject ballObject;
    public Ball activeBall;
    // Start is called before the first frame update
    void Awake()
    {
       
    }
    
    void Start()
    {
        collidedBall = false;

        ballObject = GameObject.FindWithTag("Ball");
        activeBall = ballObject.GetComponent<Ball>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        Debug.Log("Ball collision recognized!");
        if (col.gameObject == ballObject)
        {
            
            ballObject = col.gameObject;
            activeBall.UpdateBallVelocity(horizontalPower, verticlePower);
            activeBall.AddBallExp(1);
            collidedBall = true;

            if (collidedBall == false)
            {
                
            }
        }
    }
}
