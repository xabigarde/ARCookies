using UnityEngine;
using System.Collections;

public class Spinner : MonoBehaviour 
{

	public Vector3 itsRotationVector;

	private float[] itsRandom = new float[3];

	void Start()
	{
		for (int i = 0; i < itsRandom.Length; i++) 
		{
			itsRandom[i] = Random.value;
		}
	}

	void Update()
	{
		Vector3 aRotationVector = new Vector3(itsRotationVector.x * Mathf.Sin(Time.time * itsRandom[0]), itsRotationVector.y * Mathf.Cos(Time.time * itsRandom[1]), itsRotationVector.z * Mathf.Sin(Time.time * itsRandom[2]));
		this.transform.Rotate(new Vector3(aRotationVector.x, aRotationVector.y, aRotationVector.z));
	}
}
