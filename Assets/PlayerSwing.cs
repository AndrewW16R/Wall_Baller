using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwing : MonoBehaviour
{
    public bool isSwinging;
    public bool swingDurationUpdateQued;
    public bool stopHorizontalVel; //set to true when a move should stop/prevent horizontal vel
    public bool stopHorizontalInput; //set to true when a move should stop/prevent horizontal input
    public bool stopJumpInput; //set to true when a move should stop Jump/prevent input
    private string currentSwingName; //this variable is not currently utilized but could be implemented to indicate which attack is being used
    [SerializeField] private int currentSwingDuration;

    //PlayerMovement class on Player GameObject
    PlayerMovement playerMovement;

    //PlayerAnimation playerAnimation; //Add this in when animation script is ready

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = gameObject.GetComponent<PlayerMovement>();
        //playerAnimation = gameObject.GetComponent<PlayerAnimation>(); //Add this in when animation script is ready

        isSwinging = false;
        swingDurationUpdateQued = false;
        stopHorizontalVel = false;
        stopHorizontalInput = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSwing();
    }

    private void UpdateSwing()
    {
        if (isSwinging == true)
        {
            return;
        }
        else if (Input.GetButtonDown("Fire1") && playerMovement.IsGrounded()) //Light grounded swings
        {
            if (playerMovement.dirY >= playerMovement.verInputGatePositive)
            {
                //Swing light grounded up
                currentSwingName = "L_Grounded_Up";
            }
            else if (playerMovement.dirY <= playerMovement.verInputGateNegative)
            {
                //Swing light grounded down
                currentSwingName = "L_Grounded_Down";
            }
            else
            {
                //Swing light grounded middle
                currentSwingName = "L_Grounded_Middle";
            }
        }
        else if (Input.GetButtonDown("Fire2") && playerMovement.IsGrounded())
        {
            if (playerMovement.dirY >= playerMovement.verInputGatePositive)
            {
                //Swing Heavy grounded up
                currentSwingName = "H_Grounded_Up";
            }
            else if (playerMovement.dirY <= playerMovement.verInputGateNegative)
            {
                //Swing Heavy grounded down
                currentSwingName = "H_Grounded_Down";
            }
            else
            {
                //Swing Heavy grounded middle
                currentSwingName = "H_Grounded_Middle";
            }
        }
        else if (Input.GetButtonDown("Fire1") && playerMovement.IsGrounded() == false)
        {
            if (playerMovement.dirY >= playerMovement.verInputGatePositive)
            {
                //Swing light air up
                currentSwingName = "L_Airborne_Up";
            }
            else if (playerMovement.dirY <= playerMovement.verInputGateNegative)
            {
                //Swing light air down
                currentSwingName = "L_Airborne_Down";
            }
            else
            {
                //Swing light air middle
                currentSwingName = "L_Airborne_Middle";
            }
        }
        else if (Input.GetButtonDown("Fire2") && playerMovement.IsGrounded() == false)
        {
            if (playerMovement.dirY >= playerMovement.verInputGatePositive)
            {
                //Swing heavy air up
                currentSwingName = "H_Airborne_Up";
            }
            else if (playerMovement.dirY <= playerMovement.verInputGateNegative)
            {
                //Swing heavy air down
                currentSwingName = "H_Airborne_Down";
            }
            else
            {
                //Swing heavy air middle
                currentSwingName = "H_Airborne_Middle";
            }
        }
    }

    private void UpdateSwingHitbox()
    {

    }

    private void UpdateSwingDuration()
    {

    }
}
