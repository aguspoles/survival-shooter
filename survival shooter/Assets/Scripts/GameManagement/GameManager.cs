using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static float mouseSensitivity = 10f;

	private Animator m_fadeAnimator;
	[SerializeField]
	private float m_fadeTime = 1.5f;

	public static bool isRestarting = false;
	public static bool GameIsPaused = false;
	public static bool playerPauseTheGame = false;
	public GameObject pauseGameObject;

	public static uint RobotsToWin = 20;
	public static uint RobotsCollected = 0;           // The number of robots the player has to pick.
	public Text m_MessageText;                  // Reference to the overlay Text to display winning text, etc.

	private void Awake()
	{
		m_fadeAnimator = GameObject.Find("FadeUI").GetComponent<Animator>();
	}

	private void Start()
	{
		Cursor.visible = false;
	}

	private void Update()
	{
		if (playerPauseTheGame)
		{
			if (GameIsPaused)
				Resume();
			else
				Pause();

			playerPauseTheGame = false;
		}
		if (RobotsCollected >= RobotsToWin)
		{
			RestartLevel();
		}
	}

	public void RestartLevel()
	{
		StartCoroutine(Restart());
	}

	IEnumerator Restart()
	{
		isRestarting = true;
		m_fadeAnimator.SetBool("fade", true);
		RobotsCollected = 0;
		yield return new WaitForSeconds(m_fadeTime);
		isRestarting = false;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void Resume()
	{
		Cursor.visible = false;
		pauseGameObject.SetActive(false);
		GameIsPaused = false;
		Time.timeScale = 1f;
	}

	public void Pause()
	{
		Cursor.visible = true;
		pauseGameObject.SetActive(true);
		GameIsPaused = true;
		Time.timeScale = 0f;
	}

	void StopSounds()
	{
		foreach (Sound s in FindObjectOfType<AudioManager>().sounds)
			if (s.name != "Music")
				s.source.Stop();
	}

}