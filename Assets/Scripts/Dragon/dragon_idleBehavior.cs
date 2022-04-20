using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragon_idleBehavior : StateMachineBehaviour
{
    private float timer;
    private float _timer;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = animator.GetComponent<Dragon>().IdleTimer;

        animator.SetTrigger("idle");
        if (_timer <= 0
            && (animator.GetBool("headHitDone") || animator.GetComponent<Dragon>().headHitCount == 0)
            && (animator.GetBool("stompDone") || animator.GetComponent<Dragon>().stompCount == 0))
            _timer = timer;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_timer <= 0)
        {
            if (!animator.GetBool("headHitDone"))
            {
                animator.SetInteger("head", animator.GetComponent<Dragon>().ChooseHead());
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
