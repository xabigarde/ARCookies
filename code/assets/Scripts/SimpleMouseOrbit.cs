using UnityEngine;
using System.Collections.Generic;

public class SimpleMouseOrbit : MonoBehaviour 
{
	public Transform target;
	
	public float xSpeed = 1000.0f;
	public float ySpeed = 1000.0f;
	
	public float yMinLimit = 5;
	public float yMaxLimit = 85;
	
	public float minDistance = 5;
	public float maxDistance = 50;
	
	[HideInInspector]
	public float x = 0.0f;
	[HideInInspector]
	public float y = 0.0f;
	
	public float distance = 25.0f;
	
	public bool allowPanning = true;
	public float panSpeed = 2;
	
	[HideInInspector]
	public Vector3 panOffset = Vector3.zero;
	
	[HideInInspector]
	public float targetX = 0.0f;
	[HideInInspector]
	public float targetY = 0.0f;
	[HideInInspector]
	public float targetDistance = 25.0f;
	
	public GameObject targetValuesDummy;
	
	void Start () 
	{
	    var angles = transform.eulerAngles;
	    x = angles.y;
	    y = angles.x;
		
		if (targetValuesDummy != null)
			targetValuesDummy.SetActive (false);
		
		targetX = x;
		targetY = y;
		targetDistance = distance;
		
	    // Make the rigid body not change rotation
	    if (rigidbody) 
	        rigidbody.freezeRotation = true;
		
	}

    void Update () 
    {
		if (Input.GetAxis("Mouse ScrollWheel") > 0) { // forward
			targetDistance--;
		}
    	if (Input.GetAxis("Mouse ScrollWheel") < 0) { // back
			targetDistance++;
		}
		
		targetDistance = Mathf.Clamp( targetDistance, minDistance, maxDistance);
		
		if (Input.GetMouseButton (0)) {
#if UNITY_FLASH
			// factor "3" ist da, weil unerklärlicherweise im flash der gelieferte wert höher ist
			targetX += Input.GetAxis("Mouse X") * xSpeed / 3 / 2 * Time.deltaTime;
			targetY -= Input.GetAxis("Mouse Y") * ySpeed / 3 / 2 * Time.deltaTime;
#else
			if( allowPanning && Input.GetKey(KeyCode.LeftShift) ) {
				Transform camTransform = Camera.main.transform;
				panOffset -= (Input.GetAxis("Mouse X") * Time.deltaTime * panSpeed) * camTransform.right;
				panOffset -= (Input.GetAxis("Mouse Y") * Time.deltaTime * panSpeed) * camTransform.up;
			} else {
				targetX += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
				targetY -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;
			}
#endif			

			targetY = ClampAngle(targetY, yMinLimit, yMaxLimit);
		}
		
        if (target)
        {
			//Debug.Log (	iTween.tweens.Count );
            //iTween.MoveTo (targetValues, iTween.Hash ("position", new Vector3 (x, y, distance), "easeType", "easeOutQuad", "onUpdateTarget", gameObject, "onUpdate", "CameraValueUpdate") );
			CameraValueUpdate();

        }
    }
	
	void CameraValueUpdate () 
	{

		distance = Mathf.Lerp( distance, targetDistance, Time.deltaTime * 3 );
		x = Mathf.Lerp( x, targetX, Time.deltaTime * 3 );
		y = Mathf.Lerp( y, targetY, Time.deltaTime * 3 );

		//panOffset = Vector3.Lerp( panOffset, idealPanOffset, Time.deltaTime * smoothPanningSpeed );

		transform.position = (Quaternion.Euler (y, x, 0)) * new Vector3 (0.0f, 0.0f, -distance) + target.position + panOffset;
		transform.rotation = Quaternion.Euler (y, x, 0);
	}

    static float ClampAngle(float angle, float min, float max) 
    {
        if (angle < -360)
        {
            angle += 360;
        }
        if (angle > 360)
        {
            angle -= 360;
        }
        return Mathf.Clamp(angle, min, max);
    }
}