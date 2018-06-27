using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mobile : IInput {

	public FixedJoystick moveJoystick;
	public FixedTouchField touchField;
	public FixedButton shootButton;

	public void Walk(PlayerController controller)
	{
		//calculate movement
		float xMov = moveJoystick.inputVector.x;
		float zMov = moveJoystick.inputVector.y;
	
		controller.Walk(xMov, zMov);
	}

	public void Rotate(PlayerController controller)
	{
		float yRot = touchField.TouchDist.x;
		float xRot = touchField.TouchDist.y;

		controller.Rotate(xRot, yRot);
	}

	public void Run(PlayerController controller)
	{
		Debug.Log("Running");
	}

	public void Shoot(PlayerShooter shooter)
	{
		if (GameManager.isRestarting == false)
		{

			if (shooter.currentWeapon.FireRate <= 0f)
			{
				if (shootButton.Pressed)
				{
					shooter.Shoot();
				}
			}
			else
			{
				if (shootButton.Pressed)
				{
					shooter.ShootRepeating();
				}
				else if (!shootButton.Pressed)
				{
					shooter.CancelShoot();
				}
			}

		}
		else
		{
			shooter.CancelShoot();
		}
	}
}
