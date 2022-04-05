using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTower : MonoBehaviour
{
    public GameObject tower;

    private RayCasting coins;
    // Start is called before the first frame update
    void Start()
    {
        tower = GetComponent<GameObject>();
        coins = GameObject.Find("player1").GetComponent<RayCasting>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (coins.coins > 0)
                {
                    Debug.DrawLine(Camera.main.transform.position, hitInfo.point, Color.red, 0.5f);
                    Instantiate(tower, hitInfo.point, Quaternion.identity);
                    coins.reduceCoins();
                    coins.coinUI.SetText("coins: " + coins.coins);
                    Debug.Log("Cost of Tower = $1");
                }

            }
        }
    }
}
