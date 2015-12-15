﻿using UnityEngine;
using System.Collections;
using System;
public class Delete : MonoBehaviour {
	public double Lifetime =0;
	ConfigManager cm;
	// Use this for initialization
	void Start () {
		cm = GetComponent<ConfigManager> ();//Gets the ConfigManager
		float Duration = 1.0f;//Stores the lifespan of the puffer cloud
		Lifetime = Time.time + Duration;//Sets the delete timer to the future
	}
	
	// Update is called once per frame
	void Update () {
		if (Lifetime < Time.time)//Destroys the cloud when it's time is up
			Destroy (gameObject);
	}
}