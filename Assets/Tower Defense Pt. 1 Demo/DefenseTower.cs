using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseTower : MonoBehaviour
{
    public Transform target;
    public float range = 250f;

    
    public float fireRate = 1f;
    public float fireCountDown = 0f;

    public GameObject laserPrefab;
    

    // Update is called once per frame
    void Update()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("enemy");

        float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

        if (distanceToEnemy <= range)
        {
            target = enemy.transform;

            if (fireCountDown <= 0f)
            {
                GameObject bulletGO = (GameObject)Instantiate(laserPrefab, transform.position, laserPrefab.transform.rotation);
                Laser bullet = bulletGO.GetComponent<Laser>();
                
                bullet.GoTowardsTarget(target);
                
                fireCountDown = 1f / fireRate;
            }

            fireCountDown -= Time.deltaTime;
        }
        else
        {
            target = null;
        }
        
        
    }

 

   
}