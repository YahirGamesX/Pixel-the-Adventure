using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float runSpeed = 1;

    public float jumpSpeed = 2;

    public float DoubleJump = 2.5f;

    private bool candoubleJump;

    Rigidbody2D rb2d;



    public bool betterJump = false;

    public float fallMultipler = 0.5f;

    public float lowJumpMultipler = 1f;

    public SpriteRenderer SpriteRenderer;

    public Animator animator;

    bool isTouchingFront = false;
    bool wallSliding;
    public float wallSlidingSpeed = 0.75f;

    bool isTouchingLeft;

    bool isTouchingRight;




    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKey("space")&&wallSliding==false)
        {
            if (CheckGround.isGround)
            {
                candoubleJump = true;
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
            }
            else
            {
                if (Input.GetKeyDown("space"))
                {
                    if (candoubleJump==true)
                    {
                        animator.SetBool("Double Jump", true);  
                        rb2d.velocity = new Vector2(rb2d.velocity.x, DoubleJump);
                        candoubleJump = false;
                    }
                }

            }
            
        }
        if (CheckGround.isGround == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }
        if (CheckGround.isGround == true)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Double Jump", false);
            animator.SetBool("Falling", false);

        }
        if (rb2d.velocity.y < 0)
        {
            animator.SetBool("Falling", true);
        }

        else if (rb2d.velocity.y > 0)
        {
            animator.SetBool("Falling", false);
        }

        if (isTouchingFront == true && CheckGround.isGround == false)
        {
            wallSliding = true;
            
        }
        else
        {
            wallSliding = false;
        }
        if (wallSliding)
        {
            animator.Play("Wall");
            rb2d.velocity = new Vector2(rb2d.velocity.x, Mathf.Clamp(rb2d.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }





    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right")&&isTouchingRight==false)
        {
            rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
            SpriteRenderer.flipX = false;
            animator.SetBool("Run", true);
            
            if (CheckGround.isGround == true)
            {
            }
           
        }
        else if (Input.GetKey("a") || Input.GetKey("left")&&isTouchingLeft==false)
        {
            rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
            SpriteRenderer.flipX = true;
            animator.SetBool("Run", true);
            if (CheckGround.isGround == true)
            {
                
            }
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            animator.SetBool("Run", false);
            
        }
        


        if (betterJump==true)
        {
            if (rb2d.velocity.y < 0)
            {
                rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultipler) * Time.deltaTime;
            }
            if (rb2d.velocity.y > 0 && !Input.GetKey("space"))
            {
                rb2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultipler) * Time.deltaTime;
            }
        }

       }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Right"))
        {
            isTouchingFront = true;
            isTouchingRight = true;
        }
        if (collision.gameObject.CompareTag("Left"))
        {
            isTouchingFront = true;
            isTouchingLeft = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isTouchingFront = false;
        isTouchingLeft = false;
        isTouchingRight = false;
    }

    }

