using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Font font;

	public GUISkin guiskinbackground;
	public GUISkin guiskinButton1;
	public GUISkin guiskinButton2;

	private float buttonWidth1 = 0;
	private float buttonWidth2 = 0;
	private float buttonHeight1 = 0;
	private float buttonHeight2 = 0;
	private float buttonPos1 = 0;
	private float buttonPos2 = 0;
	private float buttonLeft1 = 0;
	private float buttonLeft2 = 0;
	

	void Update(){
		// back button pressed on android
		if (Input.GetKeyDown(KeyCode.Escape)) { 
			//Application.Quit();
			Debug.Log("pressed back button start");
		}
	}

	protected void Awake(){
		buttonHeight1 = Screen.height / 4;
		buttonHeight2 = Screen.height / 10;
		buttonWidth1 =  Screen.width / 3;
		buttonWidth2 =  Screen.width / 2f;
		buttonPos1 = (Screen.height - buttonHeight1) / 2f;
		buttonPos2 = buttonHeight1 * 2.5f;
		buttonLeft1 = buttonWidth1 / 2;
		buttonLeft2 = (Screen.width - buttonWidth2) / 2f;
	}


	protected void OnGUI()
	{
		GUI.skin = guiskinbackground;
		GUI.Box(new Rect (0, 0, Screen.width, Screen.height), "");

		GUI.skin = guiskinButton1;
		if (!font) {
			Debug.LogError("No font found, assign one in the inspector.");
			return;
		}
		GUI.skin.font = font;

		if (GUI.Button(new Rect(buttonLeft1, buttonPos1, buttonWidth1, buttonHeight1), "START\neating cookies"))
		{
			Application.LoadLevel("WebCamScene");
		}

		//GUI.skin = guiskinButton2;
		
		/*if (GUI.Button(new Rect(buttonLeft2, buttonPos2, buttonWidth2, buttonHeight2),"about"))
		{
			Debug.Log("test");
		}*/
	}
}
