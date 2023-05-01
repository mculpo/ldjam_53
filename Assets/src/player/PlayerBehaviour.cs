using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerBehaviour : MonoBehaviour
{
    private Transform myTransform;

    public float speed = 5f;
    public float rotateSpeed = 150f;

    private AudioSource audioSource;

    public Direction myDirection { get; set; }

    void Update()
    {
        if (myDirection != Direction.None && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
        else if (myDirection == Direction.None && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    void Awake()
    {
        myTransform = GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
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
}
