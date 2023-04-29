using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerBehaviour playerBehaviour;
    private Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        playerBehaviour = GetComponent<PlayerBehaviour>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerBehaviour.myDirection.Equals(Direction.Up))
        {
            animator.SetBool("up", true);
            animator.SetBool("down", false);
            animator.SetBool("right", false);
            animator.SetBool("left", false);
        }
        if (playerBehaviour.myDirection.Equals(Direction.Down))
        {
            animator.SetBool("left", false);
            animator.SetBool("right", false);
            animator.SetBool("up", false);
            animator.SetBool("down", true);
        }
        if (playerBehaviour.myDirection.Equals(Direction.Left))
        {
            animator.SetBool("right", false);
            animator.SetBool("left", true);
            animator.SetBool("up", false);
            animator.SetBool("down", false);
        }
        if (playerBehaviour.myDirection.Equals(Direction.Right))
        {
            animator.SetBool("down", false);
            animator.SetBool("up", false);
            animator.SetBool("right", true);
            animator.SetBool("left", false);
        }
        if (playerBehaviour.myDirection.Equals(Direction.None))
        {
            animator.SetBool("up", false);
            animator.SetBool("down", false);
            animator.SetBool("right", false);
            animator.SetBool("left", false);
        }
    }
}
