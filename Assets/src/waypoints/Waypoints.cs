using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [SerializeField]
    Transform[] waypoints;

    [SerializeField]
    float moveSpeed = 3f;

    int waypointIndex = 0;

    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    void Update()
    {
        moveWaypoints();
    }

    void moveWaypoints()
    {
        transform.position = Vector2.MoveTowards(transform.position, 
                                                waypoints[waypointIndex].transform.position, 
                                                moveSpeed * Time.deltaTime);
        
        if (transform.position == waypoints[waypointIndex].transform.position)
            waypointIndex++;

        if (waypointIndex == waypoints.Length)
            waypointIndex = 0;
    }
}
