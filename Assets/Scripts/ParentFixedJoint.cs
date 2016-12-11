using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class ParentFixedJoint : MonoBehaviour {

	SteamVR_TrackedObject trackObject;
	SteamVR_Controller.Device device;

	FixedJoint fixedJoint;
	public Rigidbody rigidBoddyAttachment;
	public Transform sphere;

	// Use this for initialization
	void Awake () {
		trackObject = GetComponent<SteamVR_TrackedObject> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		SteamVR_Controller.Device device = SteamVR_Controller.Input ((int)trackObject.index);
		if (device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad)) {
			Debug.Log ("touchpad up!");
			sphere.transform.position = Vector3.zero;
			sphere.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			sphere.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
		}

	}

	void onTriggerStay(Collider col){
		if (fixedJoint == null && device.GetTouch (SteamVR_Controller.ButtonMask.Trigger)) {
			fixedJoint = col.gameObject.AddComponent<FixedJoint> ();
			fixedJoint.connectedBody = rigidBoddyAttachment;
		} else if (fixedJoint != null && device.GetTouchUp (SteamVR_Controller.ButtonMask.Trigger)) {
			GameObject go = fixedJoint.gameObject;
			Rigidbody rigidBody = go.GetComponent<Rigidbody> ();
			Object.Destroy (fixedJoint);
			fixedJoint = null;
			tossObject (rigidBody);
		}
	}

	void tossObject(Rigidbody rigidBody)
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
