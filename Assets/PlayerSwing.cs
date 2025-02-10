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

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = gameObject.GetComponent<PlayerMovement>();
        //playerAnimation = gameObject.GetComponent<PlayerAnimation>(); //Add this in when animation script is ready

        isSwinging = false;
        swingDurationUpdateQued = false;
        stopHorizontalVel = false;
        stopHorizontalInput = false;
        stopJumpInput = false;
        isAirSwing = false;

        gameManagerObject = GameObject.Find("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();
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
            if (playerMovement.dirY >= playerMovement.verInputGatePositive)
            {
                isSwinging = true;
                UpdateHorizontalInputPrevention(true);
                UpdateHorizontalVelocityPrevention(true);
                UpdateJumpInputPrevention(true);
                //Swing light grounded up
                FetchSwingCollision(swingHitbox_LGU);
                currentSwingName = "L_Grounded_Up";
                isAirSwing = false;
                currentSwingDuration = swingCollision.swingTotalDuration;
            }
            else if (playerMovement.dirY <= playerMovement.verInputGateNegative)
            {
                isSwinging = true;
                UpdateHorizontalInputPrevention(true);
                UpdateHorizontalVelocityPrevention(true);
                UpdateJumpInputPrevention(true);
                //Swing light grounded dwon
                FetchSwingCollision(swingHitbox_LGD);
                currentSwingName = "L_Grounded_Down";
                isAirSwing = false;
                currentSwingDuration = swingCollision.swingTotalDuration;
            }
            else
            {
                isSwinging = true;
                UpdateHorizontalInputPrevention(true);
                UpdateHorizontalVelocityPrevention(true);
                UpdateJumpInputPrevention(true);
                //Swing light grounded middle
                FetchSwingCollision(swingHitbox_LGM);
                currentSwingName = "L_Grounded_Middle";
                isAirSwing = false;
                currentSwingDuration = swingCollision.swingTotalDuration;

            }

        }
        else if (Input.GetButtonDown("Fire2") && playerMovement.IsGrounded()) //Heavy Grounded Swings
        {
            if (playerMovement.dirY >= playerMovement.verInputGatePositive)
            {
                isSwinging = true;
                UpdateHorizontalInputPrevention(true);
                UpdateHorizontalVelocityPrevention(true);
                UpdateJumpInputPrevention(false);
                //Swing heavy grounded Up
                FetchSwingCollision(swingHitbox_HGU);
                currentSwingName = "H_Grounded_Up";
                isAirSwing = false;
                currentSwingDuration = swingCollision.swingTotalDuration;
            }
            else if (playerMovement.dirY <= playerMovement.verInputGateNegative)
            {
                isSwinging = true;
                UpdateHorizontalInputPrevention(true);
                UpdateHorizontalVelocityPrevention(true);
                UpdateJumpInputPrevention(true);
                //Swing heavy grounded Up
                FetchSwingCollision(swingHitbox_HGD);
                currentSwingName = "H_Grounded_Down";
                isAirSwing = false;
                currentSwingDuration = swingCollision.swingTotalDuration;
            }
            else
            {
                isSwinging = true;
                UpdateHorizontalInputPrevention(true);
                UpdateHorizontalVelocityPrevention(true);
                UpdateJumpInputPrevention(true);
                //Swing heavy grounded middle
                FetchSwingCollision(swingHitbox_HGM);
                currentSwingName = "H_Grounded_Middle";
                isAirSwing = false;
                currentSwingDuration = swingCollision.swingTotalDuration;
            }
        }
        else if (Input.GetButtonDown("Fire1") && playerMovement.IsGrounded() == false) //Light Airborne Swings
        {
            if (playerMovement.dirY >= playerMovement.verInputGatePositive)
            {
                isSwinging = true;
                UpdateHorizontalInputPrevention(false);
                UpdateHorizontalVelocityPrevention(true);
                UpdateJumpInputPrevention(true);
                //Swing light airborne down
                FetchSwingCollision(swingHitbox_LAU);
                currentSwingName = "L_Airborne_Up";
                isAirSwing = true;
                currentSwingDuration = swingCollision.swingTotalDuration;
            }
            else if (playerMovement.dirY <= playerMovement.verInputGateNegative)
            {
                isSwinging = true;
                UpdateHorizontalInputPrevention(false);
                UpdateHorizontalVelocityPrevention(true);
                UpdateJumpInputPrevention(true);
                //Swing light airborne down
                FetchSwingCollision(swingHitbox_LAD);
                currentSwingName = "L_Airborne_Down";
                isAirSwing = true;
                currentSwingDuration = swingCollision.swingTotalDuration;
            }
            else
            {
                isSwinging = true;
                UpdateHorizontalInputPrevention(false);
                UpdateHorizontalVelocityPrevention(true);
                UpdateJumpInputPrevention(true);
                //Swing light airborne middle
                FetchSwingCollision(swingHitbox_LAM);
                currentSwingName = "L_Airborne_Middle";
                isAirSwing = true;
                currentSwingDuration = swingCollision.swingTotalDuration;
            }
        }
        else if (Input.GetButtonDown("Fire2") && playerMovement.IsGrounded() == false) //Heavy Airborne Swings
        {
            if (playerMovement.dirY >= playerMovement.verInputGatePositive)
            {
                isSwinging = true;
                UpdateHorizontalInputPrevention(false);
                UpdateHorizontalVelocityPrevention(true);
                UpdateJumpInputPrevention(true);
                //Swing Heavy airborne up
                FetchSwingCollision(swingHitbox_HAU);
                currentSwingName = "H_Airborne_Up";
                isAirSwing = true;
                currentSwingDuration = swingCollision.swingTotalDuration;
            }
            else if (playerMovement.dirY <= playerMovement.verInputGateNegative)
            {
                isSwinging = true;
                UpdateHorizontalInputPrevention(false);
                UpdateHorizontalVelocityPrevention(true);
                UpdateJumpInputPrevention(true);
                //Swing Heavy airborne down
                FetchSwingCollision(swingHitbox_HAD);
                currentSwingName = "H_Airborne_Down";
                isAirSwing = true;
                currentSwingDuration = swingCollision.swingTotalDuration;
            }
            else
            {
                isSwinging = true;
                UpdateHorizontalInputPrevention(false);
                UpdateHorizontalVelocityPrevention(true);
                UpdateJumpInputPrevention(true);
                //Swing Heavy airborne middle
                FetchSwingCollision(swingHitbox_HAM);
                currentSwingName = "H_Airborne_Middle";
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

    public void UpdateJumpInputPrevention(bool isPrevented)
    {
        stopJumpInput = isPrevented;
    }

    public void FetchSwingCollision(GameObject swing)
    {
        GameObject swingCollisionObject = swing; //assigns the referenced game object as the swing collision object currently being used

        if (swingCollisionObject != null)
        {
            swingCollision = swingCollisionObject.GetComponent<SwingCollision>(); // Assigns SwingCollision class from the retrieved swing collision game object as the currently active swing collision
        }
    }

    public void EndSwing()
    {
        isSwinging = false;
        currentSwingDuration = 0; //ensures that Swing duration is set back to 0 if player jumps and press s button at the same time
        UpdateHorizontalInputPrevention(false);
        UpdateHorizontalVelocityPrevention(false);
        UpdateJumpInputPrevention(false);
        currentSwingName = "";
        isAirSwing = false;
        swingCollision.collidedBall = false; //signals that the swing is over and the swing hitbox can now collide with the ball again
        swingCollision = null;
    }
}
