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

    private GameObject finalCandy;
    // Start is called before the first frame update
    void Start()
    {
        finalCandy = GameObject.Find("Chocolate (6)");
        enemy = GameObject.Find("player1").GetComponent<EnemyDemo>();
        Debug.Log(finalCandy);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.speed == 1)
        {
            health -= Time.deltaTime;
            candyHealth.value = health;
        }

        if (candyHealth.value == 0)
        {
            Destroy(finalCandy);
            SceneManager.LoadScene("Restart");
        }
    }
}