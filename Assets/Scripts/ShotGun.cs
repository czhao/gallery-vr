using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ShotGun : VRTK_InteractableObject {

	public GameObject bulletObject;
	public GameObject bulletSpawn;
	private float bulletSpeed = 200f;
	private float bulletLife = 1f;

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
			}
		}
		Destroy(bullet, bulletLife);
	}
}
