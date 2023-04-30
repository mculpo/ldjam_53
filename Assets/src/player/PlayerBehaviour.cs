using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerBehaviour : MonoBehaviour
{
    private Transform myTransform;
    private Rigidbody2D rigidBody2D;

    public float speed = 5f;
    public float rotateSpeed = 150f;

    public Direction myDirection { get; set; }

    void Awake()
    {
        myTransform = GetComponent<Transform>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    public void move(float vertical, float horizontal)
    {
        rigidBody2D.velocity =  new Vector3(0, 3, 0);
    }

    public void addDirection(Direction direction)
    {
        myDirection |= direction;
    }

    public void removeDirection(Direction direction)
    {
        myDirection &= ~direction;
    }
}
