using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {

	public float amount = 5f;
	// Use this for initialization

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (amount <= 0f) {
			PoolObject po = this.gameObject.GetComponent<PoolObject> ();
			if (po != null)
				po.Recycle ();
			else
				Destroy (this.gameObject);
		}
	}
}
