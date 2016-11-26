using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ResourceShipBehaviour : MonoBehaviour {

    public GameObject package;
    float positionDropPackage;
    bool timeToAdd = true;


    void Awake()
    {
        positionDropPackage = Random.Range(-7, 7);
    }

	void Update () {
        gameObject.transform.Translate(0.04f, 0, 0);

        if (timeToAdd == true)
        {
            if (gameObject.transform.position.x > positionDropPackage)
            {
                DropPackage();

            }
        }

        if(gameObject.transform.position.x > 10)
        {
            Destroy(gameObject);
        }
	}

    void DropPackage()
    {
        GameObject packageInstance = Instantiate(package) as GameObject;
        packageInstance.transform.position = gameObject.transform.position;
        timeToAdd = false;
    }
}
