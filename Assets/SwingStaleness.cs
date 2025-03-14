using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingStaleness : MonoBehaviour
{
    //public string[] swingLog;

    public bool styleModeSpeed; //If true, the ball gains more speed the higher the stale rating is
    public bool styleModeTimer; //If true, the lower the stale rating, the more additional time is gained on the timer upon leveling up the ball 

    public string loggedSwingA; //first swing in log
    public string loggedSwingB; //second swing in log
    public string loggedSwingC; //third swing in log
    public string loggedSwingD; //fourth swing in log
    public string loggedSwingE; //fifth swing in log
    public string loggedSwingF; //fifth swing in log

    public int staleRating;
    public int prevStaleRating;
    public float staleMultSpeed;
    public float staleMultTimer;
    public string prevSwing;

    public float speedLv1StaleMult;
    public float speedLv2StaleMult;
    public float speedLv3StaleMult;
    public float speedLv4StaleMult;

    public float timerLv0StaleMult;
    public float timerLv1StaleMult;
    public float timerLv2StaleMult;
    public float timerLv3StaleMult;
    public float timerLv4StaleMult;

    public int swingLGMLogCount;
    public int swingLGMLogSearchTimer;
    private int swingLGULogCount;
    private int swingLGULogSearchTimer;
    private int swingLGDLogCount;
    private int swingLGDLogSearchTimer;

    private int swingLAMLogCount;
    private int swingLAMLogSearchTimer;
    private int swingLAULogCount;
    private int swingLAULogSearchTimer;
    private int swingLADLogCount;
    private int swingLADLogSearchTimer;

    private int swingHGMLogCount;
    private int swingHGMLogSearchTimer;
    private int swingHGULogCount;
    private int swingHGULogSearchTimer;
    private int swingHGDLogCount;
    private int swingHGDLogSearchTimer;

    private int swingHAMLogCount;
    private int swingHAMLogSearchTimer;
    private int swingHAULogCount;
    private int swingHAULogSearchTimer;
    private int swingHADLogCount;
    private int swingHADLogSearchTimer;

    public bool swingLogFull;

    private PlayerSwing playerSwing;
    // Start is called before the first frame update
    void Start()
    {
        playerSwing = gameObject.GetComponent<PlayerSwing>();
        swingLogFull = false;

        //swingLog = new string[5];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwingLogUpdate()
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
         
        if(swingLogFull == true)
        {
            loggedSwingA = loggedSwingB;
            loggedSwingB = loggedSwingC;
            loggedSwingC = loggedSwingD;
            loggedSwingD = loggedSwingE;
            loggedSwingE = loggedSwingF;
            loggedSwingF = playerSwing.currentSwingName;
        }
    }

    public void CalculateStaleness()
    {

        if (styleModeSpeed == true)
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
        
        
        
        if (styleModeTimer == true)
        {
            if (staleRating < 2)
            {
                staleMultTimer = timerLv0StaleMult;
            }
            else if (staleRating == 2)
            {
                staleMultTimer = timerLv1StaleMult;
            }
            else if (staleRating == 3)
            {
                staleMultTimer = timerLv2StaleMult;
            }
            else if (staleRating == 4)
            {
                staleMultTimer = timerLv3StaleMult;
            }
            else if (staleRating == 5)
            {
                staleMultTimer = timerLv4StaleMult;
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

    public void SwingLogCheck()
    {
        if (playerSwing.currentSwingName == "L_Grounded_Middle") //LGM
        {
            swingLGMLogSearchTimer = 6;
        }

        if (swingLGMLogSearchTimer > 0)
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

    public void ProcessSwingLog(string swingName, int swingLogCount, int swingSearchCounter)
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

        staleRating = staleRating + (swingLogCount - 1);

        swingLogCount = 0;

    }

    /*
    public void ProcessSwingLogLGM(string swingName, int swingLogCount, int swingSearchCounter)
    {
        swingLAMLogCount = 0;

        if (loggedSwingA == "L_Grounded_Middle")
        {
            swingLAMLogCount = swingLAMLogCount + 1;
        }

        if (loggedSwingB == "L_Grounded_Middle")
        {
            swingLAMLogCount = swingLAMLogCount + 1;
        }

        if (loggedSwingC == "L_Grounded_Middle")
        {
            swingLAMLogCount = swingLAMLogCount + 1;
        }

        if (loggedSwingD == "L_Grounded_Middle")
        {
            swingLAMLogCount = swingLAMLogCount + 1;
        }

        if (loggedSwingE == "L_Grounded_Middle")
        {
            swingLAMLogCount = swingLAMLogCount + 1;
        }

        swingLGMLogSearchTimer = swingLGMLogSearchTimer - 1;

        staleRating = staleRating + (swingLogCount - 1);

        swingLogCount = 0;

    }
    */
}
