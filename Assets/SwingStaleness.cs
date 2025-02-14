using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingStaleness : MonoBehaviour
{
    //public string[] swingLog;

    public string loggedSwingA; //first swing in log
    public string loggedSwingB; //second swing in log
    public string loggedSwingC; //third swing in log
    public string loggedSwingD; //fourth swing in log
    public string loggedSwingE; //fifth swing in log

    public int staleRating;
    public int prevStaleRating;
    public float staleMult;
    public string prevSwing;

    public float lv1StaleMult;
    public float lv2StaleMult;
    public float lv3StaleMult;

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
            loggedSwingE = playerSwing.currentSwingName;
        }
    }

    public void CalculateStaleness()
    {
       

        if (staleRating == 2)
        {
            staleMult = lv1StaleMult;
        }
        else if (staleRating == 3)
        {
            staleMult = lv2StaleMult;
        }
        else if (staleRating == 4)
        {
            staleMult = lv3StaleMult;
        }
        else
        {
            staleMult = 1.0f;
        }

        prevStaleRating = staleRating;
        staleRating = 0;

        

    }

    public void SwingLogCheck()
    {
        if (playerSwing.currentSwingName == "L_Grounded_Middle") //LGM
        {
            swingLGMLogSearchTimer = 5;
        }

        if (swingLGMLogSearchTimer > 0)
        {
            ProcessSwingLog("L_Grounded_Middle", swingLGMLogCount, swingLGMLogSearchTimer);
            swingLGMLogSearchTimer = swingLGMLogSearchTimer - 1;
        }

        if (playerSwing.currentSwingName == "L_Grounded_Up") //LGU
        {
            swingLGULogSearchTimer = 5;
        }

        if (swingLGULogSearchTimer > 0)
        {
            ProcessSwingLog("L_Grounded_Up", swingLGULogCount, swingLGULogSearchTimer);
            swingLGULogSearchTimer = swingLGULogSearchTimer - 1;
        }

        if (playerSwing.currentSwingName == "L_Grounded_Down") //LGD
        {
            swingLGDLogSearchTimer = 5;
        }

        if (swingLGDLogSearchTimer > 0)
        {
            ProcessSwingLog("L_Grounded_Down", swingLGDLogCount, swingLGDLogSearchTimer);
            swingLGDLogSearchTimer = swingLGDLogSearchTimer - 1;
        }


        if (playerSwing.currentSwingName == "L_Airborne_Middle") //LAM
        {
            swingLAMLogSearchTimer = 5;
        }

        if (swingLAMLogSearchTimer > 0)
        {
            ProcessSwingLog("L_Airborne_Middle", swingLAMLogCount, swingLAMLogSearchTimer);
            swingLAMLogSearchTimer = swingLAMLogSearchTimer - 1;
        }

        if (playerSwing.currentSwingName == "L_Airborne_Up") //LAU
        {
            swingLAULogSearchTimer = 5;
        }

        if (swingLAULogSearchTimer > 0)
        {
            ProcessSwingLog("L_Airborne_Up", swingLAULogCount, swingLAULogSearchTimer);
            swingLAULogSearchTimer = swingLAULogSearchTimer - 1;
        }

        if (playerSwing.currentSwingName == "L_Airborne_Down") //LAD
        {
            swingLADLogSearchTimer = 5;
        }

        if (swingLADLogSearchTimer > 0)
        {
            ProcessSwingLog("L_Airborne_Down", swingLADLogCount, swingLADLogSearchTimer);
            swingLADLogSearchTimer = swingLADLogSearchTimer - 1;
        }


        if (playerSwing.currentSwingName == "H_Grounded_Middle")
        {
            swingHGMLogSearchTimer = 5;
        }

        if (swingHGMLogSearchTimer > 0)
        {
            ProcessSwingLog("H_Grounded_Middle", swingHGMLogCount, swingHGMLogSearchTimer);
            swingHGMLogSearchTimer = swingHGMLogSearchTimer - 1;
        }

        if (playerSwing.currentSwingName == "H_Grounded_Up")
        {
            swingHGULogSearchTimer = 5;
        }

        if (swingHGULogSearchTimer > 0)
        {
            ProcessSwingLog("H_Grounded_Up", swingHGULogCount, swingHGULogSearchTimer);
            swingHGULogSearchTimer = swingHGULogSearchTimer - 1;
        }

        if (playerSwing.currentSwingName == "H_Grounded_Down")
        {
            swingHGDLogSearchTimer = 5;
        }

        if (swingHGDLogSearchTimer > 0)
        {
            ProcessSwingLog("H_Grounded_Down", swingHGDLogCount, swingHGDLogSearchTimer);
            swingHGDLogSearchTimer = swingHGDLogSearchTimer - 1;
        }


        if (playerSwing.currentSwingName == "H_Airborne_Middle")
        {
            swingHAMLogSearchTimer = 5;
        }

        if (swingHAMLogSearchTimer > 0)
        {
            ProcessSwingLog("H_Airborne_Middle", swingHAMLogCount, swingHAMLogSearchTimer);
            swingHAMLogSearchTimer = swingHAMLogSearchTimer - 1;
        }

        if (playerSwing.currentSwingName == "H_Airborne_Up")
        {
            swingHAULogSearchTimer = 5;
        }

        if (swingHAULogSearchTimer > 0)
        {
            ProcessSwingLog("H_Airborne_Up", swingHAULogCount, swingHAULogSearchTimer);
            swingHAULogSearchTimer = swingHAULogSearchTimer - 1;
        }

        if (playerSwing.currentSwingName == "H_Airborne_Down")
        {
            swingHADLogSearchTimer = 5;
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
