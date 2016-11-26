using UnityEngine;
using System.Collections;

public class BulletEnemyController : MonoBehaviour {

    public float speed;

    private TankController TK;

    void Update()
    {
        gameObject.transform.Translate(0, speed, 0);

    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Tank")
        {
            
            Destroy(this.gameObject);
            TankController TC = col.gameObject.GetComponent<TankController>();
            TC.BeforeDestroy();
            Destroy(col.gameObject, col.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + 0.8f);
            
        }
        if(col.gameObject.tag == "Floor")
        {
            Destroy(this.gameObject);
        }

        if (col.gameObject.tag == "Barrier")
        {
            Destroy(this.gameObject);
            BarrierBehaviour BB = col.gameObject.GetComponent<BarrierBehaviour>();
            BB.Damage();

        }
    }

}
