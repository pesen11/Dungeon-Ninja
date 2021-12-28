using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody2D myBody;
    Animator myanimator;
    [SerializeField] float speedMultiplier = 25f;
    [SerializeField] float jumpForce = 20f;
    [SerializeField] float kunaiSpeed = 5f;
    [SerializeField] float intervalBetweenShooting = 2f;
    bool isAlive = true;
    [SerializeField] Vector2 deathVelocity = new Vector2(0, 30);
    [SerializeField] float climbSpeed = 15f;

    [SerializeField] AudioClip jumpSFX;
    [SerializeField] AudioClip shootSFX;


    float gravityScaleAtStart = 2f;

    BoxCollider2D mycollider;
    //CapsuleCollider2D myfeetcollider;
    [SerializeField] GameObject kunaiPrefab;

    bool isGrounded;
    [SerializeField] bool canFire = true;


    [SerializeField] Transform kunaiSpawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myanimator = GetComponent<Animator>();
        mycollider = GetComponent<BoxCollider2D>();
        
        gravityScaleAtStart = myBody.gravityScale;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive) { return; }
            Playerwalk();
            Jump();
            Die();
            Fire();
        climbLadder();
        
       
    }


    private void Playerwalk()
    {
        float axisValue = Input.GetAxis("Horizontal");

        float playerMove = axisValue * speedMultiplier;
        Vector2 walkSpeed = new Vector2(playerMove, myBody.velocity.y);
        myBody.velocity = walkSpeed;
        bool playerHasHorizontalVelocity = Mathf.Abs(myBody.velocity.x) > 0;
        myanimator.SetBool("isrunning", playerHasHorizontalVelocity);

        if (axisValue > 0)
        {
            Vector3 temp = transform.localScale;
            temp.x = 1;
            transform.localScale = temp;
        }
        if (axisValue < 0)
        {
            Vector3 temp = transform.localScale;
            temp.x = -1;
            transform.localScale = temp;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            
           
        }
    }
   

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                isGrounded = false;
                Vector2 jumpVelocity = new Vector2(0, jumpForce);
                myBody.velocity += jumpVelocity;
                // bool playerHasVerticalVelocity = myBody.velocity.y >= 0f;
                // myanimator.SetBool("isjumping", true);
                //AudioSource.PlayClipAtPoint(jumpSFX,transform.position);
                StartCoroutine(jumpcoroutine());
            }
        }
    }
   /* private void Jump()
    {
        if (!myfeetcollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }
        if(Input.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocity = new Vector2(0, jumpForce);
            myBody.velocity += jumpVelocity;
            /* bool playerHasVerticalVelocity = myBody.velocity.y >= 0f;
             myanimator.SetBool("isjumping", true);
             AudioSource.PlayClipAtPoint(jumpSFX, transform.position);
            jumpcoroutine();
            
        }
    }*/

    IEnumerator jumpcoroutine()
    {
        myanimator.SetBool("isjumping", true);
        AudioSource.PlayClipAtPoint(jumpSFX, transform.position);
        yield return new WaitForSeconds(0.4f);
        myanimator.SetBool("isjumping", false);
    }

    private void Die()
    {
        if (mycollider.IsTouchingLayers(LayerMask.GetMask("enemy", "hazards")))
        {
            myanimator.SetTrigger("isdead");
            myBody.velocity = deathVelocity;
            FindObjectOfType<lifeCounterScript>().processPlayerDeath();
            isAlive = false;
        }
    }

    private void climbLadder()
    {
        if (!mycollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            myanimator.SetBool("Climbing", false);
            myBody.gravityScale = gravityScaleAtStart;
            return;
        }
        float controlThrow = Input.GetAxis("Vertical") * climbSpeed;//* Time.deltaTime;
        Vector2 climbVelocity = new Vector2(myBody.velocity.x, controlThrow);
        myBody.velocity = climbVelocity;
        bool playerHasVerticalSpeed = Mathf.Abs(myBody.velocity.y) > Mathf.Epsilon;
        myanimator.SetBool("Climbing", playerHasVerticalSpeed);
        myBody.gravityScale = 0f;
    }

    private void Fire()
    {
        StartCoroutine(firecoroutine());
    }

    IEnumerator firecoroutine()
    {
        if (Input.GetKeyDown(KeyCode.Z) && canFire)
        {
            GameObject kunai = Instantiate(kunaiPrefab, kunaiSpawnPosition.position, Quaternion.identity) as GameObject;
            if (transform.localScale.x > 0)
            {
                kunai.GetComponent<Rigidbody2D>().velocity = new Vector2(kunaiSpeed, 0);

            }
            else
            {
                kunai.GetComponent<Rigidbody2D>().velocity = new Vector2(-kunaiSpeed, 0);

            }
            //AudioSource.PlayClipAtPoint(kunaiSFX, transform.position);
            myanimator.SetTrigger("isshooting");
            AudioSource.PlayClipAtPoint(shootSFX, transform.position);
            canFire = false;
            yield return new WaitForSecondsRealtime(intervalBetweenShooting);
            canFire = true;
        }
    }
}
