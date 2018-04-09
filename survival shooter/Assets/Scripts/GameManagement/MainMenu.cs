using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public AudioMixer audioMixer;

	public void PlaySound(){
		FindObjectOfType<AudioManager> ().Play ("Select");
	}

	public void PlayGame(){
		FindObjectOfType<AudioManager> ().Stop ("MenuMusic");
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
		FindObjectOfType<AudioManager> ().Play ("Level0Music");
	}

	public void GoToMenu(){
		FindObjectOfType<AudioManager> ().Stop ("Level0Music");
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex - 1);
		FindObjectOfType<AudioManager> ().Play ("MenuMusic");
		FindObjectOfType<GameManager> ().Resume ();
	}

	public void Continue(){
		FindObjectOfType<GameManager> ().Resume ();
	}

	public void Quit(){
		Debug.Log("QUIT APPLICATION");
		Application.Quit ();
	}

	public void PlayOnMouseSound(){
		FindObjectOfType<AudioManager> ().Play ("Navigate");
	}

	public void SetVolume(float v){
		audioMixer.SetFloat ("volume", v);
	}

	public void SetMouseSensitivity(float s){
		GameManager.mouseSensitivity = s;
	}

	public void SetQuality(int qualityIndex){
		QualitySettings.SetQualityLevel (qualityIndex);
	}
}
