using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : IInput
{

	public void Walk(PlayerController controller)
	{
		//calculate movement
		float xMov = Input.GetAxisRaw("Horizontal");
		float zMov = Input.GetAxisRaw("Vertical");

		controller.Walk(xMov, zMov);
	}

	public void Rotate(PlayerController controller)
	{
		float yRot = Input.GetAxisRaw("Mouse X");
		float xRot = Input.GetAxisRaw("Mouse Y");

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
				if (Input.GetButtonDown("Fire1"))
				{
					shooter.Shoot();
				}
			}
			else
			{
				if (Input.GetButtonDown("Fire1"))
				{
					shooter.ShootRepeating();
				}
				else if (Input.GetButtonUp("Fire1"))
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

	public void Pause()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
			GameManager.playerPauseTheGame = true;
	}
}
