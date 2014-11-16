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
	

	protected void Awake(){
		buttonHeight1 = Screen.height / 8;
		buttonHeight2 = Screen.height / 10;
		buttonWidth1 =  Screen.width / 1.5f;
		buttonWidth2 =  Screen.width / 2f;
		buttonPos1 = buttonHeight1;
		buttonPos2 = buttonHeight1 * 2.5f;
		buttonLeft1 = (Screen.width - buttonWidth1) / 2f;
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

		GUI.skin = guiskinButton2;
		
		if (GUI.Button(new Rect(buttonLeft2, buttonPos2, buttonWidth2, buttonHeight2),"about"))
		{
			Debug.Log("test");
		}
	}
}
