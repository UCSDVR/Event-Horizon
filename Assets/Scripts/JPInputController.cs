﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class JPInputController : NetworkBehaviour {
	JPNetworkPlayer networkPlayer;
	GameObject selectedShip;
	GameObject targetShip;
	Vector3 targetPosition;

	Plane groundPlane = new Plane (new Vector3 (0, 0, 0), new Vector3 (-100, 0, -100), new Vector3 (100, 0, -100));
	GameObject marker;
	public int playerNumber = 0;
	// Use this for initialization
	void Start () {
		if(isLocalPlayer) {
			networkPlayer = this.GetComponent<JPNetworkPlayer> ();
			marker = GameObject.Find ("Marker");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(isLocalPlayer) {
			if (Input.GetMouseButtonDown (0)) {
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				Debug.DrawRay (ray.origin, ray.direction * 100000, Color.yellow, 0.0f, false);
				float rayDistance;

				if (Physics.Raycast (ray, out hit)) {
					if (hit.collider.gameObject.transform.name.Contains ("Ship")) {
						if (hit.collider.gameObject.name.Contains ("Player" + playerNumber)) {
							selectedShip = hit.collider.gameObject;
						}
					}

				}
			} else if(Input.GetMouseButtonUp (0)) {
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				Debug.DrawRay (ray.origin, ray.direction * 100000, Color.yellow, 0.0f, false);
				float rayDistance;

				// Ship Targeted
				if (Physics.Raycast (ray, out hit)) {
					
					setTargetShip (hit.collider.gameObject);
				}
				// Position Targeted
				else if (groundPlane.Raycast (ray, out rayDistance)) {
					if (selectedShip != null) {
						setTargetPosition(ray.GetPoint (rayDistance));
					}
				}

				selectedShip = null;
				targetShip = null;

			} else if(Input.GetMouseButton (0)) {
				
				if(selectedShip) {
					RaycastHit hit;
					Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
					float rayDistance;
					groundPlane.Raycast (ray, out rayDistance);
					marker.transform.position = ray.GetPoint (rayDistance);
				}
			}
		}
	}
	void selectShip (GameObject ship) {
		networkPlayer.CmdSelectShip (ship.name);
	}
	void setTargetShip (GameObject ship) {
		networkPlayer.CmdSetTargetShip (ship.name);
	}
	void setTargetPosition (Vector3 pos) {
		networkPlayer.CmdSetPosition (pos);
	}

}
