using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BounceTriggerVolume : MonoBehaviour
{

    public GameObject ballObject;
    public Ball activeBall;

    public UnityEvent onLowSpeedCollisionEvent;
    public UnityEvent onHighSpeedCollisionEvent;

    public GameManager gameManager;
    public GameObject gameManagerObject;

    // Start is called before the first frame update
    void Start()
    {
        ballObject = GameObject.FindWithTag("Ball");
        activeBall = ballObject.GetComponent<Ball>();

        gameManagerObject = GameObject.Find("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();

        if (onLowSpeedCollisionEvent == null)
        {
            onLowSpeedCollisionEvent = new UnityEvent();
        }

        if (onHighSpeedCollisionEvent == null)
        {
            onHighSpeedCollisionEvent = new UnityEvent();
        }
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

            if (gameManager.ballSpeed < 120)
            {
                onLowSpeedCollisionEvent.Invoke();
            }
            else if (gameManager.ballSpeed >= 120)
            {
                onHighSpeedCollisionEvent.Invoke();
            }

        }
    }
}
