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
        if (gameManager.isGamePaused == false && gameManager.isGameOver == false)
        {


            if (playerSwing.isSwinging == true)
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
            else if (playerMovement.rb.velocity.y > .1f && !playerMovement.IsGrounded() && playerMovement.jumpsAvailable == playerMovement.maxJumps - 1)
            {
                SetAnimationState("Player_Jump");
            }
            else if (playerMovement.rb.velocity.y > .1f && !playerMovement.IsGrounded() && playerMovement.jumpsAvailable < playerMovement.maxJumps - 1) //so jump animation plays again with double jump
            {
                SetAnimationState("Player_SecondJump");
            }
            else if (playerMovement.rb.velocity.y < .1f && !playerMovement.IsGrounded())
            {
                SetAnimationState("Player_Fall");
            }
            else if (playerMovement.dirX > 0.5f && playerMovement.dirX > 0f && playerMovement.IsGrounded())
            {
                SetAnimationState("Player_MoveForward");
            }
            else if (playerMovement.dirX < -0.5f && playerMovement.dirX < 0f && playerMovement.IsGrounded())
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
        if (newState == currentAnim)
        {
            return;
        }
        else
        {
            currentAnim = newState;
            anim.Play(newState);
        }

    }
}
