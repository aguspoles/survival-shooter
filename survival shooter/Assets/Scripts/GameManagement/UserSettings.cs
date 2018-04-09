using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserSettings : MonoBehaviour {

	//private static UserSettings instance;

	[SerializeField]
	private GameObject graphics;

	void Awake () {
		/*if (instance == null)
			instance = this;
		else {
			Destroy (gameObject);
			return;
		}

		DontDestroyOnLoad (gameObject);*/
	}

	void Start(){
		Dropdown dropDownGraphics = graphics.GetComponentInChildren<Dropdown> ();
		if (dropDownGraphics == null) {
			Debug.Log ("Dropdown UI component not found");
			return;
		}
		dropDownGraphics.value = QualitySettings.GetQualityLevel ();
		QualitySettings.SetQualityLevel (dropDownGraphics.value);
	}

}
