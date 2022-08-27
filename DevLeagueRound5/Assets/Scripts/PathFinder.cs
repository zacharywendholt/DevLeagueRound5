using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] EnemyConfig enemyConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;
    

    
    
    // Start is called before the first frame update
    void Start()
    {
        waypoints = enemyConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;

    }

    // Update is called once per frame
    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        Vector3 targetPosition;
        if(waypointIndex == waypoints.Count - 1)
        {
            waypoints[waypointIndex] = GameObject.FindWithTag("Baloon").transform;
            
        }
        if(waypointIndex < waypoints.Count)
        {
            targetPosition = waypoints[waypointIndex].position;
            float delta = enemyConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if(transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            
            // it damages the balloon
            Destroy(gameObject);
        }
    }
}
