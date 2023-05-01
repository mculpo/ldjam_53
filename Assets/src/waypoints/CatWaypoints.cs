using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatWaypoints : MonoBehaviour
{
    [SerializeField]
    Transform[] waypoints;

    Rigidbody2D rb;

    private Animator animator;

    [SerializeField]
    float moveSpeed = 3f;

    int waypointIndex = 0;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
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

        if (rb.velocity.x > 0 && Mathf.Abs(rb.velocity.x) > Mathf.Abs(rb.velocity.y))
        {
            animator.SetBool("isRight", true);
            animator.SetBool("isLeft", false);
            animator.SetBool("isUp", false);
            animator.SetBool("isDown", false);
        }
        else if (rb.velocity.x < 0 && Mathf.Abs(rb.velocity.x) > Mathf.Abs(rb.velocity.y))
        {
            animator.SetBool("isRight", false);
            animator.SetBool("isLeft", true);
            animator.SetBool("isUp", false);
            animator.SetBool("isDown", false);
        }
        else if (rb.velocity.y > 0 && Mathf.Abs(rb.velocity.x) < Mathf.Abs(rb.velocity.y))
        {
            animator.SetBool("isRight", false);
            animator.SetBool("isLeft", false);
            animator.SetBool("isUp", true);
            animator.SetBool("isDown", false);
        }
        else if (rb.velocity.y < 0 && Mathf.Abs(rb.velocity.x) < Mathf.Abs(rb.velocity.y))
        {
            animator.SetBool("isRight", false);
            animator.SetBool("isLeft", false);
            animator.SetBool("isUp", false);
            animator.SetBool("isDown", true);
        }
    }
}
