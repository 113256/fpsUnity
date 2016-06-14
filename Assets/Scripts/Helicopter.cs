using UnityEngine;
using System.Collections;

public class Helicopter : MonoBehaviour {

	//public AudioClip heliSound;
	public AudioClip callSound;
	private bool called = false;
	private AudioSource[] audioSource;
	private bool canCall = false;
	private Rigidbody rigidBody;

	public Player player;

	private bool flying = false;
	public float speed;
	private Vector3 playerPos;

	// Use this for initialization
	void Start () {
		//we have 2
		audioSource = GetComponents<AudioSource> ();
		rigidBody = GetComponent<Rigidbody> ();
	}

	public void canCallHeli(){
		canCall = true;
	}

	public void cannotCallHeli(){
		canCall = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("CallHeli") && !called && canCall){
			called = true;
			audioSource[0].clip = callSound;
			audioSource[0].Play();
			//rigidBody.velocity = new Vector3(0,0,180f);
			player.dropFlare();
			flying = true;
			playerPos = player.getPos();
			playerPos.y = 60; //so that helicopter lands a bit higher than the player
		} 

		if (flying) {
			 
			//playerPos.y = 150; //uncomment this if you want the helicopter to be fixed at y=150 because it will fly lower to the player's position
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, playerPos, step);
			if(Vector3.Distance(this.transform.position, playerPos) <= 10){
				flying = false;
			}
		}
	}

	public void Fly(){

	}

	/*public void Call(){
		if (!called) {
			called = true;
			audioSource[0].clip = callSound;
			audioSource [0].Play ();
			rigidBody.velocity = new Vector3(0,0,300f);
		}
	}*/
}
