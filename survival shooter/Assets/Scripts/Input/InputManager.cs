using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	private static InputManager instance;
	private IInput activeInput;

	[SerializeField]
	private GameObject m_player;
	private PlayerController m_controller;
	private PlayerMotor m_motor;
	private PlayerShooter m_shooter;
	[SerializeField]
	private GameObject m_robot;
	private RobotMovement m_robotMove;

	void Awake(){
		if (instance == null)
			instance = this;
		else {
			Destroy (gameObject);
			return;
		}

		DontDestroyOnLoad (gameObject);

		activeInput = new Keyboard();

		if (m_player) {
			m_controller = m_player.GetComponent<PlayerController> ();
			m_motor = m_player.GetComponent<PlayerMotor> ();
			m_shooter = m_player.GetComponent<PlayerShooter> ();
		} else
			Debug.Log ("InputManager: player is null");
		
		if (m_robot) {
			m_robotMove = m_robot.GetComponent<RobotMovement> ();
		}
		else 
			Debug.Log ("InputManager: robot is null");
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		activeInput.Walk (m_controller);
		activeInput.Rotate (m_controller);
		activeInput.Shoot (m_shooter);
		activeInput.ControllRobot (m_robotMove);
	}
}
