using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    private int points;
    private int ordersDeliveredInTime;
    private int ordersDeliveredLate;
    [SerializeField]
    private int maxOrders;
    private int currentOrders;

    void Start()
    {
        points = 0;
        currentOrders = 0;
        ordersDeliveredInTime = 0;
        ordersDeliveredLate = 0;
    }

    public int getTotalOrdersDelivered()
    {
        return ordersDeliveredInTime + ordersDeliveredLate;
    }

    public void incrementOrderDeliveredInTime()
    {
        ordersDeliveredInTime++;
    }

    public void incrementOrderDeliveredLate()
    {
        ordersDeliveredLate++;
    }

    public void addPoints(int points)
    {
        this.points += points;
    }

    public void incrementCurrentOrders ()
    {
        currentOrders++;
    }

    public void decrementCurrentOrders ()
    {
        currentOrders--;
    }

    public int Points { get => points; set => points = value; }
    public int OrdersDeliveredInTime { get => ordersDeliveredInTime; set => ordersDeliveredInTime = value; }
    public int OrdersDeliveredLate { get => ordersDeliveredLate; set => ordersDeliveredLate = value; }
    public int MaxOrders { get => maxOrders; set => maxOrders = value; }
    public int CurrentOrders { get => currentOrders; set => currentOrders = value; }
}
