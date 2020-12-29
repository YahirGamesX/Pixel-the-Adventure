using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageSpikes : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("player"))
        {
           
            collision.transform.GetComponent<PlayerEdwe>().PlayerDamage();
            

        }
    }
}
