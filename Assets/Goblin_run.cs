using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_run : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    Transform player;
    Rigidbody2D rigidbody;
    public float speed = 10f;
    public float attackRange = 1.5f;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       player = GameObject.FindGameObjectWithTag("Player").transform;
       rigidbody = animator.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       Vector2 target = new Vector2(player.position.x, player.position.y);
       Vector2 newPos = Vector2.MoveTowards(rigidbody.position, target, speed*Time.fixedDeltaTime);
       
       if(Vector2.Distance(player.position, rigidbody.position) <= attackRange){
            animator.SetTrigger("Attack1");
       }else{
            rigidbody.MovePosition(newPos);
       }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.ResetTrigger("Attack1");
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
