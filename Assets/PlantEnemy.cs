using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : MonoBehaviour
{
    private float waitedTime;

    public float waitTimetoAttack = 1;

    public Animator animator;
    public GameObject bulletPrefab;

    public Transform launchSpawnPoint;

    private void Start()
    {
        waitedTime = waitTimetoAttack;
    }

    private void Update()
    {
        if (waitedTime <= 0)
        {
            waitedTime = waitTimetoAttack;
            animator.Play("Attack");
            Invoke("LaunchBullet", 0.5f);

        }
        else
        {
            waitedTime -= Time.deltaTime;
        }

        
    }
    public void LaunchBullet()
    {
        GameObject newBullet;
        newBullet = Instantiate(bulletPrefab, launchSpawnPoint.position, launchSpawnPoint.rotation);    


        
    }

}
