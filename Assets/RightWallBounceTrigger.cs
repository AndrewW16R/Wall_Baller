using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWallBounceTrigger : MonoBehaviour
{
    public GameObject ballObject;
    public Ball activeBall;

    public GameObject rightWallObject;
    public RightWallAnimator rightWallAnimator;
    // Start is called before the first frame update
    void Start()
    {
        ballObject = GameObject.FindWithTag("Ball");
        activeBall = ballObject.GetComponent<Ball>();

        rightWallObject = GameObject.Find("RightWall");
        rightWallAnimator = rightWallObject.GetComponent<RightWallAnimator>();
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

            rightWallAnimator.InitiateHitAnim();

        }
    }
}
