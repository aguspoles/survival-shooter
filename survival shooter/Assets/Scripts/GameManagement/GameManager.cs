using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class GameManager : MonoBehaviour {

	//private static GameManager instance;
	public static float mouseSensitivity = 10f;

	private Animator m_fadeAnimator;
	[SerializeField]
	private float m_fadeTime = 1.5f;

	public static bool isRestarting = false;
	public static bool GameIsPaused = false;
	public GameObject pauseGameObject;

	void Awake(){
		m_fadeAnimator	= GameObject.Find ("FadeUI").GetComponent<Animator> ();
		//Cursor.lockState = CursorLockMode.Locked;
	}

	void Start(){
		/*if(FindObjectOfType<AudioManager> ().IsPlaying("Level0Music") == false)
		   FindObjectOfType<AudioManager> ().Play ("Level0Music");*/
	}

	void Update(){
		//check pause
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
