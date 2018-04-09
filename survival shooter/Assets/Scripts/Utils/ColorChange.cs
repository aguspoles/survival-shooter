using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ColorChange : MonoBehaviour {

	public float glitchChance = 0.1f;
	public float threshCutAmount = 0.1f;

	private WaitForSeconds glitchLoopWait = new WaitForSeconds(0.1f);
	private WaitForSeconds glitchDuration = new WaitForSeconds(0.1f);

	private float duration = 2.0f;
	private int r = 0;
	private int r1 = 1;
	private float changeColorTime = 0f;
	[SerializeField]
	private Color color0 = Color.red;
	[SerializeField]
	private Color color1 = Color.blue;
	[SerializeField]
	private Color color2 = Color.green;
	[SerializeField]
	private Color color3 = Color.yellow;
	private List<Color> colors = new List<Color>();

	private Material material;
	private Renderer holoRenderer;

	void Awake(){
		holoRenderer = GetComponent<Renderer> ();
		material = holoRenderer.material;
		colors.Add (color0);
		colors.Add (color1);
		colors.Add (color2);
		colors.Add (color3);
	}

	IEnumerator Start () {
		
		while (true) {
			float glitchTest = Random.Range (0, 1);
			if (glitchTest <= glitchChance)
				StartCoroutine (Glitch ());
			yield return glitchLoopWait;
		}
	}

	void Update () {
		if (changeColorTime > duration*4) {
			r = Random.Range (0, 3);
		    r1 = Random.Range (0, 3);
			changeColorTime = 0f;
		}
		changeColorTime += Time.deltaTime;
		float t = Mathf.PingPong(Time.time, duration) / duration;
		Color color = Color.Lerp(colors[r] , colors[r1], t);
		material.SetColor ("_TintColor", color);
	}

	IEnumerator Glitch(){
		glitchDuration = new WaitForSeconds (Random.Range (0.05f, 0.25f));
		material.SetFloat ("_CutoutThresh", threshCutAmount);
		//material.SetFloat ("_Amount", 1f);
		//material.SetFloat ("_Amplitude", Random.Range(100, 250));
		//material.SetFloat ("_Speed", Random.Range(1, 10));
		yield return glitchDuration;
		material.SetFloat ("_CutoutThresh", 0f);
		//material.SetFloat ("_Amount", 0f);
	}
}
