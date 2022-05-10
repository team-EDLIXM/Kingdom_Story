using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragon_fireRightBehavior : StateMachineBehaviour
{
    private GameObject headRight;
    private GameObject player;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator.GetComponent<Dragon>().fireAttackCount++;
        headRight = GameObject.Find("headRight");
        headRight.transform.position += new Vector3(0.8f, 0, 0);
        headRight.GetComponent<Stats>().isInvulnerable = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player.transform.position.x > headRight.transform.position.x)
            headRight.GetComponent<Stats>().isInvulnerable = true;
        else
            headRight.GetComponent<Stats>().isInvulnerable = false;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        headRight.GetComponent<Stats>().isInvulnerable = true;
        headRight.transform.position += new Vector3(-0.8f, 0, 0);
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
