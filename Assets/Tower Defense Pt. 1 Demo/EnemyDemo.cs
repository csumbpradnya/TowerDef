using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDemo : MonoBehaviour
{

    // todo #1 set up properties
    //   health, speed, coin worth
    public float speed = 3f;
   
    public List<Transform> waypointList;
    private int targetWaypointIndex;

    public Animator animator;

    
    
    

    // NOTE! This code should work for any speed value (large or small)

    //-----------------------------------------------------------------------------
    void Start()
    {
        // todo #2
        //   Place our enemy at the starting waypoint
        transform.position = waypointList[0].transform.position;
        targetWaypointIndex = 1;
        animator = GetComponent<Animator>();
    }

    //-----------------------------------------------------------------------------
    void Update()
    {

        animator.SetFloat("speed", speed);
        
        // todo #3 Move towards the next waypoint
        
        
        // todo #4 Check if destination reaches or passed and change target
        // https://www.youtube.com/watch?v=GIDz0DjhA4E

        transform.position = Vector3.MoveTowards(transform.position, waypointList[targetWaypointIndex].transform.position, speed * Time.deltaTime);

        if (transform.position == waypointList[targetWaypointIndex].transform.position && targetWaypointIndex<6)
        {
            targetWaypointIndex++;
        }
        
        if (!(targetWaypointIndex < 6) && transform.position == waypointList[targetWaypointIndex].transform.position)
        {
            speed = 1;
        }

        animator.SetFloat("speed", speed);
      
        
    }


}
