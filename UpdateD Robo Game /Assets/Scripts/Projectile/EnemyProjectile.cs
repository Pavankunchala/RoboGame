using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyProjectile : MonoBehaviour
{

    public float projectileSpeed = .5f;
    private Rigidbody2D myRB;

    public Vector3 direction;

    private SpriteRenderer bulletSprite;



    

    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        bulletSprite = GetComponentInChildren<SpriteRenderer>();
            }

    // Update is called once per frame
    void Update()
    {

         

        if (Enemy.instance.direction.x <0)
        {
            myRB.AddForce(new Vector2(.5f, 0) * -projectileSpeed , ForceMode2D.Impulse);
            bulletSprite.flipX = true;
        }
        else if(Enemy.instance.direction.x>0)
        {
            myRB.AddForce(new Vector2(.5f, 0) * projectileSpeed, ForceMode2D.Impulse);
            bulletSprite.flipX = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            RemoveForce();
            Destroy(gameObject);
        }
    }

    public void RemoveForce()
    {
        myRB.velocity = new Vector2(0, 0);
    }
}
