using UnityEngine;
using System.Collections;

public class ClickButton : MonoBehaviour {

	public GameObject LoadIMG;

	public void LoadScene(int level)
	{
		LoadIMG.SetActive(true);
		Application.LoadLevel(level);
	}
}
