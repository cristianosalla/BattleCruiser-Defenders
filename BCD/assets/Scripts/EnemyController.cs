using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    //public float speed;
    public float speedDown;
    public float periodStaying;
    public float periodMoving;
    public float currentTime;

    //controle de animacao deste objeto
    public Animator EnemyAnim;

    public bool shotNow = true;

    private InstantiateHorde IH;
    private TankController TK;
    public GameObject tank;

    void Start()
    {
        IH = GameObject.Find("Instantiate Horde").GetComponent<InstantiateHorde>();
        TK = GameObject.Find("Tank").gameObject.GetComponent<TankController>();
    }

    void Update()
    {
        if (IH.movement == false)
            gameObject.transform.Translate(-IH.speed * Time.deltaTime, 0, 0);
        
        else
            gameObject.transform.Translate(+IH.speed * Time.deltaTime, 0, 0);


        if (IH.currentTime != 0 && Time.time - IH.currentTime <= periodMoving)
            gameObject.transform.Translate(0, -speedDown * Time.deltaTime, 0);

    }

    public void OnDestroy()
    {
        this.gameObject.SetActive(false);
        Collider2D C = gameObject.GetComponent<Collider2D>();
        C.enabled = false;
        
    }

    void InactiveEnemy()
    {
        
        EnemyAnim.SetBool("OnDestroyed", true);
        gameObject.GetComponent<Collider2D>().enabled = false;
        Invoke("OnDestroy", 0.8f);
        IH.enemyCount -= 1;
        if (IH.enemyCount < 2)
        {
            IH.speed = 11;
        }
        else if (IH.enemyCount < 5)
        {
            IH.speed += 1f;
        }
        else if (IH.enemyCount < 20)
        {

            IH.speed += 0.2f;
        }

    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Bullet" )
        {
            TK.IncBarrier();
            InactiveEnemy();
        }

        if(coll.gameObject.tag == "Barrier")
        {
            InactiveEnemy();
            BarrierBehaviour BB = coll.gameObject.GetComponent<BarrierBehaviour>();
            BB.DamageEnemy();

        }
            
        if(coll.gameObject.tag == "Limit")
        {
            if (Time.time - IH.timeToChangeMove > 0.2f)
            {
                if (IH.movement == false)
                {
                    IH.movement = true;
                    IH.timeToChangeMove = Time.time;
                    IH.TimeToDown();
                }
                else
                {
                    IH.movement = false;
                    IH.timeToChangeMove = Time.time;
                    IH.TimeToDown();
                }
            }
        }
    }
}
