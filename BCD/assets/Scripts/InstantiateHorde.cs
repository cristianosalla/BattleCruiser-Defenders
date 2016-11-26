using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateHorde : MonoBehaviour {

    //instanciar inimigos
    public GameObject Enemy;
    public GameObject Enemy2;
    public List<GameObject> enemies;
    public Vector3 initialPosition = new Vector3();
    public int lines;
    public int columns;
    public float objectSize;

    public float speed;

    public bool movement = false;
    public float timeToChangeMove;
    public float currentTime = 0;
    public float currentTime2 = 0;
    public List<int> enemyRetire;

    public int enemyCount;
    public int countForBarrier;
    public GameObject tank;


    //instancia resourcesShip
    public GameObject resourcesShip;
    float timeToSpawnResourcesShip;

    void Awake ()
    {
        timeToSpawnResourcesShip = Random.Range(35, 45);

        int c = 0;
        enemyCount = lines * columns;
        int sizeOflist = enemyRetire.Count;

        for (int i = 0; i < lines*columns; i++)
        {
            if (Random.Range(0, 10) > 5)
                InstantiateEnemies(Enemy);
            else
                InstantiateEnemies(Enemy2);
        }

        enemies[0].transform.position = initialPosition;

        for (int j = 0; j < lines; j++)
        {
            for (int i = 0; i < columns; i++)
            {

                //mudar para o tamanho do objeto
                enemies[c].transform.position = new Vector3(enemies[0].transform.position.x + i * objectSize,
                                        enemies[0].transform.position.y - j * objectSize, 0);

                enemies[c].SetActive(true);

                c++;
            }
        }

        for(int i = 0; i < sizeOflist; i++)
        {
            Destroy(enemies[enemyRetire[i]]);
            enemyCount -= 1;
        }

    }

    void Update()
    {

        if (Time.time - timeToChangeMove > 5)
        { 
            int rand = Random.Range(0, enemyCount);
            if (enemies[rand].active == true  && enemies[rand].tag == "EnemyOne")
            {
                timeToChangeMove = Time.time;
                FireEnemyShot FES = enemies[rand].GetComponent<FireEnemyShot>();
                FES.Fire();
            }
        }

        if(Time.time - currentTime2 > timeToSpawnResourcesShip)
        {
            SpawnShip();
        }

    }


void InstantiateEnemies(GameObject Enemy)
    {
        GameObject enemyInstance = Instantiate(Enemy) as GameObject;
        //enemyInstance.transform.parent = GameObject.Find("Instantiate Horde").transform;
        enemies.Add(enemyInstance);
    }

    public void SpawnShip()
    { 
       currentTime2 = Time.time;
       timeToSpawnResourcesShip = Random.Range(15f, 25f);
       GameObject resourceShipInstance = Instantiate(resourcesShip) as GameObject;
    }

    public void TimeToDown()
    {
        currentTime = Time.time;

    }


}
