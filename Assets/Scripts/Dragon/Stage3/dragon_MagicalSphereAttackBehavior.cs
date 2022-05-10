using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragon_MagicalSphereAttackBehavior : StateMachineBehaviour
{
    private GameObject player;
    private GameObject headMiddle;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        headMiddle = GameObject.Find("headMiddle");
        animator.GetComponent<Dragon>().magicalSphereAttackCount++;
        headMiddle.transform.position += new Vector3(-2, 0, 0);
        headMiddle.GetComponent<Stats>().isInvulnerable = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player.transform.position.x < headMiddle.transform.position.x)
            headMiddle.GetComponent<Stats>().isInvulnerable = true;
        else
            headMiddle.GetComponent<Stats>().isInvulnerable = false;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        headMiddle.transform.position += new Vector3(2, 0, 0);
        headMiddle.GetComponent<Stats>().isInvulnerable = true;
        animator.SetBool("magicalSphereAttack", false);
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
