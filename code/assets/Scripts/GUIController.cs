using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {

	public AutoRotate autoRotate;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI(){
		if (GUI.Button (new Rect (10, 10, 150, 100), "I am a button")) {
				autoRotate.rotateValues = new Vector3 (0, 0, 0);
				print ("You clicked the button");
		}
	}
}
