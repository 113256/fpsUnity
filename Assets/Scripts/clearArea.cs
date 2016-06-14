using UnityEngine;
using System.Collections;

public class clearArea : MonoBehaviour {

	public bool clear = false;
	//wait for 1 second of no collisions to be able to call helicopter
	public float clearTimer = 5;
	private bool canCallHeli = false;
	private bool colliding = false;
	GameObject terrainObject;
	private AudioSource clearAreaSound;



	// Use this for initialization
	void Start () {
		clearAreaSound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

		colliding = (terrainObject != null);
		//print (terrainObject);
		/*if (colliding) {
			clear = false;;
		} else {
			clear = true;
		}*/

		if (!colliding && !canCallHeli) {
			clearTimer-=Time.deltaTime;
			print(clearTimer);
			if(clearTimer<=0){
				print ("Call Heli!");
				canCallHeli = true;
				clearAreaSound.Play();
				//searches parent for a "OnFindClearArea" method and calls it
				SendMessageUpwards("OnFindClearArea");
			}
		}
	}

	void OnTriggerEnter(Collider collider){
		//clear = false;
		terrainObject = collider.gameObject;
		clearTimer = 5;
		canCallHeli = false;
		SendMessageUpwards("OnNotOnClearArea");
	}

	void OnTriggerExit(Collider collider){
		terrainObject = null;
	}
}
