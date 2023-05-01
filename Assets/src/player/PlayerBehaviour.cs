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

    private float originalSpeed;
    public bool isSlowed = false;
    public bool isSpeeded = false;
    public bool isIvencible = false;

    [SerializeField]
    private SpriteRenderer visualShader;
    private Material originalShader;
    public Material pulseEffect;

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

        originalSpeed = speed;
        originalShader = visualShader.material;
    }

    public void move(float vertical, float horizontal)
    {
        Debug.Log(speed);
        myTransform.position += new Vector3(speed * horizontal * Time.deltaTime, speed * vertical * Time.deltaTime, 0);
    }

    public void addDirection(Direction direction)
    {
        myDirection |= direction;
    }

    public void removeDirection(Direction direction)
    {
        myDirection &= ~direction;
    }

    public void applyTime(float time)
    {
        gameObject.GetComponent<PlayerOrderHolder>().increaseOrderTime(time);
    }

    public void applySlow(float time)
    {
        if (!isSlowed && !isIvencible)
        {
            isSlowed = true;

            speed *= 0.75f;

            applyPulseEffect(new Color(70, 20, 0, 1));

            Invoke("resetSpeed", time);
            Invoke("resetShader", time);
        }
    }

    public void applySpeed(float time)
    {
        if (!isSpeeded)
        {
            isSpeeded = true;

            speed *= 1.5f;

            applyPulseEffect(new Color(30, 80, 180, 1));

            Invoke("resetSpeed", time);
            Invoke("resetShader", time);
        }
    }

    public void applyInvencibility(float time)
    {
        if (!isIvencible)
        {
            isIvencible = true;

            applyPulseEffect(new Color(20, 20, 50, 0.6F));

            Invoke("resetInvencibility", time);
            Invoke("resetShader", time);
        }
    }

    public void resetSpeed()
    {
        isSlowed = false;
        isSpeeded = false;
        speed = originalSpeed;
    }

    public void resetInvencibility()
    {
        isIvencible = false;
    }

    public void applyPulseEffect(Color color)
    {
        visualShader.color = color;
        visualShader.material = pulseEffect;
    }

    public void resetShader()
    {
        visualShader.color = Color.white;
        visualShader.material = originalShader;
    }
}
