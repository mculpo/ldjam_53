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

    // Start is called before the first frame update
    void Start () {
        orders = new List<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerOrderHolder player = collision.gameObject.GetComponent<PlayerOrderHolder>();

            if (orders.Count > 0 && player.Orders.Count < player.MaximumOrderCapacity)
            {
                player.holdOrder(takeOrder(player.MaximumOrderCapacity - player.Orders.Count));
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
            order_aux.DisableIconShop();
            order_aux.EnableIconTarget();
            ordersTmp.Add(order);
            bagSpace--;
        }

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
            order.MaxTime = UnityEngine.Random.Range(30, 60);
            OrderManager.instance.addDeliveryPoint(order);
            order.EnableIconShop();
            orders.Add(gameObject);
            return order;
        }
        return null;
    }
}
