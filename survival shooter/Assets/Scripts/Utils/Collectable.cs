using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Player")) {
			GameManager.RobotsCollected++;
			Destroy (this.gameObject);
			GameObject.FindObjectOfType<AudioManager>().Play("Collect");
		}
	}
}
