using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTree : MonoBehaviour
{
    public float Speed = 1;
    public float lifeTime = 3;

    public bool left;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    private void Update()
    {
        if (left)
        {
            transform.Translate(Vector2.left * Speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
        }
    }

}
