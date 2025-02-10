using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BallUiManager : MonoBehaviour
{

    public Ball activeBall;
    public GameObject ballObject;

    private SwingStaleness swingStaleness;
    private GameObject swingStalenessObject;

    public Text textBallSpeed;
    public Text textBallLevel;
    public Text textBallExp;
    public Text textStyle;

    public float actualBallSpeed;
    public int displayBallSpeed;

    // Start is called before the first frame update
    void Start()
    {
        ballObject = GameObject.FindWithTag("Ball");
        activeBall = ballObject.GetComponent<Ball>();

        swingStalenessObject = GameObject.FindWithTag("Player");
        swingStaleness = swingStalenessObject.GetComponent<SwingStaleness>();

        textStyle.text = "STYLE: TBD";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        textBallLevel.text = "BALL LVL: " + activeBall.ballLevel.ToString();
        textBallExp.text = "BALL EXP: " + activeBall.ballExp.ToString();
        CalculateDisplaySpeed();
        textBallSpeed.text = "BALL SPEED: " + displayBallSpeed.ToString();
        CalculateStyle();

    }

    public void CalculateDisplaySpeed() //Takes the actual Ball horizontal speed and converts it to a cleaner whole number to be displayed in the UI
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

    public void CalculateStyle()
    {
        if (swingStaleness.staleRating == 1 || swingStaleness.staleRating == 2)
        {
            textStyle.text = "STYLE: FRESH!!!";
        }
        else if (swingStaleness.staleRating == 3)
        {
            textStyle.text = "STYLE: COOL!";
        }
        else if (swingStaleness.staleRating == 4)
        {
            textStyle.text = "STYLE: MEH...";
        }
        else if (swingStaleness.staleRating == 5)
        {
            textStyle.text = "STYLE: STALE";
        }
    }
}
