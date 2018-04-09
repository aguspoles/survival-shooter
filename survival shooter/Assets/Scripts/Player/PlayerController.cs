using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float m_speed = 5f;
	private float m_xMov;
	private float m_zMov;

	[SerializeField]
	private float m_thrusterForce = 1000f;
	[SerializeField]
	private float m_thrusterFuelRegenSpeed = 0.3f;
	[SerializeField]
	private float m_thrusterFuelBurnSpeed = 1f;
	private float m_thrusterFuelAmount = 1f;

	[SerializeField]
	private float m_dashForce = 500f;
	[SerializeField]
	private float m_dashCoolDown = 1f;
	private bool m_dashActivated = true;

	[SerializeField]
	private LayerMask m_enviromentMask;

	private PlayerMotor m_motor;
	private GameManager m_gameManager;
	public Animator m_animator;

	void Start () {
		m_motor = GetComponent<PlayerMotor> ();
		m_gameManager = GameObject.Find ("GameController").GetComponent<GameManager> ();
	}

	void Update () {
		Move ();
		Rotate ();
		CheckDash ();
	}

	public float GetThrusterFuel(){
		return m_thrusterFuelAmount;
	}

	IEnumerator DashCollDown(float sec){
		m_dashActivated = false;
		yield return new WaitForSeconds (sec);
		m_dashActivated = true;
	}

	private void Move(){
		//calculate movement
		m_xMov = Input.GetAxisRaw ("Horizontal");
		m_zMov = Input.GetAxisRaw ("Vertical");

		Vector3 moveHorizontal = transform.right * m_xMov * m_speed;
		Vector3 moveVertical = transform.forward * m_zMov * m_speed;

		m_motor.MoveHorizontal (moveHorizontal);
		m_motor.MoveVertical (moveVertical);
	}


	void OnCollisionEnter(Collision other){
		if (other.collider.tag == "Obstacle" || other.collider.tag == "Destroyable") {
			m_gameManager.RestartLevel ();
			FindObjectOfType<AudioManager> ().Play ("Die");
			this.gameObject.GetComponent<Collider> ().enabled = false;
		}
	}

	void CheckDash(){
		if (Input.GetKeyDown(KeyCode.LeftShift) && m_thrusterFuelAmount > 0f && m_dashActivated) {
			m_thrusterFuelAmount -= m_thrusterFuelBurnSpeed * Time.deltaTime;
			StartCoroutine (DashCollDown (m_dashCoolDown));

				m_motor.ApplyDashForce (m_dashForce, true);
				if (m_xMov > 0.5f) {
					m_animator.Play ("rightDash");
				} else {
					m_animator.Play ("leftDash");
				}
				FindObjectOfType<AudioManager> ().Play ("Dash");		}
	}

	void Rotate(){
		//turning around
		float yRot = Input.GetAxisRaw ("Mouse X");
		float rotation = yRot * GameManager.mouseSensitivity * Time.deltaTime;
		m_motor.RotateY (rotation);

		//calculate camera rotation
		float xRot = Input.GetAxisRaw ("Mouse Y");
		float cameraRotationX = xRot * -GameManager.mouseSensitivity * Time.deltaTime;
		m_motor.RotateCameraX (cameraRotationX);
	}

	IEnumerator WaitForRefuel(){
		yield return new WaitForSeconds (0.5f);
		m_thrusterFuelAmount += m_thrusterFuelRegenSpeed/2 * Time.deltaTime;
	}

}
