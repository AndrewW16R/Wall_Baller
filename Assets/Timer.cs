using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float currentTime; //how many seconds the timer currently has
    public float intialTime; //how many seconds the timer starts at
    public float timeCap; //The maximum amount of time the timer can go up to

    public float intialTimeHard; //how many seconds the timer starts at, is used if hard dificulty is selected
    public float timeCapHard; //The maximum amount of time the timer can go up to, is used if hard dificulty is selected


    //public bool timerStarted; //Has the timer started counting for the first time within the scene
    public bool timerOn; //Is the timer currently counting down?

    public float timeAdditionOne;// The amount of time added when leveling up to levels 2 and 3
    public float timeAdditionTwo; // The amount of time added when leveling up to levels 4 and 5
    public float timeAdditionThree; // The amount of time added when leveling up to levels 6, 7, or 8
    public float timeAdditionFour; // The amount of time added when leveling up to levels 9 and 10
    public float timeAdditionFive; // The amount of time added when leveling up to levels 11 and above


    public float timeAdditionOneHard;// The amount of time added when leveling up to levels 2 and 3 (is used if hard dificulty is selected)
    public float timeAdditionTwoHard; // The amount of time added when leveling up to levels 4 and 5 (is used if hard dificulty is selected)
    public float timeAdditionThreeHard; // The amount of time added when leveling up to levels 6, 7, or 8 (is used if hard dificulty is selected)
    public float timeAdditionFourHard; // The amount of time added when leveling up to levels 9 and 10 (is used if hard dificulty is selected)
    public float timeAdditionFiveHard; // The amount of time added when leveling up to levels 11 and above (is used if hard dificulty is selected)

    public string difficulty;

    public GameManager gameManager;

    public GameObject playerObject;
    public SwingStaleness swingStaleness;

    public float timeAdded;

    public bool difficultyApplied;
    

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>(); //This script should be on the GameManager GameObject

        playerObject = GameObject.Find("Player");
        swingStaleness = playerObject.GetComponent<SwingStaleness>();

        timerOn = false;
        difficultyApplied = false;

        if (difficulty == "Standard")
        {
            Debug.Log("Standard chosen");
            currentTime = intialTime;
            difficultyApplied = true;
        }
        else if(difficulty == "Hard")
        {
            Debug.Log("Hard chosen");
            currentTime = intialTimeHard;
            difficultyApplied = true;
        }
        
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

        if(difficulty == "Standard")
        {
            if (gameManager.ballLevel >= 1 && gameManager.ballLevel <= 3)
            {
                currentTime = currentTime + (timeAdditionOne * swingStaleness.staleMultTimer);
                timeAdded = timeAdditionOne * swingStaleness.staleMultTimer;
                if (currentTime > timeCap)
                {
                    currentTime = timeCap;
                }
            }
            else if (gameManager.ballLevel >= 4 && gameManager.ballLevel <= 5)
            {
                currentTime = currentTime + (timeAdditionTwo * swingStaleness.staleMultTimer);
                if (currentTime > timeCap)
                {
                    currentTime = timeCap;
                }
            }
            else if (gameManager.ballLevel >= 6 && gameManager.ballLevel <= 8)
            {
                currentTime = currentTime + (timeAdditionThree * swingStaleness.staleMultTimer);
                if (currentTime > timeCap)
                {
                    currentTime = timeCap;
                }
            }
            else if (gameManager.ballLevel >= 9 && gameManager.ballLevel <= 10)
            {
                currentTime = currentTime + (timeAdditionFour * swingStaleness.staleMultTimer);
                if (currentTime > timeCap)
                {
                    currentTime = timeCap;
                }
            }
            else if (gameManager.ballLevel >= 11)
            {
                currentTime = currentTime + (timeAdditionFive * swingStaleness.staleMultTimer);
                if (currentTime > timeCap)
                {
                    currentTime = timeCap;
                }
            }
        }
        else if(difficulty == "Hard")
        {
            if (gameManager.ballLevel >= 1 && gameManager.ballLevel <= 3)
            {
                currentTime = currentTime + (timeAdditionOneHard * swingStaleness.staleMultTimer);
                timeAdded = timeAdditionOne * swingStaleness.staleMultTimer;
                if (currentTime > timeCap)
                {
                    currentTime = timeCap;
                }
            }
            else if (gameManager.ballLevel >= 4 && gameManager.ballLevel <= 5)
            {
                currentTime = currentTime + (timeAdditionTwoHard * swingStaleness.staleMultTimer);
                if (currentTime > timeCap)
                {
                    currentTime = timeCap;
                }
            }
            else if (gameManager.ballLevel >= 6 && gameManager.ballLevel <= 8)
            {
                currentTime = currentTime + (timeAdditionThreeHard * swingStaleness.staleMultTimer);
                if (currentTime > timeCap)
                {
                    currentTime = timeCap;
                }
            }
            else if (gameManager.ballLevel >= 9 && gameManager.ballLevel <= 10)
            {
                currentTime = currentTime + (timeAdditionFourHard * swingStaleness.staleMultTimer);
                if (currentTime > timeCap)
                {
                    currentTime = timeCap;
                }
            }
            else if (gameManager.ballLevel >= 11)
            {
                currentTime = currentTime + (timeAdditionFiveHard * swingStaleness.staleMultTimer);
                if (currentTime > timeCap)
                {
                    currentTime = timeCap;
                }
            }
        }
        
        
    }
}
