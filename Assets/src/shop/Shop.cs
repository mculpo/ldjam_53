using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private OrderManager orderManager;
    private GameObject refMyOrderArrow;

    [SerializeField]
    private OrderType orderType;
    private List<GameObject> orders;

    [SerializeField]
    private GameObject particleEffect;
    [SerializeField]
    private GameObject imageEffect;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start () {
        orders = new List<GameObject>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerOrderHolder player = collision.gameObject.GetComponent<PlayerOrderHolder>();

            if (orders.Count > 0 && player.Orders.Count < player.MaximumOrderCapacity)
            {
                player.holdOrder(takeOrder(player.MaximumOrderCapacity - player.Orders.Count));

                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            }
        }
    }

    public List<GameObject> takeOrder (int bagSpace)
    {
        List<GameObject> ordersTmp = new List<GameObject>();

        foreach (GameObject order in orders)
        {
            if (bagSpace == 0) break;
            Order order_aux = order.GetComponent<Order>();
            order_aux.DisableArrowOrder();
            UIGameManager.instance.DisableUIOrder(order_aux);
            order_aux.EnableArrowDelivering();
            UIGameManager.instance.EnableUIDelivering(order_aux);
            order_aux.Pos.GetComponent<DropPoint>().OnEnableEffect(order_aux.RefIconTarget.GetComponent<ArrowController>().spriteRenderContent.color);
            ordersTmp.Add(order);
            bagSpace--;
        }
        OnDisableEffect();
        orders = orders.Except(ordersTmp).ToList();
        return ordersTmp;
    }

    public Order makeOrder ()
    {
        if (OrderManager.instance.AvailableDeliveryPoints.Count > 0)
        {
            GameObject gameObject = new GameObject();
            Order order = gameObject.AddComponent<Order>();
            order.Type = orderType;
            order.ShopTarget = this.gameObject;
            order.MaxTime = UnityEngine.Random.Range(10, 15);
            OrderManager.instance.addDeliveryPoint(order);
            order.EnableArrowOrder();
            UIGameManager.instance.EnableUIOrder(order);
            orders.Add(gameObject);
            OnEnableEffect();
            return order;
        }
        return null;
    }

    public void OnEnableEffect()
    {
        particleEffect.SetActive(true);
        imageEffect.SetActive(true);
    }

    public void OnDisableEffect()
    {
        particleEffect.SetActive(false);
        imageEffect.SetActive(false);
    }
}
