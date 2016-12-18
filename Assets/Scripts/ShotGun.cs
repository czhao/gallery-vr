using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using UnityEngine.UI;

public class ShotGun : VRTK_InteractableObject {

	public GameObject bulletObject;
	public GameObject bulletSpawn;
	private float bulletSpeed = 200f;
	private float bulletLife = 1f;
	public GameObject scoreBoard;
	private int count;

	public override void StartUsing(GameObject usingObject)
	{
		base.StartUsing(usingObject);
		FireBullet();
	}

	private void FireBullet()
	{
		GameObject bullet = Instantiate(bulletObject, bulletSpawn.transform.position, bulletObject.transform.rotation) as GameObject;
		bullet.SetActive(true);

		Rigidbody rb = bullet.GetComponent<Rigidbody>();
		rb.AddForce(bulletSpawn.transform.forward * bulletSpeed);

		//perform raycast
		Vector3 fwd = bulletSpawn.transform.TransformDirection(Vector3.forward);
		RaycastHit hit;
		
		if (Physics.Raycast (rb.transform.position, fwd, out hit, 100f)) {
			GameObject victim =  hit.transform.gameObject;
			if (victim.CompareTag("Ballon")){
				Destroy (victim, 0.1f);
				Debug.Log ("hit!!");
				Text score = scoreBoard.GetComponent<Text> ();
				count++;
				score.text = "" + count;
			}
		}
		Destroy(bullet, bulletLife);
	}
}
