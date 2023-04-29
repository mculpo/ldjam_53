using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    private int points;
    private int ordersDeliveredInTime;
    private int ordersDeliveredLate;

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

    public int Points { get => points; set => points = value; }
    public int OrdersDeliveredInTime { get => ordersDeliveredInTime; set => ordersDeliveredInTime = value; }
    public int OrdersDeliveredLate { get => ordersDeliveredLate; set => ordersDeliveredLate = value; }
}
