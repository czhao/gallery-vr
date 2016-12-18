using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public float waitToStartWave = 2f;
	public GameObject harzard;
	public float BallonLife = 5f;
	private float thrust = 1f;


	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnWaves ());
	}

	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds (waitToStartWave);
		while (true) {
			//randomize the position a little bit
			float deltaX = Random.Range(-3f, 3f);
			float deltaZ = Random.Range(-3f, 3f);
			Vector3 initPosition = new Vector3 (deltaX, 0, deltaZ);
			GameObject ballon = Instantiate(harzard,  initPosition, harzard.transform.rotation) as GameObject;
			ballon.SetActive(true);
			Destroy(ballon, BallonLife);
			yield return new WaitForSeconds (waitToStartWave);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
