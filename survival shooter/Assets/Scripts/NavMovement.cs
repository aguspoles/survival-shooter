using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMovement : MonoBehaviour {

	protected NavMeshAgent agent;

	// Use this for initialization
	void Awake () {
		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Move(Vector3 pos){
		agent.SetDestination (pos);
	}
}
