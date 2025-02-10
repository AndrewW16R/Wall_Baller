using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingStaleness : MonoBehaviour
{
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


    public bool swingLogFull;

    private PlayerSwing playerSwing;
    // Start is called before the first frame update
    void Start()
    {
        playerSwing = gameObject.GetComponent<PlayerSwing>();
        swingLogFull = false;
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
        staleRating = 0;

        if (playerSwing.currentSwingName == loggedSwingA)
        {
            staleRating = staleRating + 1;
        }

        if (playerSwing.currentSwingName == loggedSwingB)
        {
            staleRating = staleRating + 1;
        }

        if (playerSwing.currentSwingName == loggedSwingC)
        {
            staleRating = staleRating + 1;
        }

        if (playerSwing.currentSwingName == loggedSwingD)
        {
            staleRating = staleRating + 1;
        }

        if (playerSwing.currentSwingName == loggedSwingE)
        {
            staleRating = staleRating + 1;
        }

        if ((prevStaleRating >= 3 && staleRating <= 2) && playerSwing.currentSwingName != loggedSwingA)
        {
            staleRating = prevStaleRating - 1;
        }

        if (staleRating == 3)
        {
            staleMult = lv1StaleMult;
        }
        else if (staleRating == 4)
        {
            staleMult = lv2StaleMult;
        }
        else if (staleRating == 5)
        {
            staleMult = lv3StaleMult;
        }
        else
        {
            staleMult = 1.0f;
        }

        prevStaleRating = staleRating;

    }
}
