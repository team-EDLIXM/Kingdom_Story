using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragon_stage1 : StateMachineBehaviour
{
    private Dragon dragon;

    public int maxHealth;
    public int damage;
    public float IdleTimer;
    public int headHitCountMax;
    public int stompCountMax;
    public float stompWaveSpeed;
    public float stompWaveDestroyTime;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        dragon = animator.GetComponent<Dragon>();

        dragon.headLeft.GetComponent<Stats>().maxhealth = maxHealth;
        dragon.headLeft.GetComponent<Stats>().health = maxHealth;
        dragon.headMiddle.GetComponent<Stats>().maxhealth = maxHealth;
        dragon.headMiddle.GetComponent<Stats>().health = maxHealth;
        dragon.headRight.GetComponent<Stats>().maxhealth = maxHealth;
        dragon.headRight.GetComponent<Stats>().health = maxHealth;

        dragon.damage = damage;

        dragon.headHitCountMax = headHitCountMax;
        animator.SetBool("headHitDone", false);

        dragon.IdleTimer = IdleTimer;

        dragon.stompCountMax = stompCountMax;
        animator.SetBool("stompDone", false);
        dragon.stompWaveSpeed = stompWaveSpeed;
        dragon.stompWaveDestroyTime = stompWaveDestroyTime;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("stage1Done");
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
