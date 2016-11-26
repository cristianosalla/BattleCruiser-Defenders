using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class GridObject : MonoBehaviour {
	
	public float cellSize = 1f;
	private float x, y, z;
	
	void Start() {
		x = 0f;
		y = 0f;
		z = 0f;
		
	}
	
	void Update () {
		//Calculo do GRID para os objetos instanciados
		x = Mathf.Round(transform.position.x / cellSize) * cellSize;
		y = Mathf.Round(transform.position.y / cellSize) * cellSize;
		z = transform.position.z;
		transform.position = new Vector3(x, y, z);
	}
	
}