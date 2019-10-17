using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // movment variable
    public float maxSpeed;

    // jumping varbles
    [SerializeField]
    private float jumpForce = 5f;
    [SerializeField]
    private LayerMask groundLayer;
    private bool resetJump = false;
    [SerializeField]
    private bool canJump = false; 

    // Bullet prefab
    public GameObject projectile;
    [SerializeField]
    public Transform bulletposition;
    [SerializeField]
    private float fireRate = .5f;
    private float nextFire = 0f;



    private Rigidbody2D myRB;
    // my Animation
    private Animator myAnim;
    private bool facingRight;

    // access the sprite
    private SpriteRenderer playerSprite;


    // audio source
    private AudioSource myAS;
   [SerializeField]
    private AudioClip fireClip;
	// Use this for initialization
	void Start () {
        myAnim = GetComponent<Animator>();
        myRB = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        myAS = GetComponent<AudioSource>();
        facingRight = true;

        //canJump = false;
        //myAnim.SetBool("Jump", canJump);


    }

    private void Update()
    {
        Movement();
        IsGrounded();

        PlayerShoot();
    }



    // Update is called once per frame


    private void Movement()
    {
        float move = Input.GetAxis("Horizontal");
        // for  movement
        myAnim.SetFloat("speed", Mathf.Abs(move));
       

        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);

        if (move > 0)
        {
            facingRight = true;
            playerSprite.flipX = false;

        }
        else if (move < 0)
        {
            facingRight = false;
            playerSprite.flipX = true;
        }
          
       
        if (Input.GetAxis("Jump") > 0 && IsGrounded() == true)
        {
            //canJump = true;
            //myAnim.SetBool("Jump", canJump);
            myRB.velocity = new Vector2(myRB.velocity.x, jumpForce);
            StartCoroutine(ResetJumpRoutine());
            canJump = false;

        }
        if (Input.GetAxis("Fire1") > 0 && move >0)
        {
            facingRight = true;
           myAnim.SetBool("Fire", true);
          
        }
        else if(Input.GetAxis("Fire1") > 0 && move < 0)
        {
            facingRight = false;
            myAnim.SetBool("Fire", true);
           
        }


    }// Movement

    private bool IsGrounded()
    {
      RaycastHit2D hitinfo =   Physics2D.Raycast(transform.position, Vector2.down, 1.2f, 1 << 8);

        if(hitinfo.collider != null)
        {
           
            if (resetJump == false)
            {

                return true;
            }

        }
        return false;
    }// Is Grounded

    private void PlayerShoot()
    {
    if(Input.GetAxisRaw("Fire1")>0)
        {
            if (Time.time > nextFire)
            {

                // this way we can give gaps betweem the fires
                nextFire = Time.time + fireRate;
                if(facingRight)
                {
                    Instantiate(projectile, bulletposition.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                }
                else if(!facingRight)
                {
                    Instantiate(projectile, bulletposition.position, Quaternion.Euler(new Vector3(0, 0,180f)));
                }

                
                myAS.PlayOneShot(fireClip);
                myAnim.SetBool("Fire", true);
            }


        }
    else
        {
            myAnim.SetBool("Fire", false);
        }



    }//player shoot 

    IEnumerator ResetJumpRoutine()
    {
        resetJump = true;

        yield return new WaitForSeconds(.1f);
        resetJump = false;
    }


}//PlayerController

//
