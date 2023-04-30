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
        //getInputOrientation();
        playerBehaviour.move(vertical, horizontal);
        //resetOrientation();
    }

    private void getInputOrientation()
    {
 

        if (Input.GetKey(KeyCode.W))
        {
            playerBehaviour.addDirection(Direction.Up);
        }
        else if(Input.GetKeyUp(KeyCode.W))
        {
            playerBehaviour.removeDirection(Direction.Up);
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerBehaviour.addDirection(Direction.Down);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            playerBehaviour.removeDirection(Direction.Down);
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerBehaviour.addDirection(Direction.Left);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            playerBehaviour.removeDirection(Direction.Left);
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerBehaviour.addDirection(Direction.Right);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            playerBehaviour.removeDirection(Direction.Right);
        }

        // Atualiza a direção do player com base na última direção pressionada
        if (playerBehaviour.myDirection != Direction.None)
        {
            if ((playerBehaviour.myDirection & Direction.Up) != 0)
            {
                vertical = 1;
            }

            if ((playerBehaviour.myDirection & Direction.Down) != 0)
            {
                vertical = -1;
            }

            if ((playerBehaviour.myDirection & Direction.Left) != 0)
            {
                horizontal = -1;
            }

            if ((playerBehaviour.myDirection & Direction.Right) != 0)
            {
                horizontal = 1;
            }
        }

        /*if (Input.GetKey(KeyCode.W))
        {
            vertical = 1;
            playerBehaviour.addDirection(Direction.Up);
        }
        if (Input.GetKey(KeyCode.S))
        {
            vertical = -1;
            playerBehaviour.addDirection(Direction.Down);
        }
        if (Input.GetKey(KeyCode.A))
        {
            horizontal = -1;
            playerBehaviour.addDirection(Direction.Left);
        }
        if (Input.GetKey(KeyCode.D))
        {
            horizontal = 1;
            playerBehaviour.addDirection(Direction.Right);
        }*/
    }

    private void resetOrientation()
    {
        vertical = 0;
        horizontal = 0;
    }
}
