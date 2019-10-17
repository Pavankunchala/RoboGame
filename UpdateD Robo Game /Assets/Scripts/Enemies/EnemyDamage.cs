using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float enemyDamage;
    public float damageRate;
    public float pushBackForce;

    //public GameObject explostionEfffect;

    private float nextDamage;


    [SerializeField]
    private float fireRate = .5f;
    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        nextDamage = 0f;
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && nextDamage <= Time.time)
        {
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            playerHealth.AddDamage(enemyDamage);
            nextDamage = Time.time + damageRate;


            //Instantiate(explostionEfffect, transform.position, Quaternion.identity);

            PushBack(other.transform);
            
        }
    }

    void PushBack(Transform pushedObject)
    {
        Vector2 pushDirection = new Vector2(0, (pushedObject.position.y - transform.position.y)).normalized;
        pushDirection *= pushBackForce;

        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
    }
}
