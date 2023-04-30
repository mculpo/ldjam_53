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
    private List<GameObject> availableDeliveryPoints;
    private List<GameObject> unvailableDeliveryPoints;

    void Start()
    {
        points = 0;
        currentOrders = 0;
        ordersDeliveredInTime = 0;
        ordersDeliveredLate = 0;
        AvailableDeliveryPoints = new List<GameObject>();
        UnvailableDeliveryPoints = new List<GameObject>();
        AvailableDeliveryPoints.AddRange(GameObject.FindGameObjectsWithTag("Point"));
    }

    public void addDeliveryPoint (Order order)
    {
        int randomPoint = UnityEngine.Random.Range(0, AvailableDeliveryPoints.Count - 1);
        GameObject point = AvailableDeliveryPoints[randomPoint];

        AvailableDeliveryPoints.Remove(point);
        UnvailableDeliveryPoints.Add(point);
        order.Pos = point;
    }
    
    public void markPointAsAvailable (GameObject point)
    {
        UnvailableDeliveryPoints.Remove(point);
        AvailableDeliveryPoints.Add(point);
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
    public List<GameObject> AvailableDeliveryPoints { get => availableDeliveryPoints; set => availableDeliveryPoints = value; }
    public List<GameObject> UnvailableDeliveryPoints { get => unvailableDeliveryPoints; set => unvailableDeliveryPoints = value; }
}
