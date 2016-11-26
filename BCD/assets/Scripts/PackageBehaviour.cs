using UnityEngine;
using System.Collections;

public class PackageBehaviour : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Tank"){
            Destroy(gameObject);

        }

    }

    void Update()
    {
        if (gameObject.transform.position.y < -2f)
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
    } 
}
