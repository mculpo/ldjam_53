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
        float joyHorizontal = Input.GetAxis("Horizontal");
        float joyVertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.W) || joyVertical > 0.0f)
        {
            playerBehaviour.addDirection(Direction.Up);
        }
        else if (Input.GetKeyUp(KeyCode.W) || joyVertical == 0.0f)
        {
            playerBehaviour.removeDirection(Direction.Up);
        }

        if (Input.GetKey(KeyCode.S) || joyVertical < 0.0f)
        {
            playerBehaviour.addDirection(Direction.Down);
        }
        else if (Input.GetKeyUp(KeyCode.S) || joyVertical == 0.0f)
        {
            playerBehaviour.removeDirection(Direction.Down);
        }

        if (Input.GetKey(KeyCode.A) || joyHorizontal < 0.0f)
        {
            playerBehaviour.addDirection(Direction.Left);
        }
        else if (Input.GetKeyUp(KeyCode.A) || joyHorizontal == 0.0f)
        {
            playerBehaviour.removeDirection(Direction.Left);
        }

        if (Input.GetKey(KeyCode.D) || joyHorizontal > 0.0f)
        {
            playerBehaviour.addDirection(Direction.Right);
        }
        else if (Input.GetKeyUp(KeyCode.D) || joyHorizontal == 0.0f)
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
    }

    private void resetOrientation()
    {
        vertical = 0;
        horizontal = 0;
    }
}
