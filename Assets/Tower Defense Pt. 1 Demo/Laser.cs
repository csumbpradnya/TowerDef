using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Laser : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;

    private RayCasting enemy;

    public AudioSource audioSrc;
    public AudioClip boing;
    public void GoTowardsTarget(Transform enemy)
    {
        target = enemy;
    }

    private void Start()
    {
        enemy = GameObject.Find("player1").GetComponent<RayCasting>();
        audioSrc = enemy.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        Debug.Log(direction.magnitude + "  " + distanceThisFrame);
        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        
    }

    void HitTarget()
    {
        Destroy(gameObject);

        enemy.health -= 1;
        enemy.slider.value = enemy.health;

        if (enemy.health <= 0)
        {
            
            
            Destroy(enemy.gameObject);
            enemy.coins += 1;
            enemy.coinUI.SetText("coins: " + enemy.coins);
            SceneManager.LoadScene("Restart");
        }

        if (enemy.health <= 1)
        {
            audioSrc.clip = boing;
            audioSrc.Play();
        }
    }
    
}