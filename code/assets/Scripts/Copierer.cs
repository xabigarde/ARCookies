using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Copierer : MonoBehaviour {

	public GameObject gameObject;
	//public GameObject particle;

	public int timeTillNextCookie = 100;
	public int radiusOfAppearing = 20;
	public int amountOfCookies = 5;



	float timer = 0;
	private int index = 1;
	private List<GameObject> _list = new List<GameObject>();
	private GameObject hittedGameObject;
	private GameObject instantiateGameObject;
	private GameLogic game;
	private  float count;
	private int startTime;
	private bool startCountdown = false;


	// Use this for initialization
	void Start () {
		// try to add first cookie! 
		//_list.Add (gameObject);
		game = GameLogic.Instance;
		count = Time.time;
		startTime = game.Countdown;
		startCountdown = true;
	}
	
	// Update is called once per frame
	void Update () {
		//timer = (Mathf.CeilToInt((timer - Time.deltaTime)))/10;
		if (startCountdown) {
				count += Time.deltaTime * 1;

				game.Countdown = startTime - (int)Mathf.Ceil (count % 60);
		}

		// left mouse click
		if (Input.GetButtonDown("Fire1")) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, 60)){
				Debug.Log("hitted");
				if(Physics.Raycast(ray)){
					// get Object which was clicked 
					hittedGameObject = hit.transform.gameObject;
					Debug.Log(hit.transform.name);

					// remove Object form List
					foreach (GameObject go in _list){
						if(go.name.Equals(hittedGameObject.name)){
							_list.Remove(go);
							go.audio.Play();
							Destroy(go, 0.5f);
							scorePoints();
							break;
						}
					}
				}
			}
		}


		timer += 1;

		// generate new Cookies
		if (timer >= timeTillNextCookie) {

			Vector3 newPosition = Random.insideUnitSphere * radiusOfAppearing;
			instantiateGameObject = (GameObject)GameObject.Instantiate (gameObject, newPosition, Quaternion.identity);
			instantiateGameObject.name = "cookie" + index;
			//instantiateGameObject.tag = "cookie";
			_list.Add(instantiateGameObject);
			Debug.Log (_list.Count + " " + instantiateGameObject.name + " created at" + newPosition);
		
			if(_list.Count >= amountOfCookies){
				GameObject go = _list[0];
				_list.RemoveAt(0);

				Destroy (go, 0.5f);
				Debug.Log("Destroyed " + go.name);
			}

			index++;
			timer = 0;
		}
	}



	private void scorePoints(){
		game.addPoint ();


	}

}
