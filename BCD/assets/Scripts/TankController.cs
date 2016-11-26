using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TankController : MonoBehaviour {

    public float speed;
    public GameObject bullet;
    public int shotCount;
    public float limitLeft, limitRight;

    //instancia da barreira
    public GameObject barrier;
    public List<GameObject> barriers;

    public int barrierCount;
    public int enemyCount;
    public int barriersOnGame;

	public bool isShottingFire;
	public bool isRighting, isLefting;

    //aqui pega o controle da animação deste objeto
    public Animator anim;
    
    //variavel para mover ou não o jogador
    private bool move = true;

    void Awake()
    {
        enemyCount = 0;
        barrierCount = 0;
        barriersOnGame = 0;
    }

    void Update () {

        if (move == true)
        {
            //if (Input.GetAxisRaw("Horizontal") > 0)
            //    gameObject.transform.Translate(speed, 0, 0);

            //if (Input.GetAxisRaw("Horizontal") < 0)
            //    gameObject.transform.Translate(-speed, 0, 0);
            //trocar por FIRE
            //if ((Input.GetKeyDown(KeyCode.Space)) && (shotCount < 1))
            //    Fire(shotCount++);

			if (isRighting)
				gameObject.transform.Translate(speed, 0, 0);

			if (isLefting)
				gameObject.transform.Translate(-speed, 0, 0);

			if ((isShottingFire == true) && (shotCount < 1)) {
				Fire (shotCount++);
			}

            if (Input.GetKeyDown(KeyCode.A))
            {             
                InstantiateBarrier();
            }

        }
        if(gameObject.transform.position.x < limitLeft)
          gameObject.transform.position = new Vector3 (limitLeft, gameObject.transform.position.y, gameObject.transform.position.z);
        else if(gameObject.transform.position.x > limitRight)
          gameObject.transform.position = new Vector3 (limitRight, gameObject.transform.position.y, gameObject.transform.position.z);

    }


	public void Left(){
		isLefting = true;
	}

	public void DesLeft(){
		isLefting = false;
	}

	public void Right(){
		isRighting = true;
	}

	public void DesRight(){
		isRighting = false;
	}

	public void FireClick(){
		isShottingFire = true;
	}

	public void DesFireClick(){
		isShottingFire = false;
	}

    public void Fire(int shotCount) {
      Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
       
    }

    public void IncBarrier()
    {
        if(enemyCount < 8)
        {
            enemyCount++;

        }else if(barrierCount <= 2)
        {
            enemyCount = 0;
            barrierCount++;

        }

    }

    public void BeforeDestroy()
    {
        anim.SetBool("OnDestroyed", true);
        move = false;

    }
   
    public void InstantiateBarrier()
    {
        if (barrierCount > 0 && barriersOnGame < 3)
        {
            GameObject barrierInstance = Instantiate(barrier) as GameObject;
            barrierInstance.transform.position = new Vector2(gameObject.transform.position.x, barrierInstance.transform.position.y);
            barriers.Add(barrierInstance);
            barrierCount--;
            barriersOnGame++;
        }
    }
}
