using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  abstract class Enemy : MonoBehaviour
{

    public static Enemy instance;

    [SerializeField]
    protected float speed;

    [SerializeField]
    protected int coins;

    [SerializeField]
    protected Transform pointA, pointB;

    [SerializeField]
    protected float distToShoot;

    protected Vector3 currentTarget;

    protected Animator anim;

    protected SpriteRenderer sprite;

    public bool isHit = false;


    [SerializeField]
    public Vector3 direction;

    // for firing a bullet from the enemy

    protected float nextFire;
    [SerializeField]
    protected float fireRate;



    // enemy Health Scrpit

   protected EnemyHealth enumHealth;


    // playerController
    protected PlayerController player;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        enumHealth = GetComponentInChildren<EnemyHealth>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void Start()
    {
        Init();
    }


    public virtual void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anim.GetBool("InCombat") == false)
        {
            return;
        }
        
        Movement();
    }


    public virtual void Movement()
    {


        if (currentTarget == pointA.position)
        {
            sprite.flipX = true;
        }
        else if (currentTarget == pointB.position)
        {
            sprite.flipX = false;
        }

        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            anim.SetTrigger("Idle");
        }
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            anim.SetTrigger("Idle");

        }

        Direction();
        if (isHit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }


    }// Movement

    private void Direction()
    {
        if (enumHealth.currentHealth < enumHealth.fullHealth && distToShoot < 4.0f)
        {
            isHit = true;
            anim.SetBool("InCombat", true);
        }
        if (enumHealth.currentHealth < enumHealth.fullHealth  && distToShoot > 4.0f)
        {
            isHit = false;
            anim.SetBool("InCombat", false);
        }

        if(isHit == true && distToShoot > 4.0f)
        {
            isHit = false;
            anim.SetBool("InCombat", false);
        }
         if(isHit == true && anim.GetBool("InCombat") == true && distToShoot > 4f)
        {
            isHit = false;
            anim.SetBool("InCombat", false);
        }
       




        // check the distance betwn player and enemy

        distToShoot = Vector3.Distance(transform.localPosition, player.transform.localPosition);

        direction = player.transform.localPosition - transform.localPosition;

      

        if (distToShoot > 4.0f)
        {
            isHit = false;
            anim.SetBool("InCombat", false);
        }
    }





}
