using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverZone : MonoBehaviour
{
    public bool collidedBall;
    public GameObject ballObject;
    public Ball activeBall;

    public GameObject gameManagerObject;
    public GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        collidedBall = false;

        ballObject = GameObject.FindWithTag("Ball");
        activeBall = ballObject.GetComponent<Ball>();

        gameManagerObject = GameObject.Find("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>(); //So that gameoverzone can send to trigger function within game manager
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
                Debug.Log("Game Over!");
                collidedBall = true;
            }
        }
    }

    public void SignalGameOver()
    {
        gameManager.ActivateGameOver();
    }
}
