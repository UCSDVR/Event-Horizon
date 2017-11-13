﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShoot : MonoBehaviour {
	
	public GameObject laser;
	public float laserSpeed = 100;

	// Use this for initialization
	void Start()
	{

	}

	// Fires a laser
	public void Fire()
	{
		GameObject tempLaser = (GameObject)Instantiate(laser, transform.position, transform.rotation);
		Rigidbody tempLaserRigidbody = tempLaser.GetComponent<Rigidbody>();
		tempLaserRigidbody.AddForce(tempLaserRigidbody.transform.forward * laserSpeed);
		Destroy(tempLaser, 3f);
	}

	//Update is called once per frame
	void Update()
	{

	}
}