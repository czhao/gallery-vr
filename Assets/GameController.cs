using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public float waitToStartWave = 2f;
	public GameObject harzard;
	public float BallonLife = 5f;
	private float BallonSpeed = 0.1f;


	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnWaves ());
	}

	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds (waitToStartWave);
		while (true) {
			GameObject ballon = Instantiate(harzard, Vector3.zero, harzard.transform.rotation) as GameObject;
			ballon.SetActive(true);
			Rigidbody rb = ballon.GetComponent<Rigidbody>();
			//rb.AddForce(Vector3.up * BallonSpeed);
			//rb.velocity = Vector3.up * 0.0001F;
			Destroy(ballon, BallonLife);
			yield return new WaitForSeconds (waitToStartWave);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
