using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beeattack : MonoBehaviour
{

    public Animator animator;

    public float distanceRayCast = 0.5f;
    private float cooldownAttack = 1.5f;

    private float actualCooldownAttack;

    public GameObject beeBullet;

    // Start is called before the first frame update
    void Start()
    {
        actualCooldownAttack = 0;
    }

   
    void Update()
    {
        actualCooldownAttack -= Time.deltaTime;
        Debug.DrawRay(transform.position, Vector2.down, Color.blue, distanceRayCast);
    }
    private void FixedUpdate()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.down, distanceRayCast);
        if (hit2D.collider != null)
        {
            if (hit2D.collider.CompareTag("player"))
            {
                if (actualCooldownAttack < 0)
                {
                    Invoke("LaunchBullet", 0.2f);
                    animator.Play("Attack");
                    actualCooldownAttack = cooldownAttack;
                }
            }
        }
    }
    void LaunchBullet()
    {
        GameObject newBullet;

        newBullet = Instantiate(beeBullet, transform.position, transform.rotation);
    }
}
