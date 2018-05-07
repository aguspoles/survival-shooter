﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : NavMovement {

	public Camera camera;

	// Use this for initialization
	void Start () {
		if (camera == null) {
			Debug.Log ("RobotMovement: no reference to a camera");
			this.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update(){
		if (Input.GetMouseButtonDown (1)) {
			RaycastHit hit;
			Ray ray = camera.ScreenPointToRay (Input.mousePosition);
			if(Physics.Raycast (ray, out hit))
				base.Move (hit.point);
		}
	}
}