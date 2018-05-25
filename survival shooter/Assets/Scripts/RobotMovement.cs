using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : NavMovement {

	[SerializeField]
	private Camera m_camera;

	// Use this for initialization
	void Start () {
		if (m_camera == null) {
			Debug.Log ("RobotMovement: no reference to a camera");
			this.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update(){

	}

	public void Move(){
		RaycastHit hit;
		Ray ray = m_camera.ScreenPointToRay (Input.mousePosition);
		if(Physics.Raycast (ray, out hit))
			base.Move (hit.point);
	}
}
