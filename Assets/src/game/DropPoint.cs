using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DropPoint : MonoBehaviour
{
    private Order order;
    [SerializeField]
    private GameObject particleEffect;
    [SerializeField]
    private GameObject imageEffect;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerOrderHolder player = collision.gameObject.GetComponent<PlayerOrderHolder>();

            if (player.Orders.Count > 0)
            {
                List<GameObject> ordersDelivered = new List<GameObject>();

                foreach(GameObject orderGameObject in player.Orders)
                {
                    Order order = orderGameObject.GetComponent<Order>();
                    if (order.Pos == gameObject)
                    {
                        order.DisableArrowDelivering();
                        UIGameManager.instance.DisableUIDelivering(order);
                        OrderManager.instance.markPointAsAvailable(gameObject);

                        if (!audioSource.isPlaying)
                        {
                            audioSource.Play();
                        }

                        ordersDelivered.Add(orderGameObject);
                    }
                }

                if (ordersDelivered.Count > 0)
                {
                    player.Orders = player.Orders.Except(ordersDelivered).ToList();
                    OnDisableEffect();
                }
            }
        }
    }
    public void OnEnableEffect(Color color)
    {
        particleEffect.SetActive(true);
        imageEffect.SetActive(true);
        particleEffect.GetComponent<ParticleSystem>().startColor = new Color(color.r, color.g, color.b, 0.3f);
        imageEffect.GetComponent<SpriteRenderer>().color = color;
    }

    public void OnDisableEffect()
    {
        particleEffect.SetActive(false);
        imageEffect.SetActive(false);
    }
    public Order Order { get => order; set => order = value; }
}

