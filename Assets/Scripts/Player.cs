using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	private GameObject spawnParent;
	private Vector3 nextSpawnPoint; 
	public bool respawn;
	List<Vector3> respawnPoints;
	
	// Use this for initialization
	void Start () {
		respawn = false;
		spawnParent = GameObject.Find ("Player Spawn Points");
		respawnPoints = new List<Vector3>();
		foreach (Transform point in spawnParent.transform) {
			print (point.transform.position);
			respawnPoints.Add(point.transform.position);
		} 
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
	}
}
