using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMovement : MonoBehaviour {

	private NavMeshAgent m_agent;
	public Vector3 position;
	public Camera camera;

	// Use this for initialization
	void Start () {
		m_agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Move(Vector3 pos){
		m_agent.SetDestination (pos);
	}
}
