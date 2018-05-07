using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : InputI {

	public void Walk(){
		Debug.Log ("Walking");
	}

	public void Run(){
		Debug.Log ("Running");
	}

	public void Shoot(){
		Debug.Log ("Shooting");
	}

	public void ControllRobot (){
		Debug.Log ("Moving robot");
	}
}
