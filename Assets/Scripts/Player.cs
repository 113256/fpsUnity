using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	private GameObject spawnParent;
	private Vector3 nextSpawnPoint; 
	public bool respawn;
	List<Vector3> respawnPoints;
	public Helicopter helicopter;
	private bool flashLightOn = false;
	private Light flashLight;

	//inner voice to guide the player - list of sound files
	private AudioSource innerVoice;
	//inner voice clips
	public AudioClip whatHappened;

	public GameObject landingArea;


	// Use this for initialization
	void Start () {
		respawn = false;
		flashLight = GetComponent<Light> ();
		spawnParent = GameObject.Find ("Player Spawn Points");
		respawnPoints = new List<Vector3>();
		foreach (Transform point in spawnParent.transform) {
			print (point.transform.position);
			respawnPoints.Add(point.transform.position);
		} 

		AudioSource[] audioSources = GetComponents<AudioSource> ();
		foreach(AudioSource audioSource in audioSources){
			//the audiosource for inner voice has priority 1 (see inspector)
			if(audioSource.priority == 1){
				innerVoice = audioSource;
			}
		}

		innerVoice.clip = whatHappened;
		innerVoice.Play ();
	}
	
	public void reSpawn(){
		int count = respawnPoints.Count;
		int rnd = Random.Range (0, count + 1);
		Vector3 newRespawn = respawnPoints[rnd];
		gameObject.transform.position = newRespawn;
	}

	// Update is called once per frame
	void Update () {
		if (respawn) {
			reSpawn();
			respawn = false;
		}
		if(Input.GetKeyDown(KeyCode.F)){
			print ("f");
			if(!flashLightOn){
				flashLight.enabled = true;
				flashLightOn = true;
			} else if(flashLightOn == true){
				flashLightOn = false;
				flashLight.enabled = false;
			}
		}

	}

	//called by child object "Clear Area" when clear area is found
	void OnFindClearArea(){
		print ("found clear area, can call heli");
		helicopter.canCallHeli();
	}
	//called by child "cleararea" when player isnt on a clear area
	void OnNotOnClearArea(){
		print ("not in clear area, cant call heli");
		helicopter.cannotCallHeli();
	}

	public Vector3 getPos(){
		return gameObject.transform.position;
	}

	public void dropFlare(){
		Instantiate (landingArea, gameObject.transform.position, gameObject.transform.rotation);
	}
}
