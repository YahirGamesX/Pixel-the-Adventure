using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    public Animator animator;

    public SpriteRenderer spriteRenderer;

    public float speed = 1f;
    private float waitTime;

    public Transform[] moveSpots;

    public float StartwaitTime = 2;

    private int i = 0;

    private Vector2 actualPos;



    void Start()
    {
        animator.SetBool("Idle", true);
        waitTime = StartwaitTime;
    }


    void Update()
    {
       
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[i].transform.position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                if (moveSpots[i] != moveSpots[moveSpots.Length - 1])
                {
                    i++;
                }
                else
                {
                    i = 0;
                }
                waitTime = StartwaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }


    }
    






        
}
