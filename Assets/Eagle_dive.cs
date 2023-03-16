using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle_dive : StateMachineBehaviour
{
  Transform player;
  Rigidbody2D rb;
  public float attackRange = 6f;

  // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
  override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    Debug.Log("Entrando al behaviour " + animator.transform);
    player = GameObject.FindGameObjectWithTag("Player").transform;
    rb = animator.GetComponent<Rigidbody2D>();

  }

  // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
  override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    float distancia = Vector3.Distance(player.position, rb.position);

    Debug.Log("distancia hasta Player " + distancia);
    if (distancia < attackRange)
    {
      animator.SetTrigger("attack");
    }

  }

  // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
  override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    animator.ResetTrigger("attack");
  }

}
