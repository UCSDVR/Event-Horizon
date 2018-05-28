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

    public static event uiSetMode OnDefendMode;
    public static event uiSetMode OnAttackMode;
    public static event uiSetMode OnSpeedMode;

    public static event uiSetMode OnSkillZero;
    public static event uiSetMode OnSkillOne;
    public static event uiSetMode OnSkillTwo;
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
    public void SetDefendMode()
    {
        print("Defend");
        OnDefendMode();
    }
    public void SetAttackMode()
    {
        print("Attack");
        OnAttackMode();
    }
    public void SetSpeedMode()
    {
        print("Speed");
        OnSpeedMode();
    }

    public void SetSkillZero() {
        OnSkillZero();
    }
    public void SetSkillOne()
    {
        OnSkillOne();
    }
    public void SetSkillTwo()
    {
        OnSkillTwo();
    }
}
