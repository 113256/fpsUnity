using UnityEngine;
using System.Collections;

public class dayCycle : MonoBehaviour {

	//how many real world minutes per in game second (usually 60)
	public float timeScale;
	//starting rotation of the directional light
	private Quaternion startRotation;

	// Use this for initialization
	void Start () {
		startRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		float angleThisFrame = Time.deltaTime / 360 * timeScale;
		/*rotate the transform about the axis (param2) passing through point (param1) in world coordinates by 
		angle (param3) degrees */
		transform.RotateAround (transform.position, Vector3.forward, angleThisFrame);
	}
}
