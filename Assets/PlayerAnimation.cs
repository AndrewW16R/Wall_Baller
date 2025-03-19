using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private SpriteRenderer sprite;
    private Animator anim;
    private PlayerMovement playerMovement;
    private PlayerSwing playerSwing;
    private GameObject gameManagerObject;
    private GameManager gameManager;
   public string currentAnim;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        playerMovement = gameObject.GetComponent<PlayerMovement>();
        playerSwing = gameObject.GetComponent<PlayerSwing>();

        gameManagerObject = GameObject.Find("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimationUpdate();
    }

    public void AnimationUpdate()
    {
        if (gameManager.isGamePaused == false && gameManager.isGameOver == false)//Animations are freezed/do not update while game is paused
        {

            if (playerMovement.isDashing == true)
            {
                if(playerMovement.dashDir == 1)//if dash to right
                {
                    if(playerMovement.isAirDash == true)
                    {
                        SetAnimationState("Player_DashForwardAir");
                        return;
                    }
                    else if(playerMovement.isAirDash == false)
                    {
                        SetAnimationState("Player_DashForwardGround");
                        return;
                    }
                }

                if(playerMovement.dashDir == -1)//if dash to left
                {
                    if (playerMovement.isAirDash == true)//is air dash
                    {
                        SetAnimationState("Player_DashBackward");
                        return;
                    }
                    else if (playerMovement.isAirDash == false)//is grounded dash
                    {
                        SetAnimationState("Player_DashBackward");
                        return;
                    }
                }
            }


            if (playerSwing.isSwinging == true)//If swing is active, the current animation will be for a swing
            {

                if (playerSwing.currentSwingName == "L_Grounded_Up")
                {
                    SetAnimationState("Player_SwingLGU");
                }
                else if (playerSwing.currentSwingName == "L_Grounded_Down")
                {
                    SetAnimationState("Player_SwingLGD");
                }
                else if (playerSwing.currentSwingName == "L_Grounded_Middle")
                {
                    SetAnimationState("Player_SwingLGM");
                }
                else if (playerSwing.currentSwingName == "H_Grounded_Up")
                {
                    SetAnimationState("Player_SwingHGU");
                }
                else if (playerSwing.currentSwingName == "H_Grounded_Down")
                {
                    SetAnimationState("Player_SwingHGD");
                }
                else if (playerSwing.currentSwingName == "H_Grounded_Middle")
                {
                    SetAnimationState("Player_SwingHGM");
                }
                else if (playerSwing.currentSwingName == "L_Airborne_Up")
                {
                    SetAnimationState("Player_SwingLAU");
                }
                else if (playerSwing.currentSwingName == "L_Airborne_Down")
                {
                    SetAnimationState("Player_SwingLAD");
                }
                else if (playerSwing.currentSwingName == "L_Airborne_Middle")
                {
                    SetAnimationState("Player_SwingLAM");
                }
                else if (playerSwing.currentSwingName == "H_Airborne_Up")
                {
                    SetAnimationState("Player_SwingHAU");
                }
                else if (playerSwing.currentSwingName == "H_Airborne_Down")
                {
                    SetAnimationState("Player_SwingHAD");
                }
                else if (playerSwing.currentSwingName == "H_Airborne_Middle")
                {
                    SetAnimationState("Player_SwingHAM");
                }
                else
                {
                    return;
                }
            }//insert else/if checks for dashing here before or after jump/falling checks (once mechanic is implemented)
            else if (playerMovement.rb.velocity.y > .1f && !playerMovement.IsGrounded() && playerMovement.jumpsAvailable == playerMovement.maxJumps - 1)//Jump inputed and player moving upwards
            {
                SetAnimationState("Player_Jump");
            }
            else if (playerMovement.rb.velocity.y > .1f && !playerMovement.IsGrounded() && playerMovement.jumpsAvailable < playerMovement.maxJumps - 1) //so jump animation plays again with double jump
            {
                SetAnimationState("Player_SecondJump");
            }
            else if (playerMovement.rb.velocity.y < .1f && !playerMovement.IsGrounded())//Player falling
            {
                SetAnimationState("Player_Fall");
            }
            else if (playerMovement.dirX > 0.5f && playerMovement.dirX > 0f && playerMovement.IsGrounded())//Moving forward
            {
                SetAnimationState("Player_MoveForward");
            }
            else if (playerMovement.dirX < -0.5f && playerMovement.dirX < 0f && playerMovement.IsGrounded())//Moving backwards
            {
                SetAnimationState("Player_MoveBackward");
            }
            else
            {
                SetAnimationState("Player_Idle");
            }
        }




    }

    void SetAnimationState(string newState)
    {
        if (newState == currentAnim)//If the current set animation this frame is the same as the previous frame, continue the current animation
        {
            return;
        }
        else//If the current set animation this frame is different from the previous frame, begin playing new animation
        {
            currentAnim = newState;
            anim.Play(newState);
        }

    }
}
