using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {

	public GUISkin guiskinbackground;
	private float w = 0;
	private float h = 0;
	private float top = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// back button pressed on android
		if (Input.GetKeyDown(KeyCode.Escape)) { 
			//Application.LoadLevel("StartScene");
		}
		

	}

	void Awake(){
		w = Screen.width;
		h = Screen.width / 2.54f;
		top = Screen.height - h;
	}

	void OnGUI(){
		GUI.skin = guiskinbackground;


		GUI.Box(new Rect (0, top, w, h), "");
	}
}
