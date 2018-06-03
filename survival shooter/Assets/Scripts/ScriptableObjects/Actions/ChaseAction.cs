using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Actions/Chase")]
public class ChaseAction : Action 
{
	public override void Act (StateController controller)
	{
		Chase (controller); 
	}

	private void Chase(StateController controller)
	{
		controller.navMeshAgent.destination = controller.chaseTarget.position;

		controller.enemyController.Move(controller.navMeshAgent.desiredVelocity, false, false);

		controller.navMeshAgent.Resume ();
	}
}