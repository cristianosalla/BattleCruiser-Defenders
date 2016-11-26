﻿using UnityEngine;
using System.Collections;

public class ClickquitMenu : MonoBehaviour {
	public GameObject LoadIMG;

	public void LoadScene(int level)
	{
		LoadIMG.SetActive(true);
		Application.LoadLevel(level);
	}
}
