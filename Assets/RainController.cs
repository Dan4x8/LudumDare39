﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainController : Controller
{
	public Dialogbox DialogBox;
	public GameObject Emily;

	// Use this for initialization
	void Start () {
		PauseTimer = true;
		IsPaused = true;
		ShowDialog(24);
	}
	
	// Update is called once per frame
	void Update () {
		if(!IsPaused)
		{
			Emily.SetActive(true);
		}
	}

	public void ShowDialog(int key, Dictionary<string, string> dict = null)
	{
		Dialogbox db = Instantiate(DialogBox, GameObject.FindGameObjectWithTag("DialogCanvas").transform);
		db.Controller = this;
		db.ShowDialog(key, dict);
	}

	public override void Execute(string action, int[] param)
	{
		switch(action)
		{
			case "Emily":
				EmilyAction();
				break;
			default:
				ShowDialog(param[0]);
				break;
		}
	}

	private int EmilySteps = 0;


	private void EmilyAction()
	{
		if(EmilySteps >= 3)
		{
			return;
		}
		EmilySteps++;
		if(EmilySteps >= 3)
		{
			ShowDialog(25);
		}
		Emily.transform.localScale = new Vector3(.8f + EmilySteps * .1f, .8f + EmilySteps * .1f, .8f + EmilySteps * .1f);
	}

}
