using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Shop : MonoBehaviour
{
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
        nextOrderTime = UnityEngine.Random.Range(minOrderTime, maxOrderTime);
        GameObject gameObject = new GameObject();
        Order order = gameObject.AddComponent<Order>();
        order.Type = orderType;
        orders.Add(gameObject);
        currentOrderTime = 0;
        Debug.Log(orderType);
    }
}
