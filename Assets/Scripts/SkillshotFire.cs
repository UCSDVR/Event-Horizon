﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SkillshotFire : NetworkBehaviour {

    public GameObject torpedoPrefab;
    public float torpedoSpeed;
    public float torpedoDamage;

    public GameObject minePrefab;
    public float mineDamage;

    public float beamRange;
    public float beamDamage;

    public float healRate;
    public float healRadius, healHeight;
    public float healTime;

    public float magRate;
    public float magRadius, magHeight;
    public float magTime;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //
    public void FireTorpedo(Vector3 position, Vector3 direction)
    {
        print("Fire Torpedo");
        GameObject torpedo = (GameObject)Instantiate(torpedoPrefab, position, transform.rotation);
        torpedo.transform.LookAt(direction);
        torpedo.GetComponent<Rigidbody>().AddForce(torpedo.transform.forward * torpedoSpeed);
        //torpedo.GetComponent<Projectile>().autoTurn = true;
        torpedo.GetComponent<Projectile>().targetPos = direction;
        NetworkServer.Spawn(torpedo);
        print("Fire End");

    }

    // RaycastAll & loop through objects hit
    public void FireBeam(Vector3 origin, Vector3 direction)
    {
        // spawn particles?
        Ray ray = new Ray(origin, direction);
        RaycastHit[] hits = Physics.RaycastAll(ray, beamRange);
        foreach (RaycastHit r in hits)
        {
            // Deal damage to ships hit
            JPShip ship = r.collider.gameObject.GetComponent<JPShip>();
            if (ship != null)
            {
                ship.health -= (int)beamDamage;
            }
        }
    }

    public void PlaceMine(Vector3 position)
    {
        GameObject mine = (GameObject)Instantiate(minePrefab, position, Quaternion.Euler(Vector3.zero));
    }

    public void HealArea()
    {
        GameObject heal = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        Collider healCollider = heal.GetComponent<Collider>();

        healCollider.isTrigger = true;

        heal.transform.localScale = new Vector3(healRadius, healHeight, healRadius);
        Destroy(heal.GetComponent<MeshRenderer>());
        heal.transform.parent = gameObject.transform;
        heal.transform.localPosition = Vector3.zero;
        BuffDebuff healComponent = heal.AddComponent<BuffDebuff>();
        healComponent.healAmount = healRate;
        healComponent.teamNum = GetComponent<JPShip>().teamNum;

        Destroy(heal, healTime);
    }

    public void MagneticField()
    {
        GameObject mag = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        Collider magCollider = mag.GetComponent<Collider>();

        magCollider.isTrigger = true;

        mag.transform.localScale = new Vector3(magRadius, magHeight, magRadius);
        Destroy(mag.GetComponent<MeshRenderer>());
        mag.transform.parent = gameObject.transform;
        mag.transform.localPosition = Vector3.zero;
        BuffDebuff magComponent = mag.AddComponent<BuffDebuff>();
        magComponent.speedAmount = magRate;

        Destroy(mag, magTime);
    }
}
