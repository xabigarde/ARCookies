﻿using UnityEngine;
using System.Collections;

public class RadarTest : MonoBehaviour {

	public Texture blip  ;
	public Texture radarBG ;
	public Texture centerBG;
	
	private int blipSize = Screen.height/40;
	private int posX = 0;
	private int posY = 0;
	
	public Transform centerObject ;
	public float mapScale = 1.5f;
	//private Vector2 mapCenter = new Vector2(50,50);
	public string tagFilter =  "Cookie";
	private float maxDist = Screen.height/4;
	
	void OnGUI()
	{
		posX = (Screen.height / 4) / 2;
		posY = posX;
		
		//  GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, Vector3(Screen.width / 600.0, Screen.height / 450.0, 1));
		
		// Draw player blip (centerObject)
		//    float bX=centerObject.transform.position.x * mapScale;
		//      float bY=centerObject.transform.position.z * mapScale;
		
		

		GUI.DrawTexture(new Rect(0,0,Screen.height/4,Screen.height/4),radarBG);

		GUI.DrawTexture(new Rect(posX - (Screen.height/40)/2,posY - (Screen.height/40)/2,blipSize,blipSize),centerBG);
				

		DrawBlipsFor(tagFilter);
		
	}
	
	private void DrawBlipsFor(string tagName)
	{
		
		// Find all game objects with tag
		GameObject[] gos = GameObject.FindGameObjectsWithTag(tagName);
		
		// Iterate through them
		foreach (GameObject go in gos) 
		{
			drawBlip(go,blip);
		}
	}
	
	private void drawBlip(GameObject go,Texture aTexture)
	{
		Vector3 centerPos=centerObject.position;
		Vector3 extPos=go.transform.position;
		
		// first we need to get the distance of the enemy from the player
		float dist=Vector3.Distance(centerPos,extPos);
		
		float dx=centerPos.x-extPos.x; // how far to the side of the player is the enemy?
		float dz=centerPos.z-extPos.z; // how far in front or behind the player is the enemy?
		
		// what's the angle to turn to face the enemy - compensating for the player's turning?
		float deltay=Mathf.Atan2(dx,dz)*Mathf.Rad2Deg - 270 - centerObject.eulerAngles.y;
		
		// just basic trigonometry to find the point x,y (enemy's location) given the angle deltay
		float bX=dist*Mathf.Cos(deltay * Mathf.Deg2Rad);
		float bY=dist*Mathf.Sin(deltay * Mathf.Deg2Rad);
		
		bX=bX*mapScale; // scales down the x-coordinate by half so that the plot stays within our radar
		bY=bY*mapScale; // scales down the y-coordinate by half so that the plot stays within our radar
		
		if(dist<= maxDist)
		{
			// this is the diameter of our largest radar circle
			GUI.DrawTexture(new Rect(posX+bX,posY+bY,blipSize,blipSize),aTexture);
		}
		
	}
	
}
