using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragon_stage3_idleBehavior : StateMachineBehaviour
{
    private float timer;
    private float _timer;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = animator.GetComponent<Dragon>().IdleTimer;

        if (_timer <= 0
            && (animator.GetBool("fireAttackDone") || animator.GetComponent<Dragon>().fireAttackCount == 0)
            && (animator.GetBool("magicalSphereAttackDone") || animator.GetComponent<Dragon>().magicalSphereAttackCount == 0))
            _timer = timer;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_timer <= 0)
        {
            if (!animator.GetBool("fireAttackDone"))
            {
                animator.SetTrigger("fireAttack");
            }
            else if (!animator.GetBool("magicalSphereAttackDone"))
            {
                animator.SetTrigger("magicalSphereAttack");
            }
        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
