using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawCollectable : MonoBehaviour {

	private Text tex;

	void Awake () {
		tex = GetComponent<Text> ();
	}

	void Update () {
		tex.text = GameManager.RobotsCollected + "/" + GameManager.RobotsToWin;
	}
}
