using UnityEngine;
using System.Collections;

public class FireEnemyShot : MonoBehaviour{

    public GameObject bullet;


    public void Fire()
    {
        Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
    }
}
