using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerBehaviour : MonoBehaviour
{
    private Transform myTransform;

    public float speed = 5f;
    public float rotateSpeed = 150f;

    public Direction myDirection { get; set; }

    void Awake()
    {
        myTransform = GetComponent<Transform>();
    }

    public void move(float vertical, float horizontal)
    {
        myTransform.position +=  new Vector3(speed * horizontal * Time.deltaTime, speed * vertical * Time.deltaTime, 0);
    }

    public void direction(Direction direction)
    {
        myDirection = direction;
    }
}
