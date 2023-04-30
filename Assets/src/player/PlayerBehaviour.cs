using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerBehaviour : MonoBehaviour
{
    private Transform myTransform;

    public float speed = 5f;
    public float rotateSpeed = 150f;

    public float originalSpeed;
    public bool isSlowed = false;

    public Direction myDirection { get; set; }

    void Awake()
    {
        myTransform = GetComponent<Transform>();

        originalSpeed = speed;
    }

    public void move(float vertical, float horizontal)
    {
        myTransform.position +=  new Vector3(speed * horizontal * Time.deltaTime, speed * vertical * Time.deltaTime, 0);
    }

    public void addDirection(Direction direction)
    {
        myDirection |= direction;
    }

    public void removeDirection(Direction direction)
    {
        myDirection &= ~direction;
    }

    public void applySlow(float time)
    {
        if (isSlowed)
        {
            speed *= 0.75f;

            Invoke("resetSpeed", time);
        }
    }

    public void resetSpeed()
    {
        speed = originalSpeed;
    }
}
