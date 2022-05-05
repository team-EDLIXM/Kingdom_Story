using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragon_stage3 : StateMachineBehaviour
{
    private Dragon dragon;

    public int maxHealth;
    public int damage;
    public float IdleTimer;
    public float fireballSpeed;

    public int fireAttackCountMax;
    public int magicalSphereAttackCountMax;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        dragon = animator.GetComponent<Dragon>();

        dragon.headMiddle.GetComponent<Stats>().maxhealth = maxHealth;
        dragon.headMiddle.GetComponent<Stats>().health = maxHealth;
        dragon.headLeft.GetComponent<Stats>().isInvulnerable = true;
        dragon.headMiddle.GetComponent<Stats>().isInvulnerable = true;
        dragon.headRight.GetComponent<Stats>().isInvulnerable = true;

        dragon.damage = damage;

        dragon.headHitCountMax = 0;

        dragon.IdleTimer = IdleTimer;

        dragon.stompCountMax = 0;

        dragon.fireAttackCountMax = fireAttackCountMax;
        animator.SetBool("fireAttack", false);
        animator.SetBool("fireAttackDone", false);
        dragon.fireAttackCount = 0;
        dragon.fireballSpeed = fireballSpeed;

        dragon.magicalSphereAttackCountMax = magicalSphereAttackCountMax;
        animator.SetBool("magicalSphereAttack", false);
        animator.SetBool("magicalSphereAttackDone", false);
        dragon.magicalSphereAttackCount = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("stage3Done");
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
