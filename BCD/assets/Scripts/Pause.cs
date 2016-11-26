﻿using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
	public Transform canvas;
	public Transform gameObject;
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Paused();
		}
	}
	public void Paused()
	{
		if (canvas.gameObject.activeInHierarchy == false)
		{
			canvas.gameObject.SetActive(true);
			Time.timeScale = 0;
			gameObject.GetComponent<TankController>().enabled = false;
		}
		else
		{
				canvas.gameObject.SetActive(false);
				Time.timeScale = 1;
				gameObject.GetComponent<TankController>().enabled = true;
		}
	}
}
