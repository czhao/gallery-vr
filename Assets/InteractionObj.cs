﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObj : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Renderer> ().material.color = Color.gray;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
