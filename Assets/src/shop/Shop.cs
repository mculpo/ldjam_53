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
        //Debug.Log(currentOrderTime);
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
            if (orders.Count > 0)
            {
                PlayerOrderHolder player = collision.gameObject.GetComponent<PlayerOrderHolder>();
                player.holdOrder(takeOrder());
            }
        }
    }

    public GameObject takeOrder ()
    {
        if (orders.Count > 0)
        {
            GameObject order = orders[orders.Count - 1];
            orders.RemoveAt(orders.Count - 1);

            //Debug.Log("Pedido " + order + " retirado com sucesso!");

            return order;
        }

        return null;
    }

    public void makeOrder ()
    {
        nextOrderTime = UnityEngine.Random.Range(minOrderTime, maxOrderTime);
        GameObject gameObject = new GameObject();
        Order order = gameObject.AddComponent<Order>();

        //orders.Add(order);
        Debug.Log("Pedido: " + orderType + " criado");
        currentOrderTime = 0;
    }
}
