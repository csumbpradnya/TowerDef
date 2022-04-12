
using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RayCasting : MonoBehaviour
{
    public int health = 3;
    public int coins = 3;
    
    public TMP_Text coinUI;

    public Slider slider;

    public AudioSource audioSrc;
    public AudioClip boing;
    private void Start()
    {
        coinUI.SetText("coins: " + coins);
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = health;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                Debug.DrawLine(Camera.main.transform.position, hitInfo.point, Color.red, 0.5f);
                if (hitInfo.collider.gameObject.tag == "enemy")
                {
                    Debug.Log("Inside");
                    health -= 1;
                    // check for health
                    if (health < 0)
                    {
                        audioSrc.clip = boing;
                        audioSrc.Play();
                        coins += 1;
                        Destroy(hitInfo.collider.gameObject);
                        coinUI.SetText("coins: " + coins);
                    }
                
                }
            }
            else
            {
                Debug.DrawLine(Camera.main.transform.position, hitInfo.point, Color.red, 0.5f);
            }
        }
        
    }

    public void reduceCoins()
    {
        coins -= 1;
    }
}
