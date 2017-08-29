using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb2D;
    private Animator animator;
    private bool playerFacingRight; // Turha, koska tämä voidaan tarkistaa spriteRendere.flipX booleanista. Ehkä kuitenkin helpottaa koodin lukua
    private SpriteRenderer spriteRenderer;
    private bool jumping;
    private bool jump;
    private int gravity;
    private bool onGround;
    private float jumpStart;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerFacingRight = true;
        jumping = false;
        gravity = 2;
        onGround = false;
    }
	
	// Update is called once per frame
	void Update () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        jumping = Input.GetKeyDown(KeyCode.Space);
        onGround = Mathf.Abs(rb2D.velocity.y) <= 0.01;

        if (!onGround)
        {
            if (!animator.GetBool("playerInAir"))
                animator.SetBool("playerInAir", true);
        }
        else
        {
            if (animator.GetBool("playerInAir"))
                animator.SetBool("playerInAir", false);
        }

        moveHorizontal *= Time.deltaTime;
        moveHorizontal *= 6;

        if (moveHorizontal > 0 && !playerFacingRight)
        {
            spriteRenderer.flipX = false;
            playerFacingRight = true;
        }

        if (moveHorizontal < 0 && playerFacingRight)
        {
            spriteRenderer.flipX = true;
            playerFacingRight = false;
        }
            

        if (moveHorizontal != 0)
            if (!animator.GetBool("playerRunning"))
                animator.SetBool("playerRunning", true);
            
        
        if (moveHorizontal == 0)
            if (animator.GetBool("playerRunning"))
                animator.SetBool("playerRunning", false);

        if (jumping)
        {
            if (onGround)
            {
                jump = true;
                animator.SetTrigger("playerJump");
                rb2D.gravityScale = 0;
                jumpStart = Time.time;
            }
        }

        if (jump)
        {
            float speed = 0.5f - (Time.time - jumpStart);
            transform.Translate(0, 25f * Time.deltaTime * speed, 0);
            if (Input.GetKeyUp(KeyCode.Space) || speed <= 0)
            {
                rb2D.gravityScale = gravity;
                jump = false;
            }
        }

        transform.Translate(new Vector3(moveHorizontal, 0f, 0f));
        

    }
}
