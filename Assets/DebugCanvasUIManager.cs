using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugCanvasUIManager : MonoBehaviour
{
    Ball activeBall;
    public GameObject ballObject;

    PlayerMovement activePlayer;
    public GameObject playerObject;

    public Text textBallXvel;
    public Text textBallYvel;
    public Text textBallLevel;
    public Text textBallExp;
    public Text textYinput;
    public Text textXinput;
    public Text textLightSwingInput;
    public Text textHeavySwingInput;

    // Start is called before the first frame update
    void Start()
    {
        ballObject = GameObject.Find("Ball");
        activeBall = ballObject.GetComponent<Ball>();

        playerObject = GameObject.Find("Player");
        activePlayer = playerObject.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        textBallXvel.text = "Ball X Vel: " + activeBall.rb.velocity.x.ToString();
        textBallYvel.text = "Ball Y Vel: " + activeBall.rb.velocity.y.ToString();
        textBallLevel.text = "Ball Lvl: " + activeBall.ballLevel.ToString();
        textBallExp.text = "Ball Exp: " + activeBall.ballExp.ToString();
        textYinput.text = "Y input: " + activePlayer.dirY.ToString();
        textXinput.text = "X input: " + activePlayer.dirX.ToString();

        if (Input.GetButtonDown("Fire2"))
            {
            textLightSwingInput.text = "Heavy Swing Input: Y";
            }
        else
        {
            textLightSwingInput.text = "Heavy Swing Input: N";
        }
    }

    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            textLightSwingInput.text = "Light Swing Input: True";
        }
        else
        {
            textLightSwingInput.text = "Light Swing Input:";
        }


        if (Input.GetButtonDown("Fire2"))
        {
            textHeavySwingInput.text = "Heavy Swing Input: True";
        }
        else
        {
            textHeavySwingInput.text = "Heavy Swing Input:";
        }
    }
}
