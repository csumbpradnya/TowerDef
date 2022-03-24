
using UnityEngine;
using TMPro;

public class RayCasting : MonoBehaviour
{
    public int health = 3;
    public int coins = 0;
    
    public TMP_Text coinUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldMousePosition =
                Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100f));
            
            Vector3 direction = worldMousePosition - Camera.main.transform.position;

            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, direction, out hit, 100f))
            {

                Debug.DrawLine(Camera.main.transform.position, hit.point, Color.green, 0.5f);
                if (hit.collider.gameObject.tag == "enemy")
                {
                    health -= 1;
                    // check for health
                    if (health < 0)
                    {
                        coins += 1;
                        Destroy(hit.collider.gameObject);
                        coinUI.SetText("coins: " + coins);
                    }

                }

            }
        }
        
    }
}
