using UnityEngine;
using System.Collections;

public class BackgroundRoll : MonoBehaviour {

    public float speed;

    void Update () {
        gameObject.transform.Translate(0, -speed*Time.deltaTime, 0);
	}
}
