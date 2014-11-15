using UnityEngine;
using System.Collections;

public class AutoRotate : MonoBehaviour {

	public Vector3 rotateValues = new Vector3(0,1,0);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localEulerAngles = new Vector3 (
			transform.localEulerAngles.x + rotateValues.x,
			transform.localEulerAngles.y + rotateValues.y,
			transform.localEulerAngles.z + rotateValues.z
				);
	}
}
