using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DropPoint : MonoBehaviour
{
    private OrderManager orderManager;
    private Order order;

    void Start()
    {
        orderManager = GameObject.FindWithTag("OrderManager").GetComponent<OrderManager>();
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
                        orderManager.markPointAsAvailable(gameObject);
                        ordersDelivered.Add(orderGameObject);
                    }
                }

                if (ordersDelivered.Count > 0)
                {
                    player.Orders = player.Orders.Except(ordersDelivered).ToList();
                }
            }
        }
    }

    public Order Order { get => order; set => order = value; }
}
