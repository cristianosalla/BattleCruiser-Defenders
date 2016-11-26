using UnityEngine;
using System.Collections;

public class BarrierBehaviour : MonoBehaviour {

    public int damageCount;
    private TankController TK;


    void Awake () {
        TK = GameObject.Find("Tank").gameObject.GetComponent<TankController>();
        damageCount = 3;
        if(damageCount <= 0)
        {
            Destroy(this.gameObject);
        }
	}
	
    public void Damage()
    {
        damageCount -= 1;
        if(damageCount <= 0)
        {
            Destroy(this.gameObject);
            TK.barriersOnGame--;
        }

    }

    public void DamageEnemy()
    {

        damageCount -= 3;
        if (damageCount <= 0)
        {
            Destroy(this.gameObject);
            TK.barriersOnGame--;
        }

    }

}
