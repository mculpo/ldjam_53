using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private OrderManager orderManager;
    private GameObject refMyOrderArrow;
    private List<GameObject> orders;
    [SerializeField]
    private OrderType orderType;
    [SerializeField]
    private int maxAvailableOrder;
    [SerializeField]
    private float maxOrderTime;
    [SerializeField]
    private float minOrderTime;
    private float nextOrderTime;
    private float currentOrderTime;
    [SerializeField]
    private float initialOrderTime;
    private Collider2D collider;

    // Start is called before the first frame update
    void Start () {
        orderManager = GameObject.FindWithTag("OrderManager").GetComponent<OrderManager>();
        orders = new List<GameObject>();
        collider = GetComponent<Collider2D>();
        nextOrderTime = initialOrderTime;
    }

    // Update is called once per frame
    void Update() {
        if (orders.Count < maxAvailableOrder)
        {
            currentOrderTime += Time.deltaTime;
            if (currentOrderTime >= nextOrderTime)
            {
                makeOrder();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerOrderHolder player = collision.gameObject.GetComponent<PlayerOrderHolder>();

            if (orders.Count > 0 && player.Orders.Count < player.MaximumOrderCapacity)
            {
                player.holdOrder(takeOrder(player.MaximumOrderCapacity - player.Orders.Count));
                if(refMyOrderArrow != null)
                {
                    Destroy(refMyOrderArrow);
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
          
            ordersTmp.Add(order);
            bagSpace--;
        }

        orders = orders.Except(ordersTmp).ToList();
        return ordersTmp;
    }

    public void makeOrder ()
    {
        if (orderManager.AvailableDeliveryPoints.Count > 0)
        {
            GameObject gameObject = new GameObject();
            Order order = gameObject.AddComponent<Order>();

            order.Type = orderType;
            orderManager.addDeliveryPoint(order);
            orders.Add(gameObject);

            nextOrderTime = UnityEngine.Random.Range(minOrderTime, maxOrderTime);
            currentOrderTime = 0;
            createOrderArrow();
        }
    }

    public void createOrderArrow()
    {
        refMyOrderArrow = IconsFindManager.instance.getShopIcon(orderType);
        refMyOrderArrow.GetComponent<ArrowController>().target = transform;
    }
}
