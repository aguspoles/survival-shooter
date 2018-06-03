using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInput {
	void Walk (PlayerController controller);
	void Rotate (PlayerController controller);
	void Run (PlayerController controller);
	void Shoot (PlayerShooter shooter);
	//void ControllRobot (RobotMovement robotMove);
}

