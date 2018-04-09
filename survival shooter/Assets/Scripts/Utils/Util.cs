using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util {

	public static void SetLayerRecursively(GameObject gObjetc, int newLayer){
		if (gObjetc == null)
			return;
		
		gObjetc.layer = newLayer;

		foreach (Transform child in gObjetc.transform) {
			if (child == null)
				continue;
			SetLayerRecursively (child.gameObject, newLayer);
		}
	}
}
