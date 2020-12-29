using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDamage : MonoBehaviour
{
    public Collider2D collider2D;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public GameObject destroyParticle;

    public float jumpForce = 2.5f;
    public int lives = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * jumpForce);
            LosseLiveandHit();
            CheckLive();
        }
    }
    public void LosseLiveandHit()
    {
        lives--;    
        animator.Play("Hit");
    }

    public void CheckLive()
    {
        if (lives == 0)
        {
            destroyParticle.SetActive(true);
            spriteRenderer.enabled = false;
            Invoke("EnemyDie", 0.2f);
        }
    }
    public void EnemyDie()
    {
        Destroy(gameObject);
    }







}
