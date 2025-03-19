using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private BoxCollider2D coll;

    
    public float dirX;//Left/Right input
    public float dirY;//Up/Down input

    [SerializeField] private float movementSpeed;//Horizontal movement speed
    [SerializeField] private float jumpStrength;//How strong/high the player character's first jump is
    [SerializeField] private float doubleJumpStrength;//How strong/high the player character's double jump is
    [SerializeField] private float highJumpStrength;//How strong/high the player character's high jump is

    [SerializeField] private LayerMask jumpableGround;//Layer of gameobjects which the player can jump/walk on
    [SerializeField] private LayerMask Barrier;//Layer of the gameobjects the blocks the player's movement, but allows the ball to pass
    [SerializeField] private LayerMask Glass;//Layer of the glass gameobject which loses health upon colliding with the ball

    public PlayerSwing playerSwing;

    
    [SerializeField] public int jumpsAvailable = 2;//How many jumps the player can do before needing to be grounded again
    public int maxJumps;//Player is assigned the number of Jumps available from frame 1, used to determine how many jumps the player gets when jumps refresh  
    private bool initialJumpUsed = false;//Has the player used their first jump?

    
    private float initialGravity;//The initial intensity of gravity which acts upon the player character
    public bool fastFalling = false; //Is the process of fast falling currently taking place?  
    [SerializeField] public float fastfallGravMultiplier; //How much the default gravity is multiplied by within the process of fast falling


    [HideInInspector] public bool isDashing = false;//Is the player currently dashing?
    [SerializeField] public int dashesAvailable;//The current amount of Dashes available
    private int maxDashes;//the maximum amount of dashes that can be stored at once
    private bool dashRefilling = false; //Is the player currently refilling the dash meter for a dash?
    [SerializeField] private float dashDuration;//How long the dash lasts for
    [SerializeField] private float dashWallCheckfrequency;//How often neighboring walls are checked for while dashing. Used to help prevent the player from clipping into walls from dashing
    [SerializeField] private float dashProgress;//How much the current dash has progressed through its duration
    [SerializeField] private float dashSpeed;//How much speed the dash has
    [SerializeField] private float timeToRefillOneDash;//How long it takes for a single dash to fully be refilled/replenished
    [SerializeField] private bool spendDash;//Indicates if a dash will be spent after inputting a dash. This is used for situations where the player's dash prematurely stops very early on due to a wall blocking the way
    public float dashDir; //Stores value of which driection player is air dashing to inform animator which air dash animation to play
    public bool isAirDash = false;//Is the current dash an airdash?

    [SerializeField] private float heldDirection;//Stores the held horizontal direction

    public float verInputGatePositive = 0.35f; //How far up the vertical input needs to be counted as an "Up" input
    public float verInputGateNegative = 0.35f; //How far down the vertical input needs to be counted as an "Down" input

    public string movementType;

    private GameObject gameManagerObject;
    private GameManager gameManager;

    public UnityEvent onJumpEvent;
    public UnityEvent onDoubleJumpEvent;
    public UnityEvent onHighJumpEvent;
    public UnityEvent onDashEvent;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();

        maxDashes = dashesAvailable;
        maxJumps = jumpsAvailable;
        initialGravity = rb.gravityScale;

        dashRefilling = false;

        gameManagerObject = GameObject.Find("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();

        spendDash = true;

        if (onJumpEvent == null)
        {
            onJumpEvent = new UnityEvent();
        }

        if (onDoubleJumpEvent == null)
        {
            onDoubleJumpEvent = new UnityEvent();
        }

        if (onHighJumpEvent == null)
        {
            onHighJumpEvent = new UnityEvent();
        }

        if (onDashEvent == null)
        {
            onDashEvent = new UnityEvent();
        }

        if(movementType == null || movementType == "")//failsafe incase a movement type is not set
        {
            movementType = "Stable";
        }
    }

    // Update is called once per frame
    void Update()
    {

        dirY = Input.GetAxisRaw("Vertical");

        //Walking movement
        if (playerSwing.stopHorizontalInput == true)
        {
            dirX = 0;
        }
        else
        {
            dirX = Input.GetAxisRaw("Horizontal");
        }

       


        //Checks for jump input and executes jump in under proper conditions
        if (gameManager.isGamePaused == false && gameManager.isGameOver == false)
        {
            UpdateJump();

            //Refills player's available dashes
            if (dashesAvailable < maxDashes && dashRefilling == false)
            {
                StartCoroutine(RefillDash(timeToRefillOneDash));
                
            }

            UpdateDash();
        }
    }

    void FixedUpdate()
    {
        if (isDashing == false && playerSwing.stopHorizontalInput == false && playerSwing.stopHorizontalVel == false)//updates the player's horizontal movement
        {
            rb.velocity = new Vector2(dirX * movementSpeed, rb.velocity.y);
        }

        if (dirX > 0)//held direction right
        {
            heldDirection = 1;
        }
        else if (dirX < 0)//held direction left
        {
            heldDirection = -1;
        }
        else if (dirX == 0)//held direction neutral
        {
            heldDirection = 0;
        }

        if(playerSwing.stopHorizontalVel == true && movementType == "Stable")//Stops sliding momentum is the  movement type PlayerPref is set to "Stable"
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }


        if (gameManager.isGamePaused == false && gameManager.isGameOver == false)//Dashes will not refill while the game is paused
        {
           
            //Refills player's available dashes
            if (dashesAvailable < maxDashes && dashRefilling == false)
            {
                StartCoroutine(RefillDash(timeToRefillOneDash));

            }
        }

    }

    private void UpdateJump()
    {
        //Checks if player is grounded
        if (IsGrounded())
        {
            rb.gravityScale = initialGravity;
            fastFalling = false;
            jumpsAvailable = maxJumps;
            initialJumpUsed = false;
        }

        if (gameManager.isGamePaused == false && gameManager.isGameOver == false)//If game is not paused
        {
            if(Input.GetButtonDown("Jump") && playerSwing.canJumpCancel == true && playerSwing.jumpCancelAvailable == true && playerSwing.isSwinging)//If the player inputs jump during a jump-cancelable swing that has already collided with the ball. A jump cancel occurs
            {
                playerSwing.UpdateJumpInputPrevention(false);//Allow for jump inputs
                playerSwing.SwingCancel();//cancel the current swing
            }


            if (Input.GetButtonDown("Jump") && IsGrounded() && dirY <= verInputGateNegative && playerSwing.stopJumpInput == false && gameManager.isGamePaused == false)//If player jumps on ground while holding down, perform a high jump
            {
                rb.velocity = new Vector2(rb.velocity.x, highJumpStrength);
                jumpsAvailable = 0;//Player can not double jump from a high jump
                onHighJumpEvent.Invoke();//used to activate SFX
                initialJumpUsed = true;

            }
            else if (Input.GetButtonDown("Jump") && IsGrounded() && playerSwing.stopJumpInput == false && gameManager.isGamePaused == false) //Player uses first jump
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
                jumpsAvailable = jumpsAvailable - 1;
                onJumpEvent.Invoke();
                initialJumpUsed = true;

            }//if player is already not grounded before the intial jump is used up, both the intial jump and the first addition jump are used up.
            else if (Input.GetButtonDown("Jump") && initialJumpUsed == false && jumpsAvailable > 0 && !IsGrounded() && !IsAgainstAboveWall() && playerSwing.stopJumpInput == false && gameManager.isGamePaused == false)
            {
                rb.gravityScale = initialGravity;
                fastFalling = false;
                rb.velocity = new Vector2(rb.velocity.x, doubleJumpStrength);
                jumpsAvailable = jumpsAvailable - 2;
                onDoubleJumpEvent.Invoke();
                initialJumpUsed = true;

            } 
            else if (Input.GetButtonDown("Jump") && jumpsAvailable > 0 && !IsGrounded() && !IsAgainstAboveWall() && playerSwing.stopJumpInput == false && gameManager.isGamePaused == false)//When double jump is used
            {
                rb.gravityScale = initialGravity;
                fastFalling = false;
                rb.velocity = new Vector2(rb.velocity.x, doubleJumpStrength);
                onDoubleJumpEvent.Invoke();
                jumpsAvailable = jumpsAvailable - 1;
            }
        }

        if (rb.velocity.y < -.1f && !IsGrounded() && fastFalling == false)//Fast fall multiplier is applied to the strength of gravity if the player charact is falling downwards
        {
            rb.gravityScale = rb.gravityScale * fastfallGravMultiplier;
            fastFalling = true;
        }
    }

   
   private void UpdateDash()
    {

        if (Input.GetButtonDown("Dash") && playerSwing.canDashCancel == true && playerSwing.dashCancelAvailable == true && playerSwing.isSwinging)//If the player inputs dash during a dash-cancelable swing that has already collided with the ball. A dash cancel occurs
        {
            playerSwing.UpdateDashingPrevention(false);
            playerSwing.SwingCancel();
        }

        if (Input.GetButtonDown("Dash") && isDashing == false && dashesAvailable > 0 && playerSwing.stopDashing == false && playerSwing.stopHorizontalVel == false)//Start dash if the button is inputed, the player is not already dashing, dashing and horizontal movement are not being prevented
        {


            if (IsGrounded())//if the dash is grounded
            {
                if (heldDirection >= 0)
                {
                    dashDir = 1;
                    isAirDash = false;
                    onDashEvent.Invoke();
                    StartCoroutine(Dash(1.0f));
                }
                else if (heldDirection < 0)
                {
                    dashDir = -1;
                    isAirDash = false;
                    onDashEvent.Invoke();
                    StartCoroutine(Dash(heldDirection));
                }
                else if (dirX == 0)
                {
                    dashDir = 1;
                    isAirDash = true;
                    onDashEvent.Invoke();
                    StartCoroutine(Dash(1.0f));
                }

            }

            if (IsGrounded() == false)//if the dash is airborne
            {
                if (heldDirection >= 0 )
                {
                    dashDir = 1;
                    isAirDash = true;
                    onDashEvent.Invoke();
                    StartCoroutine(Dash(1.0f));
                }
                else if (heldDirection < 0)
                {
                    dashDir = -1;
                    isAirDash = true;
                    onDashEvent.Invoke();
                    StartCoroutine(Dash(heldDirection));
                }
                else if (dirX == 0)
                {
                    dashDir = 1;
                    isAirDash = true;
                    onDashEvent.Invoke();
                    StartCoroutine(Dash(1.0f));
                }

            }

        }
    }


    public bool IsGrounded()//Checks if the player is on the ground
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    public bool IsAgainstAboveWall()//Checks if the player has a wall close above them
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.up, .2f, jumpableGround);
    }

    public bool IsAgainstForwardWall()//Checks if the player has a wall close in front of them
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.right, .3f, Barrier);
    }

    public bool IsAgainstBackWall()//Checks if the player has a wall close in behind them
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.left, .3f, Glass);
    }


    private IEnumerator Dash(float direction)//method that initiates a dash
    {
        isDashing = true;
        //Debug.Log("dash detected");
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(new Vector2(dashSpeed * direction, 0f), ForceMode2D.Impulse);
        //below if statement implemented since above Added dash speed to move speed. It felt pretty good though

        /*
        if (rb.velocity.x != dashSpeed * direction)
        {
            rb.velocity = new Vector2(dashSpeed * direction, 0f);
        }
        */

        rb.gravityScale = 0;//player is not affected by gravity during a dash

        dashProgress = 0.0f;

            for(dashProgress=0;dashProgress<=dashDuration;dashProgress=dashProgress+dashWallCheckfrequency)//dash continues for as long as the assigned dash duration. Periodically, depending on the dashWallCheckFrequency, nearby walls are check for during the dash to prematurely end the dash, preventing the player from clipping into the wall
        {
            if(dashDir == 1)
            {
                if(IsAgainstForwardWall())
                {
                    if(dashProgress==0)
                    {
                        spendDash = false; //dash will not be spent if player starts a dash right next to the wall they would be dashing torwards 
                    }
                    rb.velocity = new Vector2(0, rb.velocity.y);
                    dashProgress = dashDuration;
                }
                else
                {
                    yield return new WaitForSeconds(dashWallCheckfrequency);
                }
            }
            else if(dashDir==-1)
            {
                if(IsAgainstBackWall())
                {
                    if (dashProgress == 0)
                    {
                        spendDash = false; //dash will not be spent if player starts a dash right next to the wall they would be dashing torwards 
                    }
                    //Debug.Log("Cancel Dash");
                    dashProgress = dashDuration;
                }
                else
                {
                    yield return new WaitForSeconds(dashWallCheckfrequency);
                }
            }
        }

        isDashing = false;
        rb.gravityScale = initialGravity;

        if(spendDash == true)
        {
            dashesAvailable = dashesAvailable - 1;
        }

        spendDash = true;

    }

    //Refills players available dashes
    private IEnumerator RefillDash(float amount)//Method that actively refills dashing meter
    {
        dashRefilling = true;
        yield return new WaitForSeconds(timeToRefillOneDash);
        dashRefilling = false;
        dashesAvailable = dashesAvailable + 1;
        rb.velocity = new Vector2(dirX * movementSpeed, rb.velocity.y);
    }

}
