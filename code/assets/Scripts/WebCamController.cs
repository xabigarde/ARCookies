using UnityEngine;
using System.Collections;

public class WebCamController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		/*
		WebCamDevice[] devices = WebCamTexture.devices;
		int i = 0;
		while(i < devices.Length){
			Debug.Log (devices[i].name);
			i++;
		}

		Debug.Log (WebCamTexture.devices.ToString ());*/
		WebCamTexture webcamTex = new WebCamTexture ();
		guiTexture.texture = webcamTex;
		//renderer.material.mainTexture = webcamTex;

		webcamTex.Play ();

		guiTexture.pixelInset = new Rect(
			Screen.width / -2,
			Screen.height / -2,
			Screen.width,
			Screen.height
		);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
