using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboEnemy : Enemy
{

    public GameObject bullet;

   

    private EnemyProjectile enemyProjectile;
    // use for initalization


    
    public override void Init()
    {
        base.Init();
    }

   

    public override void Update()
    {
        base.Update();
        EnemyAI();
       



    }// update

    private void EnemyAI()
    {
        if (anim.GetBool("InCombat") == true)
        {
            if (Time.time > nextFire)
            {

                // this way we can give gaps betweem the fires
                nextFire = Time.time + fireRate;
                if (direction.x < 0)
                {


                    Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                }
                else if (direction.x > 0)
                {

                    Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
                }


            }

        }
    }
}
