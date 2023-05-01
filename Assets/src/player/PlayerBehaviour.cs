using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerBehaviour : MonoBehaviour
{
    private Transform myTransform;

    public float speed = 5f;
    public float rotateSpeed = 150f;

    private float originalSpeed;
    public bool isSlowed = false;

    private Renderer visualShader;  
    private Material originalShader;
    public Material pulseEffect;

    public Direction myDirection { get; set; }

    void Awake()
    {
        myTransform = GetComponent<Transform>();

        originalSpeed = speed;

        visualShader = GetComponent<Renderer>();
        originalShader = visualShader.material;
    }

    public void move(float vertical, float horizontal)
    {
        Debug.Log(speed);
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
        if (!isSlowed)
        {
            isSlowed = true;

            speed *= 0.75f;

            applyPulseEffect();

            Invoke("resetSpeed", time);
            Invoke("resetShader", time);
        }
    }

    public void resetSpeed()
    {
        isSlowed = false;
        speed = originalSpeed;
    }

    public void applyPulseEffect()
    {
        visualShader = GetComponent<Renderer>();
        visualShader.material = pulseEffect;
    }

    public void resetShader()
    {
        visualShader = GetComponent<Renderer>();
        visualShader.material = originalShader;
    }
}
