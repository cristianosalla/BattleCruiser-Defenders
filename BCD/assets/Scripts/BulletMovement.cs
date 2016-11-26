using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

    public float speed;
	private TankController TK;


	void Update () {
        gameObject.transform.Translate(0, speed, 0);

        if (gameObject.transform.position.y > 6){
           DestroyBullet();
		}
	}

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag == "EnemyTwo" )
        {
            DestroyBullet();
        }

        if (col.gameObject.tag == "EnemyOne")
        {
            DestroyBullet();
        }

    }

	void DestroyBullet(){
		TK = GameObject.Find("Tank").GetComponent<TankController>();
		Destroy(this.gameObject);
		TK.shotCount--;
	}
}
