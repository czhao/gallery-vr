using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByCollision : MonoBehaviour {

	void OnTriggerEnter(Collider other){

		if (other.CompareTag ("Bullet")) {
			Destroy (gameObject);
			Destroy (other);
		}
	}
}
