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
        if ( (playerBehaviour.myDirection & Direction.Up) != 0)
        {
            animator.SetBool("up", true);
            animator.SetBool("down", false);
            animator.SetBool("right", false);
            animator.SetBool("left", false);
        }
        if ((playerBehaviour.myDirection & Direction.Down) != 0)
        {
            animator.SetBool("left", false);
            animator.SetBool("right", false);
            animator.SetBool("up", false);
            animator.SetBool("down", true);
        }
        if ((playerBehaviour.myDirection & Direction.Left) != 0)
        {
            animator.SetBool("right", false);
            animator.SetBool("left", true);
            animator.SetBool("up", false);
            animator.SetBool("down", false);
        }
        if ((playerBehaviour.myDirection & Direction.Right) != 0)
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
