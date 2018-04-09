using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Tracker : MonoBehaviour {

	public Transform target;

	private Rigidbody m_rb;
	[SerializeField]
	private float m_speed = 2f;

	void Awake () {
		m_rb = GetComponent<Rigidbody> ();
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void FixedUpdate () {
		Vector3 direction = target.position - m_rb.position;

		direction.Normalize ();

		//vector3 = Vector3.Cross (direction, transform.forward);

		m_rb.velocity = direction * m_speed;
	}
}
