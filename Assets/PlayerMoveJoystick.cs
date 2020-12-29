using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveJoystick : MonoBehaviour
{
    private float horizontalMove=0f;

    private float verticalMove = 0f;

    public Joystick joystick;


    public float runSpeedHorizontal = 2;

    public float runSpeed = 1.25f;

    public float jumpSpeed = 2;

    public float DoubleJump = 2.5f;

    private bool candoubleJump;

    Rigidbody2D rb2d;



    public SpriteRenderer SpriteRenderer;

    public Animator animator;



    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
       

        if (horizontalMove>0)
        {
            
            SpriteRenderer.flipX = false;
            animator.SetBool("Run", true);

        }
        else if (horizontalMove<0)
        {
           
            SpriteRenderer.flipX = true;
            animator.SetBool("Run", true);
        }
        else
        {
            
            animator.SetBool("Run", false);
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

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        horizontalMove = joystick.Horizontal * runSpeedHorizontal;

        transform.position += new Vector3(horizontalMove, 0, 0) * Time.deltaTime * runSpeed;


    }
    public void Jump()
    {
        if (CheckGround.isGround)
        {
            candoubleJump = true;
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
        }
        else
        {

            if (candoubleJump == true)
            {
                animator.SetBool("Double Jump", true);
                rb2d.velocity = new Vector2(rb2d.velocity.x, DoubleJump);
                candoubleJump = false;
            }


        }
    }

}
