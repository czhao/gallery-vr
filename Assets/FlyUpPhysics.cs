using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyUpPhysics : MonoBehaviour {

	Rigidbody rb;
	private float thrust = 1f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rb.AddForce(Vector3.up * thrust * Time.deltaTime, ForceMode.Impulse);
		Debug.Log ("mass "+ rb.mass + " f"+thrust * Time.deltaTime);
	}
}
