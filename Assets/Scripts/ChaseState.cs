using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : StateMachineBehaviour
{
	NavMeshAgent agent;
	Transform player;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		agent = animator.GetComponent<NavMeshAgent>();
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		agent.SetDestination(player.position);
		animator.transform.LookAt(player);
		float distance = Vector3.Distance(player.position, animator.transform.position);
		Debug.Log(distance);
		if (distance < 3f)
		{
			animator.SetBool("isWalking", false);
			animator.SetBool("isAttacking", true);
		}
			
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		agent.SetDestination(animator.transform.position);
		
	}

}