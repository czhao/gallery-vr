using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class PickupParent : MonoBehaviour {

	SteamVR_TrackedObject trackObject;

	public Transform sphere;

    void Awake()
    {
		trackObject = GetComponent<SteamVR_TrackedObject> ();
    }

	void FixedUpdate(){
		SteamVR_Controller.Device device = SteamVR_Controller.Input ((int)trackObject.index);

		if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger)){
			Debug.Log ("You Touched! !");
		}

		if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)){
			Debug.Log ("touch down!");
		}

		if (device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad)) {
			Debug.Log ("touchpad up!");
			sphere.transform.position = Vector3.zero;
			sphere.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			sphere.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
		}

	}

	void OnTriggerStay(Collider col){
		Debug.Log ("you have collide with "+col.name + "and activated onTriggerStay");

		SteamVR_Controller.Device device = SteamVR_Controller.Input ((int)trackObject.index);


		if (device.GetTouch (SteamVR_Controller.ButtonMask.Trigger)) {
			Debug.Log ("You have collide with " + col.name + " while holding down touch");
			col.attachedRigidbody.isKinematic = true;
			col.gameObject.transform.SetParent (this.gameObject.transform);
		}

		if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger)) {
			col.gameObject.transform.SetParent (null);
			col.attachedRigidbody.isKinematic = false;

			tossObject (col.attachedRigidbody, device);
		}
	}


	void tossObject(Rigidbody rigidBody, SteamVR_Controller.Device device)
	{
		Transform origin = trackObject.origin ? trackObject.origin : trackObject.transform.parent;
		if (origin != null) {
			rigidBody.velocity = origin.TransformVector (device.velocity);
			rigidBody.angularVelocity = origin.TransformVector (device.angularVelocity);
		} else {
			rigidBody.velocity = device.velocity;
			rigidBody.angularVelocity = device.angularVelocity;
		}
	}

}
