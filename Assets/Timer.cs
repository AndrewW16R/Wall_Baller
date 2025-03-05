using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float currentTime; //how many seconds the timer currently has
    public float intialTime; //how many seconds the timer starts at
    public float timeCap; //The maximum amount of time the timer can go up to

    //public bool timerStarted; //Has the timer started counting for the first time within the scene
    public bool timerOn; //Is the timer currently counting down?

    public float timeAdditonOne;// The amount of time added when leveling up to levels 2 and 3
    public float timeAdditonTwo; // The amount of time added when leveling up to levels 4 and 5
    public float timeAdditonThree; // The amount of time added when leveling up to levels 6, 7, or 8
    public float timeAdditonFour; // The amount of time added when leveling up to levels 9 and 10
    public float timeAdditonFive; // The amount of time added when leveling up to levels 11 and above

    public GameManager gameManager;

    

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>(); //This script should be on the GameManager GameObject

        //timerStarted = false;
        timerOn = false;

        currentTime = intialTime;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    public void UpdateTimer()
    {
        if (timerOn == true && gameManager.hitStopActive == false && gameManager.isGamePaused == false && gameManager.isGameOver == false)
        {
            currentTime = currentTime - Time.deltaTime;
        }

        if (currentTime <= 0.0f && gameManager.isGameOver == false)
        {
            TimerEnded();
        }
    }

    public void TimerEnded()
    {
        gameManager.ActivateGameOver();
    }

    public void AddTime()
    {
        gameManager.GetBallInfo();
        
        if(gameManager.ballLevel >= 1 && gameManager.ballLevel <= 3)
        {
            currentTime = currentTime + timeAdditonOne;
            if(currentTime > timeCap)
            {
                currentTime = timeCap;
            }
        }
        else if (gameManager.ballLevel >= 4 && gameManager.ballLevel <= 5)
        {
            currentTime = currentTime + timeAdditonTwo;
            if (currentTime > timeCap)
            {
                currentTime = timeCap;
            }
        }
        else if (gameManager.ballLevel >= 6 && gameManager.ballLevel <= 8)
        {
            currentTime = currentTime + timeAdditonThree;
            if (currentTime > timeCap)
            {
                currentTime = timeCap;
            }
        }
        else if (gameManager.ballLevel >= 9 && gameManager.ballLevel <= 10)
        {
            currentTime = currentTime + timeAdditonFour;
            if (currentTime > timeCap)
            {
                currentTime = timeCap;
            }
        }
        else if (gameManager.ballLevel >= 11)
        {
            currentTime = currentTime + timeAdditonFive;
            if (currentTime > timeCap)
            {
                currentTime = timeCap;
            }
        }
    }
}
