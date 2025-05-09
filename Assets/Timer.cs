using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float currentTime; //how many seconds the timer currently has
    public float intialTime; //how many seconds the timer starts at
    public float timeCap; //The maximum amount of time the timer can go up to
    public float timeAdded; //The previous amount of added time is stored for the Ui to reference when displaying the time added

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

    public string difficulty; //Game difficulty which determines the timer settings, difficulty is gotten from the difficulty select PlayerPref

    public GameManager gameManager;

    public GameObject playerObject;
    public SwingStaleness swingStaleness; //Style rank/staleness adds a multiplier to how much time is gained whenever the ball levels up

    public bool difficultyApplied; //Indicates that if the difficulty setting has been determined and applied to the timer
    

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>(); //This script should be on the GameManager GameObject

        playerObject = GameObject.Find("Player");
        swingStaleness = playerObject.GetComponent<SwingStaleness>();

        timerOn = false;
        difficultyApplied = false;

        if (difficulty == "Standard") //Sets the initial/starting time for Standard difficulty
        {
            Debug.Log("Standard chosen");
            currentTime = intialTime;
            difficultyApplied = true;
        }
        else if(difficulty == "Hard") //Sets the initial/starting time for Hard difficulty
        {
            Debug.Log("Hard chosen");
            currentTime = intialTimeHard;
            difficultyApplied = true;
        }
       /* else
        {
            Debug.Log("Standard chosen (Failsafe)");
            currentTime = intialTime;
            difficultyApplied = true;
            difficulty = "Standard";
        }*/
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    public void UpdateTimer() //Timer countdown is updated each frame
    {
        if (timerOn == true && gameManager.hitStopActive == false && gameManager.isGamePaused == false && gameManager.isGameOver == false)
        {
            currentTime = currentTime - Time.deltaTime;
        }

        if (currentTime <= 0.0f && gameManager.isGameOver == false) //Gameover occurs if the timer reaches zero
        {
            TimerEnded();
        }
    }

    public void TimerEnded()//Activates gameover in the GameManager script when the timer has reached zero
    {
        
            gameManager.ActivateGameOver();
        

    }

    public void AddTime() //Time is added to timer when the ball is leveled up
    {
        gameManager.GetBallInfo(); //gets current info of ball, mostly for the ball level

        if(difficulty == "Standard") //Adding time for Standard difficulty, added time is determined from the ball's level and the player's current style rating
        {
            if (gameManager.ballLevel >= 1 && gameManager.ballLevel <= 3) //Time added for levels 1-3
            {
                timeAdded = timeAdditionOne * swingStaleness.staleMultTimer;
                currentTime = currentTime + (timeAdditionOne * swingStaleness.staleMultTimer);//Time for addition for these ball levels, multiplied by the indicated value by the current style rating
                if (currentTime > timeCap)
                {
                    currentTime = timeCap;
                }
            }
            else if (gameManager.ballLevel >= 4 && gameManager.ballLevel <= 5) //Time added for levels 4-5
            {
                timeAdded = timeAdditionTwo * swingStaleness.staleMultTimer;
                currentTime = currentTime + (timeAdditionTwo * swingStaleness.staleMultTimer); //Time for addition for these ball levels, multiplied by the indicated value by the current style rating
                if (currentTime > timeCap)
                {
                    currentTime = timeCap;
                }
            }
            else if (gameManager.ballLevel >= 6 && gameManager.ballLevel <= 8) //Time added for levels 6-8
            {
                timeAdded = timeAdditionThree * swingStaleness.staleMultTimer;
                currentTime = currentTime + (timeAdditionThree * swingStaleness.staleMultTimer); //Time for addition for these ball levels, multiplied by the indicated value by the current style rating
                if (currentTime > timeCap)
                {
                    currentTime = timeCap;
                }
            }
            else if (gameManager.ballLevel >= 9 && gameManager.ballLevel <= 10)//Time added for levels 9-10
            {
                timeAdded = timeAdditionFour * swingStaleness.staleMultTimer;
                currentTime = currentTime + (timeAdditionFour * swingStaleness.staleMultTimer); //Time for addition for these ball levels, multiplied by the indicated value by the current style rating
                if (currentTime > timeCap)
                {
                    currentTime = timeCap;
                }
            }
            else if (gameManager.ballLevel >= 11) //Time added for levels 11+
            {
                timeAdded = timeAdditionFive * swingStaleness.staleMultTimer;
                currentTime = currentTime + (timeAdditionFive * swingStaleness.staleMultTimer); //Time for addition for these ball levels, multiplied by the indicated value by the current style rating
                if (currentTime > timeCap)
                {
                    currentTime = timeCap;
                }
            }
        }
        else if(difficulty == "Hard")  //Adding time for Hard difficulty, added time is determined from the ball's level and the player's current style rating
        {
            if (gameManager.ballLevel >= 1 && gameManager.ballLevel <= 3) //Time added for levels 1-3
            {
                timeAdded = timeAdditionOne * swingStaleness.staleMultTimer;
                currentTime = currentTime + (timeAdditionOneHard * swingStaleness.staleMultTimer); //Time for addition for these ball levels, multiplied by the indicated value by the current style rating
                if (currentTime > timeCap)
                {
                    currentTime = timeCap;
                }
            }
            else if (gameManager.ballLevel >= 4 && gameManager.ballLevel <= 5) //Time added for levels 4-5
            {
                timeAdded = timeAdditionTwoHard * swingStaleness.staleMultTimer;
                currentTime = currentTime + (timeAdditionTwoHard * swingStaleness.staleMultTimer); //Time for addition for these ball levels, multiplied by the indicated value by the current style rating
                if (currentTime > timeCap)
                {
                    currentTime = timeCap;
                }
            }
            else if (gameManager.ballLevel >= 6 && gameManager.ballLevel <= 8) //Time added for levels 6-8
            {
                timeAdded = timeAdditionThreeHard * swingStaleness.staleMultTimer;
                currentTime = currentTime + (timeAdditionThreeHard * swingStaleness.staleMultTimer); //Time for addition for these ball levels, multiplied by the indicated value by the current style rating
                if (currentTime > timeCap)
                {
                    currentTime = timeCap;
                }
            }
            else if (gameManager.ballLevel >= 9 && gameManager.ballLevel <= 10) //Time added for levels 9-10
            {
                timeAdded = timeAdditionFourHard * swingStaleness.staleMultTimer;
                currentTime = currentTime + (timeAdditionFourHard * swingStaleness.staleMultTimer); //Time for addition for these ball levels, multiplied by the indicated value by the current style rating
                if (currentTime > timeCap)
                {
                    currentTime = timeCap;
                }
            }
            else if (gameManager.ballLevel >= 11) //Time added for levels 11+
            {
                timeAdded = timeAdditionFiveHard * swingStaleness.staleMultTimer;
                currentTime = currentTime + (timeAdditionFiveHard * swingStaleness.staleMultTimer); //Time for addition for these ball levels, multiplied by the indicated value by the current style rating
                if (currentTime > timeCap)
                {
                    currentTime = timeCap;
                }
            }
        }
        
        
    }
}
