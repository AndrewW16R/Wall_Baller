using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameUiManager : MonoBehaviour
{

    public Ball activeBall;
    public GameObject ballObject;

    private GameObject playerObject;
    private SwingStaleness swingStaleness;
    public PlayerMovement playerMovement;

    public GameObject gameManagerObject;
    public GameManager gameManager;
    public Timer timer;

    public TMP_Text textBallSpeed;
    public TMP_Text textBallLevel;
    public TMP_Text textTimer;
    public Text textStyle;

    public TMP_Text textTimeAddedFresh;
    public TMP_Text textTimeAddedCool;
    public TMP_Text textTimeAddedOk;
    public TMP_Text textTimeAddedMeh;
    public TMP_Text textTimeAddedWack;

    public Text textDashAvailable;

    public float actualBallSpeed;
    public int displayBallSpeed;

    public float displayTimer;

    public GameObject exp0BarSprite;
    public GameObject exp10BarSprite;
    public GameObject exp20BarSprite;
    public GameObject exp30BarSprite;
    public GameObject exp40BarSprite;
    public GameObject exp50BarSprite;
    public GameObject exp60BarSprite;
    public GameObject exp70BarSprite;
    public GameObject exp80BarSprite;
    public GameObject exp90BarSprite;
    public GameObject exp100BarSprite;

    public GameObject styleDisplayFresh;
    public GameObject styleDisplayCool;
    public GameObject styleDisplayOk;
    public GameObject styleDisplayMeh;
    public GameObject styleDisplayWack;

    public float timeAddedDisplayDuration;


    // Start is called before the first frame update
    void Start()
    {
        ballObject = GameObject.FindWithTag("Ball");
        activeBall = ballObject.GetComponent<Ball>();

        playerObject = GameObject.FindWithTag("Player");
        swingStaleness = playerObject.GetComponent<SwingStaleness>();
        playerMovement = playerObject.GetComponent<PlayerMovement>();

        gameManagerObject = GameObject.Find("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();
        timer = gameManagerObject.GetComponent<Timer>();

        //textStyle.text = "STYLE: TBD";
        StyleDisplaySetToFresh();
        StopDisplayTimeAdded();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        textBallLevel.text = activeBall.ballLevel.ToString();
        CalculateDisplaySpeed();
        textBallSpeed.text = displayBallSpeed.ToString();
        //CalculateStyle();
        //CalculateDisplayTime();
        displayTimer = timer.currentTime;
        textTimer.text = displayTimer.ToString("##.#");
        CalculateDashAvailability();

    }

    public void CalculateDisplaySpeed() //Takes the actual Ball horizontal speed and converts it to a cleaner whole number to be displayed in the UI
    {
        actualBallSpeed = activeBall.rb.velocity.x;
        actualBallSpeed = Mathf.Round(actualBallSpeed * 10.0f) * 0.1f;
        actualBallSpeed = actualBallSpeed * 10; //Displayed ball speed is the actual ball speed multiplied by 10
        if (actualBallSpeed < 0)
        {
            actualBallSpeed = actualBallSpeed * -1;
        }
        displayBallSpeed = (int)actualBallSpeed;
    }

  /*  public void CalculateStyle()
    {
        if (swingStaleness.prevStaleRating <= 1)//No more than 1 repeated swings within the swing log
        {
            textStyle.text = "STYLE: FRESH!!!";
        }
        else if (swingStaleness.prevStaleRating == 2)//2 repeated swings within the swing log
        {
            textStyle.text = "STYLE: COOL!";
        }
        else if (swingStaleness.prevStaleRating == 3)//3 repeated swings within the swing log
        {
            textStyle.text = "STYLE: MEH...";
        }
        else if (swingStaleness.prevStaleRating == 4)//4 repeated swings within the swing log
        {
            textStyle.text = "STYLE: STALE";
        }
        else if (swingStaleness.prevStaleRating == 5)//5 repeated swings within the swing log
        {
            textStyle.text = "STYLE: WACK";
        }
    }
  */

     public void CalculateDisplayTime()
    {
        if (gameManager.isGameOver == false)
        {
            displayTimer = timer.currentTime;
        }
        else if (gameManager.isGameOver == true)
        {
            displayTimer = 0.0f;
        }
    }

    public void ManualSetTimer(float seconds)
    {
        displayTimer = seconds;
        textTimer.text = "TIME: " + displayTimer.ToString();
    }

    public void CalculateDashAvailability()
    {
        if(playerMovement.dashesAvailable >= 1)
        {
            textDashAvailable.text = "Dash Available: Yes"; 
        }
        else
        {
            textDashAvailable.text = "Dash Available: No";
        }
    }

    public void UpdateExpBarDisplay()
    {
        if (activeBall.ballExp == 0)
        {
            ExpBarSetTo0();
        }
        else if (activeBall.ballExp == 1)
        {
            ExpBarSetTo10();
        }
        else if (activeBall.ballExp == 1)
        {
            ExpBarSetTo10();
        }
        else if (activeBall.ballExp == 2)
        {
            ExpBarSetTo20();
        }
        else if (activeBall.ballExp == 3)
        {
            ExpBarSetTo30();
        }
        else if (activeBall.ballExp == 4)
        {
            ExpBarSetTo40();
        }
        else if (activeBall.ballExp == 5)
        {
            ExpBarSetTo50();
        }
        else if (activeBall.ballExp == 6)
        {
            ExpBarSetTo60();
        }
        else if (activeBall.ballExp == 7)
        {
            ExpBarSetTo70();
        }
        else if (activeBall.ballExp == 8)
        {
            ExpBarSetTo80();
        }
        else if (activeBall.ballExp == 9)
        {
            ExpBarSetTo90();
        }
        else if (activeBall.ballExp == 10)
        {
            ExpBarSetTo100();
        }
    }

    public void DisplayAddedTime()
    {
        if (swingStaleness.prevStaleRating <= 1)//No more than 1 repeated swings within the swing log
        {
            textTimeAddedFresh.text = ("+" + timer.timeAdded.ToString());
            StartCoroutine(TimeAddedDisplayProcess());
            textStyle.text = "STYLE: FRESH!!!";
        }
        else if (swingStaleness.prevStaleRating == 2)//2 repeated swings within the swing log
        {
            textTimeAddedCool.text = ("+" + timer.timeAdded.ToString());
            StartCoroutine(TimeAddedDisplayProcess());
            textStyle.text = "STYLE: COOL!";
        }
        else if (swingStaleness.prevStaleRating == 3)//3 repeated swings within the swing log
        {
            textTimeAddedOk.text = ("+" + timer.timeAdded.ToString());
            StartCoroutine(TimeAddedDisplayProcess());
            textStyle.text = "STYLE: MEH...";
        }
        else if (swingStaleness.prevStaleRating == 4)//4 repeated swings within the swing log
        {
            textTimeAddedMeh.text = ("+" + timer.timeAdded.ToString());
            StartCoroutine(TimeAddedDisplayProcess());
            textStyle.text = "STYLE: STALE";
        }
        else if (swingStaleness.prevStaleRating == 5)//5 repeated swings within the swing log
        {
            textTimeAddedWack.text = ("+" + timer.timeAdded.ToString());
            StartCoroutine(TimeAddedDisplayProcess());
            textStyle.text = "STYLE: WACK";
        }
    }

    public void ExpBarSetTo0()
    {
        exp0BarSprite.SetActive(true);
        exp10BarSprite.SetActive(false);
        exp20BarSprite.SetActive(false);
        exp30BarSprite.SetActive(false);
        exp40BarSprite.SetActive(false);
        exp50BarSprite.SetActive(false);
        exp60BarSprite.SetActive(false);
        exp70BarSprite.SetActive(false);
        exp80BarSprite.SetActive(false);
        exp90BarSprite.SetActive(false);
        exp100BarSprite.SetActive(false);
    }

    public void ExpBarSetTo10()
    {
        exp0BarSprite.SetActive(false);
        exp10BarSprite.SetActive(true);
        exp20BarSprite.SetActive(false);
        exp30BarSprite.SetActive(false);
        exp40BarSprite.SetActive(false);
        exp50BarSprite.SetActive(false);
        exp60BarSprite.SetActive(false);
        exp70BarSprite.SetActive(false);
        exp80BarSprite.SetActive(false);
        exp90BarSprite.SetActive(false);
        exp100BarSprite.SetActive(false);
    }

    public void ExpBarSetTo20()
    {
        exp0BarSprite.SetActive(false);
        exp10BarSprite.SetActive(false);
        exp20BarSprite.SetActive(true);
        exp30BarSprite.SetActive(false);
        exp40BarSprite.SetActive(false);
        exp50BarSprite.SetActive(false);
        exp60BarSprite.SetActive(false);
        exp70BarSprite.SetActive(false);
        exp80BarSprite.SetActive(false);
        exp90BarSprite.SetActive(false);
        exp100BarSprite.SetActive(false);
    }

    public void ExpBarSetTo30()
    {
        exp0BarSprite.SetActive(false);
        exp10BarSprite.SetActive(false);
        exp20BarSprite.SetActive(false);
        exp30BarSprite.SetActive(true);
        exp40BarSprite.SetActive(false);
        exp50BarSprite.SetActive(false);
        exp60BarSprite.SetActive(false);
        exp70BarSprite.SetActive(false);
        exp80BarSprite.SetActive(false);
        exp90BarSprite.SetActive(false);
        exp100BarSprite.SetActive(false);
    }

    public void ExpBarSetTo40()
    {
        exp0BarSprite.SetActive(false);
        exp10BarSprite.SetActive(false);
        exp20BarSprite.SetActive(false);
        exp30BarSprite.SetActive(false);
        exp40BarSprite.SetActive(true);
        exp50BarSprite.SetActive(false);
        exp60BarSprite.SetActive(false);
        exp70BarSprite.SetActive(false);
        exp80BarSprite.SetActive(false);
        exp90BarSprite.SetActive(false);
        exp100BarSprite.SetActive(false);
    }

    public void ExpBarSetTo50()
    {
        exp0BarSprite.SetActive(false);
        exp10BarSprite.SetActive(false);
        exp20BarSprite.SetActive(false);
        exp30BarSprite.SetActive(false);
        exp40BarSprite.SetActive(false);
        exp50BarSprite.SetActive(true);
        exp60BarSprite.SetActive(false);
        exp70BarSprite.SetActive(false);
        exp80BarSprite.SetActive(false);
        exp90BarSprite.SetActive(false);
        exp100BarSprite.SetActive(false);
    }

    public void ExpBarSetTo60()
    {
        exp0BarSprite.SetActive(false);
        exp10BarSprite.SetActive(false);
        exp20BarSprite.SetActive(false);
        exp30BarSprite.SetActive(false);
        exp40BarSprite.SetActive(false);
        exp50BarSprite.SetActive(false);
        exp60BarSprite.SetActive(true);
        exp70BarSprite.SetActive(false);
        exp80BarSprite.SetActive(false);
        exp90BarSprite.SetActive(false);
        exp100BarSprite.SetActive(false);
    }

    public void ExpBarSetTo70()
    {
        exp0BarSprite.SetActive(false);
        exp10BarSprite.SetActive(false);
        exp20BarSprite.SetActive(false);
        exp30BarSprite.SetActive(false);
        exp40BarSprite.SetActive(false);
        exp50BarSprite.SetActive(false);
        exp60BarSprite.SetActive(false);
        exp70BarSprite.SetActive(true);
        exp80BarSprite.SetActive(false);
        exp90BarSprite.SetActive(false);
        exp100BarSprite.SetActive(false);
    }

    public void ExpBarSetTo80()
    {
        exp0BarSprite.SetActive(false);
        exp10BarSprite.SetActive(false);
        exp20BarSprite.SetActive(false);
        exp30BarSprite.SetActive(false);
        exp40BarSprite.SetActive(false);
        exp50BarSprite.SetActive(false);
        exp60BarSprite.SetActive(false);
        exp70BarSprite.SetActive(false);
        exp80BarSprite.SetActive(true);
        exp90BarSprite.SetActive(false);
        exp100BarSprite.SetActive(false);
    }

    public void ExpBarSetTo90()
    {
        exp0BarSprite.SetActive(false);
        exp10BarSprite.SetActive(false);
        exp20BarSprite.SetActive(false);
        exp30BarSprite.SetActive(false);
        exp40BarSprite.SetActive(false);
        exp50BarSprite.SetActive(false);
        exp60BarSprite.SetActive(false);
        exp70BarSprite.SetActive(false);
        exp80BarSprite.SetActive(false);
        exp90BarSprite.SetActive(true);
        exp100BarSprite.SetActive(false);
    }

    public void ExpBarSetTo100()
    {
        exp0BarSprite.SetActive(false);
        exp10BarSprite.SetActive(false);
        exp20BarSprite.SetActive(false);
        exp30BarSprite.SetActive(false);
        exp40BarSprite.SetActive(false);
        exp50BarSprite.SetActive(false);
        exp60BarSprite.SetActive(false);
        exp70BarSprite.SetActive(false);
        exp80BarSprite.SetActive(false);
        exp90BarSprite.SetActive(false);
        exp100BarSprite.SetActive(true);
    }

    public void StyleDisplaySetToFresh()
    {
        styleDisplayFresh.SetActive(true);
        styleDisplayCool.SetActive(false);
        styleDisplayOk.SetActive(false);
        styleDisplayMeh.SetActive(false);
        styleDisplayWack.SetActive(false);
    }

    public void StyleDisplaySetToCool()
    {
        styleDisplayFresh.SetActive(false);
        styleDisplayCool.SetActive(true);
        styleDisplayOk.SetActive(false);
        styleDisplayMeh.SetActive(false);
        styleDisplayWack.SetActive(false);
    }

    public void StyleDisplaySetToOk()
    {
        styleDisplayFresh.SetActive(false);
        styleDisplayCool.SetActive(false);
        styleDisplayOk.SetActive(true);
        styleDisplayMeh.SetActive(false);
        styleDisplayWack.SetActive(false);
    }

    public void StyleDisplaySetToMeh()
    {
        styleDisplayFresh.SetActive(true);
        styleDisplayCool.SetActive(false);
        styleDisplayOk.SetActive(false);
        styleDisplayMeh.SetActive(true);
        styleDisplayWack.SetActive(false);
    }

    public void StyleDisplaySetToWack()
    {
        styleDisplayFresh.SetActive(false);
        styleDisplayCool.SetActive(false);
        styleDisplayOk.SetActive(false);
        styleDisplayMeh.SetActive(false);
        styleDisplayWack.SetActive(true);
    }

    public void StopDisplayTimeAdded()
    {
        textTimeAddedFresh.text = ("");
        textTimeAddedCool.text = ("");
        textTimeAddedOk.text = ("");
        textTimeAddedMeh.text = ("");
        textTimeAddedWack.text = ("");
    }

    private IEnumerator TimeAddedDisplayProcess()
    {
        yield return new WaitForSeconds(timeAddedDisplayDuration);
        StopDisplayTimeAdded();
    }
}
