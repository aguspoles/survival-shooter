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
		public GameObject pauseGameObject;

		public int m_NumRoundsToWin = 5;            // The number of rounds a single player has to win to win the game.
		public float m_StartDelay = 3f;             // The delay between the start of RoundStarting and RoundPlaying phases.
		public float m_EndDelay = 3f;               // The delay between the end of RoundPlaying and RoundEnding phases.
		public Text m_MessageText;                  // Reference to the overlay Text to display winning text, etc.

		private int m_RoundNumber;                  // Which round the game is currently on.
		private WaitForSeconds m_StartWait;         // Used to have a delay whilst the round starts.
		private WaitForSeconds m_EndWait;           // Used to have a delay whilst the round or game ends.

		private void Awake(){
			m_fadeAnimator	= GameObject.Find ("FadeUI").GetComponent<Animator> ();
		}

		private void Start()
		{
			// Create the delays so they only have to be made once.
			m_StartWait = new WaitForSeconds (m_StartDelay);
			m_EndWait = new WaitForSeconds (m_EndDelay);
		}

		private void Update(){
			if (Input.GetKeyDown(KeyCode.Escape)) {
				if (GameIsPaused)
					Resume ();
				else
					Pause ();
			}
		}
			


		public void RestartLevel(){
			StartCoroutine (Restart ());
		}

		IEnumerator Restart(){
			isRestarting = true;
			m_fadeAnimator.SetBool ("fade", true);
			yield return new WaitForSeconds (m_fadeTime);
			isRestarting = false;
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}

		void StopSounds(){
			foreach (Sound s in FindObjectOfType<AudioManager>().sounds)
				if(s.name != "Music")
					s.source.Stop ();
		}

		public void Resume(){
			pauseGameObject.SetActive (false);
			GameIsPaused = false;
			Time.timeScale = 1f;
		}

		public void Pause(){
			pauseGameObject.SetActive (true);
			GameIsPaused = true;
			Time.timeScale = 0f;
		}

	}