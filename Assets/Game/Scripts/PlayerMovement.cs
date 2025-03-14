using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private BoxCollider2D coll;

    //left/right input
    public float dirX;
    public float dirY;

    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpStrength;
    [SerializeField] private float doubleJumpStrength;
    [SerializeField] private float highJumpStrength;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private LayerMask Barrier;
    [SerializeField] private LayerMask Glass;

    public PlayerSwing playerSwing;

    //How many jumps the player can do before needing to be grounded again
    [SerializeField] public int jumpsAvailable = 2;
    //Player is assigned the number of Jumps available from frame 1, used to determine how many jumps the player gets when jumps refresh
    public int maxJumps;
    //Has the player used their first jump?
    private bool initialJumpUsed = false;

    //The initial intensity of gravity which acts upon the player character
    private float initialGravity;
    //Is the process of fast falling currently taking place?
    public bool fastFalling = false;
    //How much the default gravity is multiplied by within the process of fast falling
    [SerializeField] public float fastfallGravMultiplier;


    [HideInInspector] public bool isDashing = false;
    [SerializeField] public int dashesAvailable;
    private int maxDashes;
    private bool dashRefilling = false;
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashWallCheckfrquency;
    [SerializeField] private float dashProgress;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float timeToRefillOneDash;
    [SerializeField] private bool spendDash;
    public float dashDir; //Stores value of which driection player is air dashing to inform animator which air dash animation to play
    public bool isAirDash = false;

    [SerializeField] private float heldDirection;

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
        if (isDashing == false && playerSwing.stopHorizontalInput == false && playerSwing.stopHorizontalVel == false)
        {
            rb.velocity = new Vector2(dirX * movementSpeed, rb.velocity.y);
        }

        if (dirX > 0)
        {
            heldDirection = 1;
        }
        else if (dirX < 0)
        {
            heldDirection = -1;
        }
        else if (dirX == 0)
        {
            heldDirection = 0;
        }

        if(playerSwing.stopHorizontalVel == true && movementType == "Stable")
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }


        if (gameManager.isGamePaused == false && gameManager.isGameOver == false)
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

        if (gameManager.isGamePaused == false && gameManager.isGameOver == false)
        {
            if(Input.GetButtonDown("Jump") && playerSwing.canJumpCancel == true && playerSwing.jumpCancelAvailable == true && playerSwing.isSwinging)
            {
                playerSwing.UpdateJumpInputPrevention(false);
                playerSwing.SwingCancel();
            }


            if (Input.GetButtonDown("Jump") && IsGrounded() && dirY <= verInputGateNegative && playerSwing.stopJumpInput == false && gameManager.isGamePaused == false)
            {
                rb.velocity = new Vector2(rb.velocity.x, highJumpStrength);
                jumpsAvailable = 0;
                onHighJumpEvent.Invoke();
                initialJumpUsed = true;

            }
            else if (Input.GetButtonDown("Jump") && IsGrounded() && playerSwing.stopJumpInput == false && gameManager.isGamePaused == false) //jumping
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

            } //When double jump is used
            else if (Input.GetButtonDown("Jump") && jumpsAvailable > 0 && !IsGrounded() && !IsAgainstAboveWall() && playerSwing.stopJumpInput == false && gameManager.isGamePaused == false)
            {
                rb.gravityScale = initialGravity;
                fastFalling = false;
                rb.velocity = new Vector2(rb.velocity.x, doubleJumpStrength);
                onDoubleJumpEvent.Invoke();
                jumpsAvailable = jumpsAvailable - 1;
            }
        }

        if (rb.velocity.y < -.1f && !IsGrounded() && fastFalling == false)
        {
            rb.gravityScale = rb.gravityScale * fastfallGravMultiplier;
            fastFalling = true;
        }
    }

   
   private void UpdateDash()
    {

        if (Input.GetButtonDown("Dash") && playerSwing.canDashCancel == true && playerSwing.dashCancelAvailable == true && playerSwing.isSwinging)
        {
            playerSwing.UpdateDashingPrevention(false);
            playerSwing.SwingCancel();
        }

        if (Input.GetButtonDown("Dash") && isDashing == false && dashesAvailable > 0 && playerSwing.stopDashing == false && playerSwing.stopHorizontalVel == false)
        {


            if (IsGrounded())
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

            if (IsGrounded() == false)
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


    public bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    public bool IsAgainstAboveWall()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.up, .2f, jumpableGround);
    }

    public bool IsAgainstForwardWall()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.right, .3f, Barrier);
    }

    public bool IsAgainstBackWall()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.left, .3f, Glass);
    }


    private IEnumerator Dash(float direction)
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

        rb.gravityScale = 0;

        dashProgress = 0.0f;

            for(dashProgress=0;dashProgress<=dashDuration;dashProgress=dashProgress+dashWallCheckfrquency)
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
                   // Debug.Log("Cancel Dash");
                    dashProgress = dashDuration;
                }
                else
                {
                    yield return new WaitForSeconds(dashWallCheckfrquency);
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
                    yield return new WaitForSeconds(dashWallCheckfrquency);
                }
            }
        }

        //yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        rb.gravityScale = initialGravity;

        if(spendDash == true)
        {
            dashesAvailable = dashesAvailable - 1;
        }

        spendDash = true;

    }

    //Refills players available dashes
    private IEnumerator RefillDash(float amount)
    {
        dashRefilling = true;
        yield return new WaitForSeconds(timeToRefillOneDash);
        dashRefilling = false;
        dashesAvailable = dashesAvailable + 1;
        rb.velocity = new Vector2(dirX * movementSpeed, rb.velocity.y);
    }

}
