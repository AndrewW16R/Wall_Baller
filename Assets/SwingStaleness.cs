using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingStaleness : MonoBehaviour
{
    public bool styleModeSpeed; //If true, the ball gains more speed the higher the stale rating is. Is currently scrapped as of now, but I'm keeping the code incase I want to utilize later
    public bool styleModeTimer; //If true, the lower the stale rating, the more additional time is gained on the timer upon leveling up the ball 

    public string loggedSwingA; //first swing in log
    public string loggedSwingB; //second swing in log
    public string loggedSwingC; //third swing in log
    public string loggedSwingD; //fourth swing in log
    public string loggedSwingE; //fifth swing in log
    public string loggedSwingF; //fifth swing in log

    public int staleRating; //Number which determines style rating, more reoccurring/non-unique swings in the swing log results in a high stale rating
    public int prevStaleRating; //The stale rating which was previously applied
    public float staleMultSpeed; //The multiplier which will be applied to the ball speed based on the current stale/style rating (only applicable is styleModeSpeed is set on)
    public float staleMultTimer; //The multiplier which will be applied to the amount of time added to the timer when the ball levels up, stale/style rating (only applicable is styleModeTimer is set on)
    public string prevSwing; //The name of the previous swing

    public float speedLv1StaleMult; //The multiplier amount that is applied to the ball speed if the staleRating equals 2 (Only if styleModeSpeed is set on)
    public float speedLv2StaleMult; //The multiplier amount that is applied to the ball speed if the staleRating equals 3 (Only if styleModeSpeed is set on)
    public float speedLv3StaleMult; //The multiplier amount that is applied to the ball speed if the staleRating equals 4 (Only if styleModeSpeed is set on)
    public float speedLv4StaleMult; //The multiplier amount that is applied to the ball speed if the staleRating equals 5 (Only if styleModeSpeed is set on)

    public float timerLv0StaleMult; //The multiplier amount that is applied to the time added to the timer if the staleRating is less than 2 (Only if styleModeTimer is set on)
    public float timerLv1StaleMult; //The multiplier amount that is applied to the time added to the timer if the staleRating equals 2 (Only if styleModeTimer is set on)
    public float timerLv2StaleMult; //The multiplier amount that is applied to the time added to the timer if the staleRating equals 3 (Only if styleModeTimer is set on)
    public float timerLv3StaleMult; //The multiplier amount that is applied to the time added to the timer if the staleRating equals 4 (Only if styleModeTimer is set on)
    public float timerLv4StaleMult; //The multiplier amount that is applied to the time added to the timer if the staleRating equals 5 (Only if styleModeTimer is set on)

    public int swingLGMLogCount; //Keeps track of how many times the Swing LGM occurs in the swing log when the swing log is processed
    public int swingLGMLogSearchTimer; //When the LGM swing is used, this timer will ensure that the swing will be searched for in the swing log until is is moved out of the swing log from SwingLog Slot A
    private int swingLGULogCount; //Keeps track of how many times the Swing LGU occurs in the swing log when the swing log is processed
    private int swingLGULogSearchTimer; //When the LGU swing is used, this timer will ensure that the swing will be searched for in the swing log until is is moved out of the swing log from SwingLog Slot A
    private int swingLGDLogCount; //Keeps track of how many times the Swing LGD occurs in the swing log when the swing log is processed
    private int swingLGDLogSearchTimer; //When the LGD swing is used, this timer will ensure that the swing will be searched for in the swing log until is is moved out of the swing log from SwingLog Slot A

    private int swingLAMLogCount; //Keeps track of how many times the Swing LAM occurs in the swing log when the swing log is processed
    private int swingLAMLogSearchTimer; //When the LAM swing is used, this timer will ensure that the swing will be searched for in the swing log until is is moved out of the swing log from SwingLog Slot A
    private int swingLAULogCount; //Keeps track of how many times the Swing LAU occurs in the swing log when the swing log is processed
    private int swingLAULogSearchTimer; //When the LAU swing is used, this timer will ensure that the swing will be searched for in the swing log until is is moved out of the swing log from SwingLog Slot A
    private int swingLADLogCount; //Keeps track of how many times the Swing LAD occurs in the swing log when the swing log is processed
    private int swingLADLogSearchTimer; //When the LAD swing is used, this timer will ensure that the swing will be searched for in the swing log until is is moved out of the swing log from SwingLog Slot A

    private int swingHGMLogCount; //Keeps track of how many times the Swing HGM occurs in the swing log when the swing log is processed
    private int swingHGMLogSearchTimer; //When the HGM swing is used, this timer will ensure that the swing will be searched for in the swing log until is is moved out of the swing log from SwingLog Slot A
    private int swingHGULogCount; //Keeps track of how many times the Swing HGU occurs in the swing log when the swing log is processed
    private int swingHGULogSearchTimer; //When the HGU swing is used, this timer will ensure that the swing will be searched for in the swing log until is is moved out of the swing log from SwingLog Slot A
    private int swingHGDLogCount; //Keeps track of how many times the Swing HGD occurs in the swing log when the swing log is processed
    private int swingHGDLogSearchTimer; //When the HGD swing is used, this timer will ensure that the swing will be searched for in the swing log until is is moved out of the swing log from SwingLog Slot A

    private int swingHAMLogCount; //Keeps track of how many times the Swing HAM occurs in the swing log when the swing log is processed
    private int swingHAMLogSearchTimer; //When the HAM swing is used, this timer will ensure that the swing will be searched for in the swing log until is is moved out of the swing log from SwingLog Slot A
    private int swingHAULogCount; //Keeps track of how many times the Swing HAU occurs in the swing log when the swing log is processed
    private int swingHAULogSearchTimer; //When the HAU swing is used, this timer will ensure that the swing will be searched for in the swing log until is is moved out of the swing log from SwingLog Slot A
    private int swingHADLogCount; //Keeps track of how many times the Swing HAD occurs in the swing log when the swing log is processed
    private int swingHADLogSearchTimer; //When the HAD swing is used, this timer will ensure that the swing will be searched for in the swing log until is is moved out of the swing log from SwingLog Slot A

    public bool swingLogFull; //Set to true if the swing log is full

    private PlayerSwing playerSwing;
    // Start is called before the first frame update

    public GameObject backgroundManagerObject;
    public LevelBackgroundManager levelBackgroundManager; //Background sprite will be updated accordingly depending on style level each time the swing log is updated

    public GameObject gameUiManagerObject;
    public GameUiManager gameUiManager;//Ui 'styleDisplay' element will update depending on the current style level

    void Start()
    {
        playerSwing = gameObject.GetComponent<PlayerSwing>();
        swingLogFull = false;

        backgroundManagerObject = GameObject.Find("LevelBackgroundGroup");
        levelBackgroundManager = backgroundManagerObject.GetComponent<LevelBackgroundManager>();

        gameUiManagerObject = GameObject.Find("GameUiCanvas");
        gameUiManager = gameUiManagerObject.GetComponent<GameUiManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwingLogUpdate()//updates the swing log when a swing collides with the ball.
    {
        if (swingLogFull == false)
        {
            if(loggedSwingA == "")
            {
                loggedSwingA = playerSwing.currentSwingName;
            }
            else if (loggedSwingB == "")
            {
                loggedSwingB = playerSwing.currentSwingName;
            }
            else if (loggedSwingC == "")
            {
                loggedSwingC = playerSwing.currentSwingName;
            }
            else if (loggedSwingD == "")
            {
                loggedSwingD = playerSwing.currentSwingName;
            }
            else if (loggedSwingE == "")
            {
                loggedSwingE = playerSwing.currentSwingName;
            }
            else if (loggedSwingF == "")
            {
                loggedSwingF = playerSwing.currentSwingName;
            }
            else
            {
                swingLogFull = true;
            }
        }
         
        if(swingLogFull == true) //If the swinglog is full, each swing in the list is translated one spot up. The swing in SwingLogA will be move out of the list
        {
            loggedSwingA = loggedSwingB;
            loggedSwingB = loggedSwingC;
            loggedSwingC = loggedSwingD;
            loggedSwingD = loggedSwingE;
            loggedSwingE = loggedSwingF;
            loggedSwingF = playerSwing.currentSwingName;
        }
    }

    public void CalculateStaleness()//Calculates stale rating
    {

        if (styleModeSpeed == true) //For determining multiplier for speed mode
        {
            if (staleRating == 2)
            {
                staleMultSpeed = speedLv1StaleMult;
            }
            else if (staleRating == 3)
            {
                staleMultSpeed = speedLv2StaleMult;
            }
            else if (staleRating == 4)
            {
                staleMultSpeed = speedLv3StaleMult;
            }
            else if (staleRating == 5)
            {
                staleMultSpeed = speedLv4StaleMult;
            }
            else
            {
                staleMultSpeed = 1.0f;
            }
        }
        else
        {
            staleMultSpeed = 1.0f;
        }
        
        
        
        if (styleModeTimer == true) // for determining multiplier for timer mode
        {
            if (staleRating < 2)
            {
                staleMultTimer = timerLv0StaleMult;
                levelBackgroundManager.BackgroundUpdate("Fresh");
                gameUiManager.StyleDisplaySetToFresh();
            }
            else if (staleRating == 2)
            {
                staleMultTimer = timerLv1StaleMult;
                levelBackgroundManager.BackgroundUpdate("Cool");
                gameUiManager.StyleDisplaySetToCool();
            }
            else if (staleRating == 3)
            {
                staleMultTimer = timerLv2StaleMult;
                levelBackgroundManager.BackgroundUpdate("Ok");
                gameUiManager.StyleDisplaySetToOk();
            }
            else if (staleRating == 4)
            {
                staleMultTimer = timerLv3StaleMult;
                levelBackgroundManager.BackgroundUpdate("Meh");
                gameUiManager.StyleDisplaySetToMeh();
            }
            else if (staleRating == 5)
            {
                staleMultTimer = timerLv4StaleMult;
                levelBackgroundManager.BackgroundUpdate("Wack");
                gameUiManager.StyleDisplaySetToWack();
            }
            else
            {
                staleMultTimer = 1.0f;
            }
        }
        else
        {
            staleMultTimer = 1.0f;
        }

        prevStaleRating = staleRating;
        staleRating = 0;

        

    }

    public void SwingLogCheck()//Determines for each swing if it would be present in the swing log, and then initiates searches for repeated occurences of Swings that are in the swing log
    {
        if (playerSwing.currentSwingName == "L_Grounded_Middle") //LGM
        {
            swingLGMLogSearchTimer = 6;// if the previous swing was LGM, The LGM swing will be checked for in the swing log each time a new swing collides with the ball. 
        }

        if (swingLGMLogSearchTimer > 0) //The swing will be checked for repeat occurences as long as the search timer is above 0
        {
            ProcessSwingLog("L_Grounded_Middle", swingLGMLogCount, swingLGMLogSearchTimer);
            swingLGMLogSearchTimer = swingLGMLogSearchTimer - 1;
        }

        if (playerSwing.currentSwingName == "L_Grounded_Up") //LGU
        {
            swingLGULogSearchTimer = 6;
        }

        if (swingLGULogSearchTimer > 0)
        {
            ProcessSwingLog("L_Grounded_Up", swingLGULogCount, swingLGULogSearchTimer);
            swingLGULogSearchTimer = swingLGULogSearchTimer - 1;
        }

        if (playerSwing.currentSwingName == "L_Grounded_Down") //LGD
        {
            swingLGDLogSearchTimer = 6;
        }

        if (swingLGDLogSearchTimer > 0)
        {
            ProcessSwingLog("L_Grounded_Down", swingLGDLogCount, swingLGDLogSearchTimer);
            swingLGDLogSearchTimer = swingLGDLogSearchTimer - 1;
        }


        if (playerSwing.currentSwingName == "L_Airborne_Middle") //LAM
        {
            swingLAMLogSearchTimer = 6;
        }

        if (swingLAMLogSearchTimer > 0)
        {
            ProcessSwingLog("L_Airborne_Middle", swingLAMLogCount, swingLAMLogSearchTimer);
            swingLAMLogSearchTimer = swingLAMLogSearchTimer - 1;
        }

        if (playerSwing.currentSwingName == "L_Airborne_Up") //LAU
        {
            swingLAULogSearchTimer = 6;
        }

        if (swingLAULogSearchTimer > 0)
        {
            ProcessSwingLog("L_Airborne_Up", swingLAULogCount, swingLAULogSearchTimer);
            swingLAULogSearchTimer = swingLAULogSearchTimer - 1;
        }

        if (playerSwing.currentSwingName == "L_Airborne_Down") //LAD
        {
            swingLADLogSearchTimer = 6;
        }

        if (swingLADLogSearchTimer > 0)
        {
            ProcessSwingLog("L_Airborne_Down", swingLADLogCount, swingLADLogSearchTimer);
            swingLADLogSearchTimer = swingLADLogSearchTimer - 1;
        }


        if (playerSwing.currentSwingName == "H_Grounded_Middle")
        {
            swingHGMLogSearchTimer = 6;
        }

        if (swingHGMLogSearchTimer > 0)
        {
            ProcessSwingLog("H_Grounded_Middle", swingHGMLogCount, swingHGMLogSearchTimer);
            swingHGMLogSearchTimer = swingHGMLogSearchTimer - 1;
        }

        if (playerSwing.currentSwingName == "H_Grounded_Up")
        {
            swingHGULogSearchTimer = 6;
        }

        if (swingHGULogSearchTimer > 0)
        {
            ProcessSwingLog("H_Grounded_Up", swingHGULogCount, swingHGULogSearchTimer);
            swingHGULogSearchTimer = swingHGULogSearchTimer - 1;
        }

        if (playerSwing.currentSwingName == "H_Grounded_Down")
        {
            swingHGDLogSearchTimer = 6;
        }

        if (swingHGDLogSearchTimer > 0)
        {
            ProcessSwingLog("H_Grounded_Down", swingHGDLogCount, swingHGDLogSearchTimer);
            swingHGDLogSearchTimer = swingHGDLogSearchTimer - 1;
        }


        if (playerSwing.currentSwingName == "H_Airborne_Middle")
        {
            swingHAMLogSearchTimer = 6;
        }

        if (swingHAMLogSearchTimer > 0)
        {
            ProcessSwingLog("H_Airborne_Middle", swingHAMLogCount, swingHAMLogSearchTimer);
            swingHAMLogSearchTimer = swingHAMLogSearchTimer - 1;
        }

        if (playerSwing.currentSwingName == "H_Airborne_Up")
        {
            swingHAULogSearchTimer = 6;
        }

        if (swingHAULogSearchTimer > 0)
        {
            ProcessSwingLog("H_Airborne_Up", swingHAULogCount, swingHAULogSearchTimer);
            swingHAULogSearchTimer = swingHAULogSearchTimer - 1;
        }

        if (playerSwing.currentSwingName == "H_Airborne_Down")
        {
            swingHADLogSearchTimer = 6;
        }

        if (swingHADLogSearchTimer > 0)
        {
            ProcessSwingLog("H_Airborne_Down", swingHADLogCount, swingHADLogSearchTimer);
            swingHADLogSearchTimer = swingHADLogSearchTimer - 1;
        }
    }

    public void ProcessSwingLog(string swingName, int swingLogCount, int swingSearchCounter)//searches swing log for each repeated occurence of a selected swing. Number of repeat occurences are added to stale rating.
    {
        if (swingName == loggedSwingA)
        {
            swingLogCount = swingLogCount + 1;
        }

        if (swingName == loggedSwingB)
        {
            swingLogCount = swingLogCount + 1;
        }

        if (swingName == loggedSwingC)
        {
            swingLogCount = swingLogCount + 1;
        }

        if (swingName == loggedSwingD)
        {
            swingLogCount = swingLogCount + 1;
        }

        if (swingName == loggedSwingE)
        {
            swingLogCount = swingLogCount + 1;
        }

        if (swingName == loggedSwingF)
        {
            swingLogCount = swingLogCount + 1;
        }

        //swingSearchCounter = swingSearchCounter - 1;

        staleRating = staleRating + (swingLogCount - 1);//1 is subtracted from the number of occurences so that only repeat occurrences are accounted.

        swingLogCount = 0;

    }

}
