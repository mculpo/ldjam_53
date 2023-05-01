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
    public Material powerUpEffect1;
    public Material powerUpEffect;

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
            CancelInvoke("resetSpeed");

            isSlowed = true;

            speed *= 0.75f;

            applyPulseEffect(pulseEffect);

            Invoke("resetSpeed", time);
            Invoke("resetShader", time);
        }
    }

    public void applySpeed(float time)
    {
        if (!isSpeeded)
        {
            CancelInvoke("resetSpeed");

            isSpeeded = true;

            speed *= 1.5f;

            applyPulseEffect(powerUpEffect);

            Invoke("resetSpeed", time);
            Invoke("resetShader", time);
        }
    }

    public void applyInvencibility(float time)
    {
        if (!isIvencible)
        {
            CancelInvoke("resetInvencibility");

            isIvencible = true;

            applyPulseEffect(powerUpEffect1);

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

    public void applyPulseEffect(Material m)
    {
        visualShader.material = m;
    }

    public void resetShader()
    {
        visualShader.material = originalShader;
    }
}
