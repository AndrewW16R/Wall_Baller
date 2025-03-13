using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSwing : MonoBehaviour
{
    public bool isSwinging;
    public bool swingDurationUpdateQued;
    public bool stopHorizontalVel; //set to true when a move should stop/prevent horizontal vel
    public bool stopHorizontalInput; //set to true when a move should stop/prevent horizontal input
    public bool stopDashing; //set to true when a move should stop/prevent dashing
    public bool stopJumpInput; //set to true when a move should stop Jump/prevent input
    public bool canJumpCancel; //set to true when a move can be jump canceled
    public bool canDashCancel; //set to true when a move can be dash canceled
    public bool jumpCancelAvailable; //set to true when a jump cancel is available
    public bool dashCancelAvailable; //set to true when a jump cancel is available
    public string currentSwingName; //this variable is not currently utilized but could be implemented to indicate which attack is being used
    [SerializeField] private int currentSwingDuration;
    public bool isAirSwing;

    //PlayerMovement class on Player GameObject
    PlayerMovement playerMovement;

    //PlayerAnimation playerAnimation; //Add this in when animation script is ready

    public GameObject swingHitbox_LGM;
    public GameObject swingHitbox_LGU;
    public GameObject swingHitbox_LGD;

    public GameObject swingHitbox_HGM;
    public GameObject swingHitbox_HGU;
    public GameObject swingHitbox_HGD;

    public GameObject swingHitbox_LAM;
    public GameObject swingHitbox_LAU;
    public GameObject swingHitbox_LAD;

    public GameObject swingHitbox_HAM;
    public GameObject swingHitbox_HAU;
    public GameObject swingHitbox_HAD;

    //SwingCollision class on the swing hitbox object of the currently active swing
    SwingCollision swingCollision;

    private GameObject gameManagerObject;
    private GameManager gameManager;

    public UnityEvent onSwingCancelEvent;


    // Start is called before the first frame update
    void Start()
    {
        playerMovement = gameObject.GetComponent<PlayerMovement>();

        isSwinging = false;
        swingDurationUpdateQued = false;
        stopHorizontalVel = false;
        stopHorizontalInput = false;
        stopDashing = false;
        stopJumpInput = false;
        isAirSwing = false;
        canJumpCancel = false;
        canDashCancel = false;
        jumpCancelAvailable = false;
        dashCancelAvailable = false;


        gameManagerObject = GameObject.Find("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();

        if (onSwingCancelEvent == null)
        {
            onSwingCancelEvent = new UnityEvent();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGamePaused == false && gameManager.isGameOver == false)
        {
            UpdateSwing();
        }
    }

    private void FixedUpdate()
    {
        UpdateSwingHitbox();
        UpdateSwingDuration();
    }

    private void UpdateSwing()
    {
        if (isSwinging == true)
        {
            return;
        }
        else if (Input.GetButtonDown("Fire1") && playerMovement.IsGrounded()) //Light grounded swings
        {
            if (playerMovement.dirY >= playerMovement.verInputGatePositive) //Light Grounded up
            {
                isSwinging = true;
                UpdateHorizontalInputPrevention(true);
                UpdateHorizontalVelocityPrevention(true);
                UpdateDashingPrevention(true);
                UpdateJumpInputPrevention(true);
                UpdateJumpCancelStatus(true);
                UpdateDashCancelStatus(true);
                //Swing light grounded up
                currentSwingName = "L_Grounded_Up";
                FetchSwingCollision(swingHitbox_LGU);
                isAirSwing = false;
                currentSwingDuration = swingCollision.swingTotalDuration;
            }
            else if (playerMovement.dirY <= playerMovement.verInputGateNegative) //Light Grounded Down
            {
                isSwinging = true;
                UpdateHorizontalInputPrevention(true);
                UpdateHorizontalVelocityPrevention(true);
                UpdateDashingPrevention(true);
                UpdateJumpInputPrevention(true);
                UpdateJumpCancelStatus(false);
                UpdateDashCancelStatus(true);
                //Swing light grounded down
                currentSwingName = "L_Grounded_Down";
                FetchSwingCollision(swingHitbox_LGD);
                isAirSwing = false;
                currentSwingDuration = swingCollision.swingTotalDuration;
            }
            else //Light Grounded Middle
            {
                isSwinging = true;
                UpdateHorizontalInputPrevention(true);
                UpdateHorizontalVelocityPrevention(true);
                UpdateDashingPrevention(true);
                UpdateJumpInputPrevention(true);
                UpdateJumpCancelStatus(false);
                UpdateDashCancelStatus(true);
                //Swing light grounded middle
                currentSwingName = "L_Grounded_Middle";
                FetchSwingCollision(swingHitbox_LGM);
                isAirSwing = false;
                currentSwingDuration = swingCollision.swingTotalDuration;

            }

        }
        else if (Input.GetButtonDown("Fire2") && playerMovement.IsGrounded()) //Heavy Grounded Swings
        {
            if (playerMovement.dirY >= playerMovement.verInputGatePositive) //Heavy Grounded Up
            {
                isSwinging = true;
                UpdateHorizontalInputPrevention(true);
                UpdateHorizontalVelocityPrevention(true);
                UpdateDashingPrevention(true);
                UpdateJumpInputPrevention(true);
                UpdateJumpCancelStatus(true);
                UpdateDashCancelStatus(false);
                //Swing heavy grounded Up
                currentSwingName = "H_Grounded_Up";
                FetchSwingCollision(swingHitbox_HGU);
                isAirSwing = false;
                currentSwingDuration = swingCollision.swingTotalDuration;
            }
            else if (playerMovement.dirY <= playerMovement.verInputGateNegative) //Heavy Grounded Down
            {
                isSwinging = true;
                UpdateHorizontalInputPrevention(true);
                UpdateHorizontalVelocityPrevention(true);
                UpdateDashingPrevention(true);
                UpdateJumpInputPrevention(true);
                UpdateJumpCancelStatus(false);
                UpdateDashCancelStatus(false);
                //Swing heavy grounded Down
                currentSwingName = "H_Grounded_Down";
                FetchSwingCollision(swingHitbox_HGD);
                isAirSwing = false;
                currentSwingDuration = swingCollision.swingTotalDuration;
            }
            else //Heavy Grounded Middle
            {
                isSwinging = true;
                UpdateHorizontalInputPrevention(true);
                UpdateHorizontalVelocityPrevention(true);
                UpdateDashingPrevention(true);
                UpdateJumpInputPrevention(true);
                UpdateJumpCancelStatus(false);
                UpdateDashCancelStatus(false);
                //Swing heavy grounded middle
                currentSwingName = "H_Grounded_Middle";
                FetchSwingCollision(swingHitbox_HGM);
                isAirSwing = false;
                currentSwingDuration = swingCollision.swingTotalDuration;
            }
        }
        else if (Input.GetButtonDown("Fire1") && playerMovement.IsGrounded() == false) //Light Airborne Swings
        {
            if (playerMovement.dirY >= playerMovement.verInputGatePositive) //Light Airborne Up
            {
                isSwinging = true;
                UpdateHorizontalInputPrevention(false);
                UpdateHorizontalVelocityPrevention(false);
                UpdateDashingPrevention(true);
                UpdateJumpInputPrevention(true);
                UpdateJumpCancelStatus(true);
                UpdateDashCancelStatus(true);
                //Swing light airborne down
                currentSwingName = "L_Airborne_Up";
                FetchSwingCollision(swingHitbox_LAU);
                isAirSwing = true;
                currentSwingDuration = swingCollision.swingTotalDuration;
            }
            else if (playerMovement.dirY <= playerMovement.verInputGateNegative) //Light Airborne Down
            {
                isSwinging = true;
                UpdateHorizontalInputPrevention(false);
                UpdateHorizontalVelocityPrevention(false);
                UpdateDashingPrevention(true);
                UpdateJumpInputPrevention(true);
                UpdateJumpCancelStatus(false);
                UpdateDashCancelStatus(true);
                //Swing light airborne down
                currentSwingName = "L_Airborne_Down";
                FetchSwingCollision(swingHitbox_LAD);
                isAirSwing = true;
                currentSwingDuration = swingCollision.swingTotalDuration;
            }
            else //Light Airborne Middle
            {
                isSwinging = true;
                UpdateHorizontalInputPrevention(false);
                UpdateHorizontalVelocityPrevention(false);
                UpdateDashingPrevention(true);
                UpdateJumpInputPrevention(true);
                UpdateJumpCancelStatus(false);
                UpdateDashCancelStatus(true);
                //Swing light airborne middle
                currentSwingName = "L_Airborne_Middle";
                FetchSwingCollision(swingHitbox_LAM);
                isAirSwing = true;
                currentSwingDuration = swingCollision.swingTotalDuration;
            }
        }
        else if (Input.GetButtonDown("Fire2") && playerMovement.IsGrounded() == false) //Heavy Airborne Swings
        {
            if (playerMovement.dirY >= playerMovement.verInputGatePositive) //Heavy Airborne Up
            {
                isSwinging = true;
                UpdateHorizontalInputPrevention(false);
                UpdateHorizontalVelocityPrevention(false);
                UpdateDashingPrevention(true);
                UpdateJumpInputPrevention(true);
                UpdateJumpCancelStatus(true);
                UpdateDashCancelStatus(false);
                //Swing Heavy airborne up
                currentSwingName = "H_Airborne_Up";
                FetchSwingCollision(swingHitbox_HAU);
                isAirSwing = true;
                currentSwingDuration = swingCollision.swingTotalDuration;
            }
            else if (playerMovement.dirY <= playerMovement.verInputGateNegative) //Heavy Airborne Down
            {
                isSwinging = true;
                UpdateHorizontalInputPrevention(false);
                UpdateHorizontalVelocityPrevention(false);
                UpdateDashingPrevention(true);
                UpdateJumpInputPrevention(true);
                UpdateJumpCancelStatus(false);
                UpdateDashCancelStatus(false);
                //Swing Heavy airborne down
                currentSwingName = "H_Airborne_Down";
                FetchSwingCollision(swingHitbox_HAD);
                isAirSwing = true;
                currentSwingDuration = swingCollision.swingTotalDuration;
            }
            else //Heavy Airborne Middle
            {
                isSwinging = true;
                UpdateHorizontalInputPrevention(false);
                UpdateHorizontalVelocityPrevention(false);
                UpdateDashingPrevention(true);
                UpdateJumpInputPrevention(true);
                UpdateJumpCancelStatus(false);
                UpdateDashCancelStatus(false);
                //Swing Heavy airborne middle
                currentSwingName = "H_Airborne_Middle";
                FetchSwingCollision(swingHitbox_HAM);
                isAirSwing = true;
                currentSwingDuration = swingCollision.swingTotalDuration;
            }
        }
    }

    private void UpdateSwingHitbox()
    {
      /*
        if(isAirSwing = true && playerMovement.IsGrounded() == true)
        {
            EndSwing();
        }
        */


        if (isAirSwing == false)
        {
            if (currentSwingName == "L_Grounded_Middle")
            {
                if (currentSwingDuration <= (swingCollision.swingTotalDuration - swingCollision.swingStartupDuration) && (currentSwingDuration > swingCollision.swingEndlagDuration))
                {
                    swingHitbox_LGM.gameObject.SetActive(true);
                }
                else
                {
                    swingHitbox_LGM.gameObject.SetActive(false);
                }
            }
            else if (currentSwingName == "L_Grounded_Up")
            {
                if (currentSwingDuration <= (swingCollision.swingTotalDuration - swingCollision.swingStartupDuration) && (currentSwingDuration > swingCollision.swingEndlagDuration))
                {
                    swingHitbox_LGU.gameObject.SetActive(true);
                }
                else
                {
                    swingHitbox_LGU.gameObject.SetActive(false);
                }
            }
            else if (currentSwingName == "L_Grounded_Down")
            {
                if (currentSwingDuration <= (swingCollision.swingTotalDuration - swingCollision.swingStartupDuration) && (currentSwingDuration > swingCollision.swingEndlagDuration))
                {
                    swingHitbox_LGD.gameObject.SetActive(true);
                }
                else
                {
                    swingHitbox_LGD.gameObject.SetActive(false);
                }
            }
            else if (currentSwingName == "H_Grounded_Middle")
            {
                if (currentSwingDuration <= (swingCollision.swingTotalDuration - swingCollision.swingStartupDuration) && (currentSwingDuration > swingCollision.swingEndlagDuration))
                {
                    swingHitbox_HGM.gameObject.SetActive(true);
                }
                else
                {
                    swingHitbox_HGM.gameObject.SetActive(false);
                }
            }
            else if (currentSwingName == "H_Grounded_Up")
            {
                if (currentSwingDuration <= (swingCollision.swingTotalDuration - swingCollision.swingStartupDuration) && (currentSwingDuration > swingCollision.swingEndlagDuration)) //if swing is currently within its active frames
                {
                    swingHitbox_HGU.gameObject.SetActive(true); //set corresponding hitbox to active
                }
                else
                {
                    swingHitbox_HGU.gameObject.SetActive(false); //turns off corresponding hitbox
                }
            }
            else if (currentSwingName == "H_Grounded_Down")
            {
                if (currentSwingDuration <= (swingCollision.swingTotalDuration - swingCollision.swingStartupDuration) && (currentSwingDuration > swingCollision.swingEndlagDuration)) //if swing is currently within its active frames
                {
                    swingHitbox_HGD.gameObject.SetActive(true); //set corresponding hitbox to active
                }
                else
                {
                    swingHitbox_HGD.gameObject.SetActive(false); //turns off corresponding hitbox
                }
            }
        }

        if (isAirSwing == true)
        {
            if (currentSwingName == "L_Airborne_Middle")
            {
                if (currentSwingDuration <= (swingCollision.swingTotalDuration - swingCollision.swingStartupDuration) && (currentSwingDuration > swingCollision.swingEndlagDuration))
                {
                    swingHitbox_LAM.gameObject.SetActive(true);
                }
                else
                {
                    swingHitbox_LAM.gameObject.SetActive(false);
                }
            }
            else if (currentSwingName == "L_Airborne_Up")
            {
                if (currentSwingDuration <= (swingCollision.swingTotalDuration - swingCollision.swingStartupDuration) && (currentSwingDuration > swingCollision.swingEndlagDuration))
                {
                    swingHitbox_LAU.gameObject.SetActive(true);
                }
                else
                {
                    swingHitbox_LAU.gameObject.SetActive(false);
                }
            }
            else if (currentSwingName == "L_Airborne_Down")
            {
                if (currentSwingDuration <= (swingCollision.swingTotalDuration - swingCollision.swingStartupDuration) && (currentSwingDuration > swingCollision.swingEndlagDuration))
                {
                    swingHitbox_LAD.gameObject.SetActive(true);
                }
                else
                {
                    swingHitbox_LAD.gameObject.SetActive(false);
                }
            }
            else if (currentSwingName == "H_Airborne_Middle")
            {
                if (currentSwingDuration <= (swingCollision.swingTotalDuration - swingCollision.swingStartupDuration) && (currentSwingDuration > swingCollision.swingEndlagDuration))
                {
                    swingHitbox_HAM.gameObject.SetActive(true);
                }
                else
                {
                    swingHitbox_HAM.gameObject.SetActive(false);
                }
            }
            else if (currentSwingName == "H_Airborne_Up")
            {
                if (currentSwingDuration <= (swingCollision.swingTotalDuration - swingCollision.swingStartupDuration) && (currentSwingDuration > swingCollision.swingEndlagDuration)) //if swing is currently within its active frames
                {
                    swingHitbox_HAU.gameObject.SetActive(true); //set corresponding hitbox to active
                }
                else
                {
                    swingHitbox_HAU.gameObject.SetActive(false); //turns off corresponding hitbox
                }
            }
            else if (currentSwingName == "H_Airborne_Down")
            {
                if (currentSwingDuration <= (swingCollision.swingTotalDuration - swingCollision.swingStartupDuration) && (currentSwingDuration > swingCollision.swingEndlagDuration)) //if swing is currently within its active frames
                {
                    swingHitbox_HAD.gameObject.SetActive(true); //set corresponding hitbox to active
                }
                else
                {
                    swingHitbox_HAD.gameObject.SetActive(false); //turns off corresponding hitbox
                }
            }
        }
    }

    private void UpdateSwingDuration()
    {
        if  (currentSwingDuration > 0)
        {
            if(playerMovement.isDashing == true)
            {
                swingDurationUpdateQued = false;
                EndSwing();
            }

            if (isAirSwing == false && playerMovement.IsGrounded() || isAirSwing == true && playerMovement.IsGrounded()==false)
            swingDurationUpdateQued = true;
        }
        else
        {
            swingDurationUpdateQued = false;
            if (isSwinging == true)
            {
                EndSwing();
            }
        }

        if (swingDurationUpdateQued == true)
        {
            currentSwingDuration = currentSwingDuration - 1;
        }
    }

    public void UpdateHorizontalInputPrevention(bool isPrevented)
    {
        stopHorizontalInput = isPrevented;
    }

    public void UpdateHorizontalVelocityPrevention(bool isPrevented)
    {
        stopHorizontalVel = isPrevented;
    }

    public void UpdateDashingPrevention(bool isPrevented)
    {
        stopDashing = isPrevented;
    }

    public void UpdateJumpInputPrevention(bool isPrevented)
    {
        stopJumpInput = isPrevented;
    }

    public void UpdateJumpCancelStatus(bool isAllowed)
    {
        canJumpCancel = isAllowed;
    }

    public void UpdateJumpCancelAvailability(bool isAvailable) //A jump cancel can only be used if the swing has collided with the ball
    {
        jumpCancelAvailable = isAvailable;
    }

    public void UpdateDashCancelStatus(bool isAllowed)
    {
        canDashCancel = isAllowed;
    }

    public void UpdateDashCancelAvailability(bool isAvailable) //A dash cancel can only be used if the swing has collided with the ball
    {
        dashCancelAvailable = isAvailable;
    }

    public void FetchSwingCollision(GameObject swing)
    {
        GameObject swingCollisionObject = swing; //assigns the referenced game object as the swing collision object currently being used

        if (swingCollisionObject != null)
        {
            swingCollision = swingCollisionObject.GetComponent<SwingCollision>(); // Assigns SwingCollision class from the retrieved swing collision game object as the currently active swing collision
        }
    }


    public void SwingCancel()
    {
        if (isAirSwing == false)
        {
            if (currentSwingName == "L_Grounded_Middle")
            {
                swingHitbox_LGM.gameObject.SetActive(false);
            }
            else if (currentSwingName == "L_Grounded_Up")
            {
                swingHitbox_LGU.gameObject.SetActive(false);
            }
            else if (currentSwingName == "L_Grounded_Down")
            {
                swingHitbox_LGD.gameObject.SetActive(false);
            }
            else if (currentSwingName == "H_Grounded_Middle")
            {
                swingHitbox_HGM.gameObject.SetActive(false);
            }
            else if (currentSwingName == "H_Grounded_Up")
            {
                swingHitbox_HGU.gameObject.SetActive(false);
            }
            else if (currentSwingName == "H_Grounded_Down")
            {
                swingHitbox_HGD.gameObject.SetActive(false);
            }

        }
        
        if(isAirSwing == true)
        {
            if (currentSwingName == "L_Airborne_Middle")
            {
                swingHitbox_LAM.gameObject.SetActive(false);
            }
            else if (currentSwingName == "L_Airborne_Up")
            {
                swingHitbox_LAU.gameObject.SetActive(false);
            }
            else if (currentSwingName == "L_Airborne_Down")
            {
                swingHitbox_LAD.gameObject.SetActive(false);
            }
            else if (currentSwingName == "H_Airborne_Middle")
            {
                swingHitbox_HAM.gameObject.SetActive(false);
            }
            else if (currentSwingName == "H_Airborne_Up")
            {
                swingHitbox_HAU.gameObject.SetActive(false);
            }
            else if (currentSwingName == "H_Airborne_Down")
            {
                swingHitbox_HAD.gameObject.SetActive(false);
            }
        }
        onSwingCancelEvent.Invoke();
        EndSwing();

    }

    public void EndSwing()
    {
        isSwinging = false;
        currentSwingDuration = 0; //ensures that Swing duration is set back to 0 if player jumps and press s button at the same time
        UpdateHorizontalInputPrevention(false);
        UpdateHorizontalVelocityPrevention(false);
        UpdateDashingPrevention(false);
        UpdateJumpInputPrevention(false);
        UpdateJumpCancelStatus(false);
        UpdateDashCancelStatus(false);
        UpdateJumpCancelAvailability(false);
        UpdateDashCancelAvailability(false);
        currentSwingName = "";
        isAirSwing = false;
        swingCollision.collidedBall = false; //signals that the swing is over and the swing hitbox can now collide with the ball again
        swingCollision = null;
    }
}
