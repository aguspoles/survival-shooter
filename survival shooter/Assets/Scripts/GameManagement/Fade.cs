using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour {

	/*public Texture2D fadeTexture; //the texture that will overlay the screen, can be a black image or a loading graphic
	public float fadeSpeed;       //the fading speed

	private int drawDepth = -1000;//the textures order in the draw hierarchy, low number renders on top
	private float alpha = -1;     //textures alpha value
	private int fadeDir = -1;     //direction to fade: in = -1, out = 1

	void OnGui(){
		//unity function, fade out/in the alpha value using a direction, a speed and a time.deltatime to convert the operation to seconds
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		//force (clamp) the number to be between 0 and 1 becuase gui color uses alpha values between those
		alpha = Mathf.Clamp(alpha, 0, 1);
		//set the color of our gui (the texture). All color values remain the same and the alpha is set with alpha variable
		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeTexture);
	}

	//sets fadedir to the direction parameter making the scene fade in if -1 and out if 1
	public float BeginFade(int direction){
		fadeDir = direction;
		return fadeSpeed; //return fadespeed variable so its easy to time the Apllication.LoadLevel();
	}

	//sceneLoaded is called when a level is loaded. It takes loaded level index as a parameter so you can limit the fade in to certain scenes
	void sceneLoaded(){
		BeginFade (-1);
	}*/
}
