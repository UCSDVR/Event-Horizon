﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class JPUIController : NetworkBehaviour {
    public int targetMode = 0;
    public delegate void uiSetMode();
    public static event uiSetMode OnModeCancel;
    public static event uiSetMode OnModeMove;
    public static event uiSetMode OnModeTarget;
    public static event uiSetMode OnSelectTeamOne;
    public static event uiSetMode OnSelectTeamTwo;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetModeCancel()
    {
        print("Cancel");
        OnModeCancel();
    }
    public void SetModeMove()
    {
        print("Move");
        OnModeMove();
    }
    public void SetModeTarget()
    {
        print("Target");
        OnModeTarget();
    }
    public void SetTeamOne () {
        print("Selected Team One");
        OnSelectTeamOne();
    }
    public void SetTeamTwo () {
        print("Selected Team Two");
        OnSelectTeamTwo();
    }
}