using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BallUiManager : MonoBehaviour
{

    public Ball activeBall;
    public GameObject ballObject;

    public Text textBallSpeed;
    public Text textBallLevel;
    public Text textBallExp;

    public float actualBallSpeed;
    public int displayBallSpeed;

    // Start is called before the first frame update
    void Start()
    {
        ballObject = GameObject.Find("Ball");
        activeBall = ballObject.GetComponent<Ball>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        textBallLevel.text = "BALL LVL: " + activeBall.ballLevel.ToString();
        textBallExp.text = "BALL EXP: " + activeBall.ballExp.ToString();
        CalculateDisplaySpeed();
        textBallSpeed.text = "BALL SPEED: " + displayBallSpeed.ToString();
    }

    public void CalculateDisplaySpeed()
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
}
