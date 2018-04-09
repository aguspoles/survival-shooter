using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

	[SerializeField]
	private Camera m_camera;
	private Vector3 m_horizontalVelocity = Vector3.zero;
	private Vector3 m_verticalVelocity = Vector3.zero;

	private Vector3 m_thrusterForce = Vector3.zero;
	[SerializeField]
	private float m_dashForce = 0f;
	[SerializeField]
	private bool m_dashActivated = false;
	private Rigidbody m_rb;

	[SerializeField]
	private float m_cameraRotationLimit = 85f;
	private float m_cameraRotationX = 0f;
	private float m_currentCameraRotationX = 0f;
	private float m_rotationY = 0f;
	private float m_currentRotationY = 0f;

	void Start(){
		m_rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate(){
		if (GameManager.isRestarting == false) {
			PerformRotation ();
			PerformMovement ();
		}
	}

	public void MoveHorizontal(Vector3 velocity){
		m_horizontalVelocity = velocity;
	}
	public void MoveVertical(Vector3 velocity){
		m_verticalVelocity = velocity;
	}

	private void PerformMovement(){
		Vector3 movement = (m_horizontalVelocity + m_verticalVelocity);

		m_rb.MovePosition (transform.position + movement * Time.fixedDeltaTime);

		if (m_dashActivated) {
			PerformDash (movement.normalized);
		}
	}


	private void PerformRotation(){
		m_currentRotationY += m_rotationY;
		//m_currentRotationY = Mathf.Clamp (m_currentRotationY, -m_cameraRotationLimit, m_cameraRotationLimit);
		Vector3 rotY = new Vector3 (0f, m_currentRotationY, 0f);
		m_rb.MoveRotation (Quaternion.Euler (rotY));
		if (m_camera != null) {
			m_currentCameraRotationX += m_cameraRotationX;
			m_currentCameraRotationX = Mathf.Clamp (m_currentCameraRotationX, -m_cameraRotationLimit, m_cameraRotationLimit);
			m_camera.transform.localEulerAngles = new Vector3 (m_currentCameraRotationX, 0, 0);
		}
	}

	public void RotateY(float rotation){
		m_rotationY = rotation;
	}
	public void RotateCameraX(float cameraRotation){
		m_cameraRotationX = cameraRotation;
	}

	public void ApplyMoveForce(Vector3 force){
		m_thrusterForce = force;
	}

	public void ApplyDashForce(float force, bool active){
		m_dashForce = force;
		m_dashActivated = active;
	}


	public void PerformDash(Vector3 direction){
		m_rb.AddForce (m_dashForce * direction * Time.fixedDeltaTime, ForceMode.Impulse);
		m_dashActivated = false;
	}
		
}
