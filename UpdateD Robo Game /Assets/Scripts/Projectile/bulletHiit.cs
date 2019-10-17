using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHiit : MonoBehaviour {

    // damage attributes
    public float weaponDamage;

    // getting a refence
    ProjectileController myPC;

   

    // effects
    public GameObject explosionEffect;

	// Use this for initialization
	void Awake () {

        myPC = GetComponentInParent<ProjectileController>();

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        

        if(other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            myPC.RemoveForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);


            if(other.tag == "Enemy")
            {
                EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
                enemyHealth.AddDamage(weaponDamage);
               
            }
        }
    }//triggerEnter

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            myPC.RemoveForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);

            if (other.tag == "Enemy")
            {
                EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
                enemyHealth.AddDamage(weaponDamage);
            }
        }

    }

}
