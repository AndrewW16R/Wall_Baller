using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

public class RightWallAnimator : MonoBehaviour
{

    private SpriteRenderer sprite;
    private Animator anim;
    private GameObject rightWallTriggerObject;
    private RightWallBounceTrigger rightWallBounceTrigger;
    public string currentAnim;


    public bool hitAnimPlaying;

    public float anim01Duration;
    public float anim02Duration;
    public float anim03Duration;
    public float anim04Duration;
    public float anim05Duration;
    public float currentHitAnimDuration;

    private int hitAnimRngRoll;
    private int previousHitAnimRngRoll;

    

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        rightWallTriggerObject = GameObject.Find("RightWallBounceTrigger");
        rightWallBounceTrigger = rightWallTriggerObject.GetComponent<RightWallBounceTrigger>(); //recieves collisions from ball to initiate right wall animation

        hitAnimRngRoll = 0;

        PlayAnimationIdle();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AnimationUpdate();
    }

    public void AnimationUpdate()
    {
        if (hitAnimPlaying == true) //if a hit anim is playing
        {
            if (currentHitAnimDuration > 0) // if hit anim is not over
            {
                currentHitAnimDuration = currentHitAnimDuration - 1; //subtract 1 from duration counter
            }
            else
            {
                PlayAnimationIdle(); //switch back to idle anim if currentHitAnimDuration reaches zero
            }
        }
        else if(currentAnim != "RightWall_Idle")
        {
            PlayAnimationIdle();
        }
    }

    public void PlayAnimationIdle()
    {
        hitAnimPlaying = false;
        SetAnimationState("RightWall_Idle");
    }

    public void InitiateHitAnim()
    {
        previousHitAnimRngRoll = hitAnimRngRoll;
        hitAnimRngRoll = 0;
        hitAnimRngRoll = Random.Range(0, 4);

        if(hitAnimRngRoll == 0)
        {
            if(hitAnimRngRoll == previousHitAnimRngRoll)
            {
                hitAnimPlaying = true;
                currentHitAnimDuration = anim01Duration;
                ForceSetAnimationState("RightWall_Hit01");
            }
            else
            {
                PlayAnimationHit01();
            }

        }
        else if(hitAnimRngRoll == 1)
        {
            if (hitAnimRngRoll == previousHitAnimRngRoll) //is the selected hit animation is the same as the previous one, force the new hit animaion to play, even if the previously initiated hit anim is still playing
            {
                hitAnimPlaying = true;
                currentHitAnimDuration = anim02Duration;
                ForceSetAnimationState("RightWall_Hit02");
            }
            else
            {
                PlayAnimationHit02();
            }
        }
        else if (hitAnimRngRoll == 2)
        {
            if (hitAnimRngRoll == previousHitAnimRngRoll)
            {
                hitAnimPlaying = true;
                currentHitAnimDuration = anim03Duration;
                ForceSetAnimationState("RightWall_Hit03");
            }
            else
            {
                PlayAnimationHit03();
            }
        }
        else if (hitAnimRngRoll == 3)
        {
            if (hitAnimRngRoll == previousHitAnimRngRoll)
            {
                hitAnimPlaying = true;
                currentHitAnimDuration = anim04Duration;
                ForceSetAnimationState("RightWall_Hit04");
            }
            else
            {
                PlayAnimationHit04();
            }
        }
        else if (hitAnimRngRoll == 4)
        {
            if (hitAnimRngRoll == previousHitAnimRngRoll)
            {
                hitAnimPlaying = true;
                currentHitAnimDuration = anim05Duration;
                ForceSetAnimationState("RightWall_Hit05");
            }
            else
            {
                PlayAnimationHit05();
            }
        }
    }

    public void PlayAnimationHit01()
    {
        hitAnimPlaying = true;
        currentHitAnimDuration = anim01Duration;
        SetAnimationState("RightWall_Hit01");
    }

    public void PlayAnimationHit02()
    {
        hitAnimPlaying = true;
        currentHitAnimDuration = anim02Duration;
        SetAnimationState("RightWall_Hit02");
    }

    public void PlayAnimationHit03()
    {
        hitAnimPlaying = true;
        currentHitAnimDuration = anim03Duration;
        SetAnimationState("RightWall_Hit03");
    }

    public void PlayAnimationHit04()
    {
        hitAnimPlaying = true;
        currentHitAnimDuration = anim04Duration;
        SetAnimationState("RightWall_Hit04");
    }

    public void PlayAnimationHit05()
    {
        hitAnimPlaying = true;
        currentHitAnimDuration = anim05Duration;
        SetAnimationState("RightWall_Hit05");
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

    void ForceSetAnimationState(string newState)
    {
        currentAnim = newState;
        anim.Play(newState);
    }
}
