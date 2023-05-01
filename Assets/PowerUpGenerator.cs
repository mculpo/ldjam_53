using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpGenerator : MonoBehaviour
{
    [SerializeField]
    private Sprite timeSprite;
    [SerializeField]
    private Sprite invencibilitySprite;
    [SerializeField]
    private Sprite SpeedSprite;


    private AudioSource auds;
    private SpriteRenderer sr;

    [SerializeField]
    private PowerUpGeneratorType type;

    [SerializeField]
    private float delay;
    private float currentTime;

    private bool active;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        active = true;
        sr = gameObject.GetComponent<SpriteRenderer>();
        auds = gameObject.GetComponent<AudioSource>();
        generate();
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            return;
        }

        currentTime += Time.deltaTime;
        if(currentTime >= delay)
        {
            generate();
        }
    }

    void generate()
    {
        if(type == PowerUpGeneratorType.SPEED)
        {
            sr.sprite = SpeedSprite;
        }
        else if (type == PowerUpGeneratorType.TIME)
        {
            sr.sprite = timeSprite;
        }
        else if (type == PowerUpGeneratorType.INVENCIBILITY)
        {
            sr.sprite = invencibilitySprite;
        }

        active = true;
        currentTime = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!active)
        {
            return;
        }

        if (collision.gameObject.tag == "Player")
        {
            if (type == PowerUpGeneratorType.SPEED)
            {
                collision.gameObject.GetComponent<PlayerBehaviour>().applySpeed(15);
            }
            else if (type == PowerUpGeneratorType.TIME)
            {
                collision.gameObject.GetComponent<PlayerBehaviour>().applyTime(45);
                GameObject.Find("Gerenciador").GetComponent<OrderManager>().applyTime(45);
            }
            else if (type == PowerUpGeneratorType.INVENCIBILITY)
            {
                collision.gameObject.GetComponent<PlayerBehaviour>().applyInvencibility(15);
            }

            active = false;
            sr.sprite = null;

            if (!auds.isPlaying)
            {
                auds.Play();
            }
        }
    }

}
