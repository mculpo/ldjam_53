using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [SerializeField]
    Transform[] waypoints;

    [SerializeField]
    Sprite upSprite;
    [SerializeField]
    Sprite downSprite;
    [SerializeField]
    Sprite rightSprite;
    [SerializeField]
    Sprite leftSprite;

    Rigidbody2D rb;
    SpriteRenderer sr;

    [SerializeField]
    float moveSpeed = 3f;

    int waypointIndex = 0;

    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        moveWaypoints();
    }

    void moveWaypoints()
    {
        rb.velocity = (waypoints[waypointIndex].transform.position - gameObject.transform.position).normalized * moveSpeed;
        
        if ((waypoints[waypointIndex].transform.position - gameObject.transform.position).magnitude < 0.1)
            waypointIndex++;

        if (waypointIndex == waypoints.Length)
            waypointIndex = 0;

        if(rb.velocity.x > 0 && Mathf.Abs(rb.velocity.x) > Mathf.Abs(rb.velocity.y))
        {
            sr.sprite = rightSprite;
        } 
        else if (rb.velocity.x < 0 && Mathf.Abs(rb.velocity.x) > Mathf.Abs(rb.velocity.y))
        {
            sr.sprite = leftSprite;
        }
        else if (rb.velocity.y > 0 && Mathf.Abs(rb.velocity.x) < Mathf.Abs(rb.velocity.y))
        {
            sr.sprite = upSprite;
        }
        else if (rb.velocity.y < 0 && Mathf.Abs(rb.velocity.x) < Mathf.Abs(rb.velocity.y))
        {
            sr.sprite = downSprite;
        }
    }
}
