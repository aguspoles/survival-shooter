﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

	private static InputManager instance;
	private IInput activeInput;

	[SerializeField]
	private GameObject m_player;
	private PlayerController m_controller;
	private PlayerMotor m_motor;
	private PlayerShooter m_shooter;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else
		{
			Destroy(gameObject);
			return;
		}

#if UNITY_STANDALONE_WIN
		activeInput = new Keyboard();
#elif UNITY_ANDROID
		Mobile mobile = new Mobile();
		GameObject ui = GameObject.Find("MobileUI");
		for (int i = 0; i < ui.transform.childCount; i++)
		{
			ui.transform.GetChild(i).gameObject.SetActive(true);
		}

		mobile.moveJoystick = ui.GetComponentInChildren<FixedJoystick>();
		mobile.touchField = ui.GetComponentInChildren<FixedTouchField>();
		FixedButton[] buttons = ui.GetComponentsInChildren<FixedButton>();
		for (int i = 0; i < buttons.Length; i++) {
			if (buttons[i].gameObject.name == "ShootButton")
				mobile.shootButton = buttons[i];
			else if (buttons[i].gameObject.name == "PauseButton")
				mobile.pauseButton = buttons[i];
			else Debug.Log("Buttons names cant be recognize");
		}

		activeInput = mobile;
#else
		activeInput = new Keyboard();
#endif

		if (m_player)
		{
			m_controller = m_player.GetComponent<PlayerController>();
			m_motor = m_player.GetComponent<PlayerMotor>();
			m_shooter = m_player.GetComponent<PlayerShooter>();
		}
		else
		{
			m_player = GameObject.FindGameObjectWithTag("Player");
			Debug.Log("InputManager: player is null");
		}
	}

	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		activeInput.Walk(m_controller);
		activeInput.Rotate(m_controller);
		activeInput.Shoot(m_shooter);
		activeInput.Pause();
	}
}
