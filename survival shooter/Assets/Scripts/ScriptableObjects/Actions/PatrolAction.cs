using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Actions/Patrol", order=1)]
public class PatrolAction : Action
{
	public override void Act(StateController controller)
	{
		Patrol (controller);
	}

	private void Patrol(StateController controller)
	{
		controller.navMeshAgent.destination = controller.wayPointList [controller.nextWayPoint].position;
		//works along with animation
		controller.enemyController.Move(controller.navMeshAgent.desiredVelocity, false, false);
        controller.navMeshAgent.Resume ();

		if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending) 
		{
			controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
		}
		else
			controller.enemyController.Move(Vector3.zero, false, false);
	}
}
