using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserSettings : MonoBehaviour {

	[SerializeField]
	private GameObject graphics;

	void Awake () {
		
	}

	void Start(){
		Cursor.visible = true;
		Dropdown dropDownGraphics = graphics.GetComponentInChildren<Dropdown> ();
		if (dropDownGraphics == null) {
			Debug.Log ("Dropdown UI component not found");
			return;
		}
		dropDownGraphics.value = QualitySettings.GetQualityLevel ();
		QualitySettings.SetQualityLevel (dropDownGraphics.value);
	}

}
