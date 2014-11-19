using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {

	public GUISkin guiskinbackground;
	public GUISkin guiskinbackground2;
	private float w = 0;
	private float h = 0;
	private float top = 0;
	private float square = 0;
	private float square2 = 0;
	private float monsterL = 0;
	public Font f;


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
		h = Screen.height;
		square = w / 7f;
		square2 = h / 5;
		monsterL = w / 2 - square / 2;
	}

	void OnGUI(){

		// display the monster
		GUI.skin = guiskinbackground;
		// calculate the middle of the screen
		GUI.Box(new Rect (w/2-square/2, h - square, square, square), "");

		// display the score
		if (!f) {
			Debug.LogError("No font found, assign one in the inspector.");
			return;
		}
		GUI.skin.font = f;
		//GUI.backgroundColor = Color.yellow;

		//GUI.skin = guiskinbackground2;
		GUIStyle style = new GUIStyle ();
		style.fontSize = 40;
		style.fontStyle = FontStyle.Bold;
		style.padding = new RectOffset (10, 10, 10, 10);
		style.normal.background = MakeTex( 2, 2, new Color( 1f, 1f, 1f, 0.5f ) );
		//GUI.Box(new Rect (0, 100 ,100, 100), GameLogic.Instance.Points.ToString(),style);
		GUI.Label(new Rect(0, h - square ,square, square), "cookies\n" + GameLogic.Instance.Points.ToString(),style);
		GUI.Label(new Rect(w-square, h - square ,square, square), "time\n" + GameLogic.Instance.Countdown.ToString(),style);
		//GUI.Label(new Rect(0, 0 ,square2, square2), "",style);


	}

	private Texture2D MakeTex( int width, int height, Color col )
	{
		Color[] pix = new Color[width * height];
		for( int i = 0; i < pix.Length; ++i )
		{
			pix[ i ] = col;
		}
		Texture2D result = new Texture2D( width, height );
		result.SetPixels( pix );
		result.Apply();
		return result;
	}
}
