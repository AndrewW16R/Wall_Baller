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
    public bool isAirSwing;

    //PlayerMovement class on Player GameObject
    PlayerMovement playerMovement;

    //PlayerAnimation playerAnimation; //Add this in when animation script is ready

    public GameObject swingHitbox_LGM;

    //SwingCollision class on the swing hitbox object of the currently active swing
    SwingCollision swingCollision; 

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
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSwing();
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
                Debug.Log("Middle Swing");
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
        else if (Input.GetButtonDown("Fire1") && playerMovement.IsGrounded() == false) //Light Airborne Swings
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
        else if (Input.GetButtonDown("Fire2") && playerMovement.IsGrounded() == false) //Heavy Airborne Swings
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
        swingCollision = null;
    }
}
