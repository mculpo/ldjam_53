using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOrderHolder : MonoBehaviour
{
    [SerializeField]
    private int maximumOrderCapacity;
    private List<Order> orders;

    private void Start()
    {
        orders = new List<Order>();
    }

    void Update()
    {
       
    }

    public void holdOrder(Order order)
    {
        if(orders.Count == maximumOrderCapacity)
        {
            return;
        }

        orders.Add(order);
        //Debug.Log("Pedido " + order + " pego com sucesso!");
    }

    public void dropOrder(int index)
    {
        orders.RemoveAt(index);
    }
}
