using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	[SerializeField]
	private float rotationSpeed = 100f;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0f, 1f, 0f) * rotationSpeed * Time.deltaTime);
		//transform.position = new Vector3 (transform.position.x, transform.position.y * Time.deltaTime, transform.position.z);
	}
}
