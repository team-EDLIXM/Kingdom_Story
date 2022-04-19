using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragon_idleBehavior : StateMachineBehaviour
{
    private int rand;
    public float timer;
    private int headHitCountMax = 3;
    private float _timer;
    private float playerPos, headLeft, headMiddle, headRight;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetTrigger("idle");
        if (_timer <= 0 && (animator.GetInteger("headHitCount") == 0 || animator.GetInteger("headHitCount") >= 3))
            _timer = timer;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_timer <= 0)
        {
            if (animator.GetInteger("headHitCount") < 3)
            {
                playerPos = GameObject.FindGameObjectWithTag("Player").transform.position.x;
                headLeft = Mathf.Abs(playerPos - GameObject.Find("headLeft").transform.position.x);
                headMiddle = Mathf.Abs(playerPos - GameObject.Find("headMiddle").transform.position.x);
                headRight = Mathf.Abs(playerPos - GameObject.Find("headRight").transform.position.x);
                float min = Mathf.Min(headLeft, headMiddle, headRight);
                if (headLeft == min)
                    animator.SetInteger("head", 1);
                else if (headMiddle == min)
                    animator.SetInteger("head", 2);
                else
                    animator.SetInteger("head", 3);
            }
            else if (!animator.GetBool("stompDone"))
            {
                animator.SetTrigger("stomp");
            }
        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("idle", false);
        animator.SetInteger("headHitCount", animator.GetInteger("headHitCount") + 1);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
