using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CandyHealth : MonoBehaviour
{
    
    private EnemyDemo enemy;
    private float health = 6f;
    public Slider candyHealth;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find("player1").GetComponent<EnemyDemo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.speed == 1)
        {
            health -= Time.deltaTime;
            candyHealth.value = health;
        }

        if (health == 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Restart");
        }
    }
}