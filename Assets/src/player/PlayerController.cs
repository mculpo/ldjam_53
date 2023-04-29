using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerBehaviour))]
[RequireComponent(typeof(PlayerAnimation))]
public class PlayerController : MonoBehaviour
{
    float horizontal = 0;
    float vertical = 0;
    private PlayerBehaviour playerBehaviour;
  
    private void Awake()
    {
        playerBehaviour = GetComponent<PlayerBehaviour>();
    }
    void Update()
    {
        getInputOrientation();
        playerBehaviour.move(vertical, horizontal);
        resetOrientation();
    }

    private void getInputOrientation()
    {
        if (Input.GetKey(KeyCode.W))
        {
            vertical = 1;
            playerBehaviour.direction(Direction.Up);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            vertical = -1;
            playerBehaviour.direction(Direction.Down);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            horizontal = -1;
            playerBehaviour.direction(Direction.Left);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontal = 1;
            playerBehaviour.direction(Direction.Right);
        }

        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            playerBehaviour.direction(Direction.None);
        }
    }

    private void resetOrientation()
    {
        vertical = 0;
        horizontal = 0;
    }
}
