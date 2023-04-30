using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : Singleton<OrderManager>
{
    [SerializeField]
    private int maxOrders;
    private List<Order> currentOrders;
    private int points;
    private int ordersDeliveredInTime;
    private int ordersDeliveredLate;
    private List<GameObject> availableDeliveryPoints;
    private List<GameObject> unvailableDeliveryPoints;
    private List<GameObject> shops;

    
    [SerializeField]
    private float maxOrderTime;
    [SerializeField]
    private float minOrderTime;
    private float nextOrderTime;
    private float currentOrderTime;
    [SerializeField]
    private float initialOrderTime;

    void Start()
    {
        points = 0;
        currentOrders = new List<Order>();
        ordersDeliveredInTime = 0;
        ordersDeliveredLate = 0;
        AvailableDeliveryPoints = new List<GameObject>();
        UnvailableDeliveryPoints = new List<GameObject>();
        AvailableDeliveryPoints.AddRange(GameObject.FindGameObjectsWithTag("Point"));
        Shops = new List<GameObject>();
        Shops.AddRange(GameObject.FindGameObjectsWithTag("Shop"));
        NextOrderTime = InitialOrderTime;
    }

    void Update()
    {
        Debug.Log(CurrentOrders.Count);
        if (currentOrders.Count < MaxOrders)
        {
            CurrentOrderTime += Time.deltaTime;
            if (CurrentOrderTime >= NextOrderTime)
            {
                int randomShopIndex = UnityEngine.Random.Range(0, Shops.Count);
                Shop shop = Shops[randomShopIndex].GetComponent<Shop>();

                currentOrders.Add(shop.makeOrder());

                NextOrderTime = UnityEngine.Random.Range(MinOrderTime, MaxOrderTime);
                CurrentOrderTime = 0;
            }
        }
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
        currentOrders.Remove(point.GetComponent<DropPoint>().Order);
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

    public int Points { get => points; set => points = value; }
    public int OrdersDeliveredInTime { get => ordersDeliveredInTime; set => ordersDeliveredInTime = value; }
    public int OrdersDeliveredLate { get => ordersDeliveredLate; set => ordersDeliveredLate = value; }
    public int MaxOrders { get => maxOrders; set => maxOrders = value; }
    public List<Order> CurrentOrders { get => currentOrders; set => currentOrders = value; }
    public List<GameObject> AvailableDeliveryPoints { get => availableDeliveryPoints; set => availableDeliveryPoints = value; }
    public List<GameObject> UnvailableDeliveryPoints { get => unvailableDeliveryPoints; set => unvailableDeliveryPoints = value; }
    public List<GameObject> Shops { get => shops; set => shops = value; }
    public float MaxOrderTime { get => maxOrderTime; set => maxOrderTime = value; }
    public float MinOrderTime { get => minOrderTime; set => minOrderTime = value; }
    public float NextOrderTime { get => nextOrderTime; set => nextOrderTime = value; }
    public float CurrentOrderTime { get => currentOrderTime; set => currentOrderTime = value; }
    public float InitialOrderTime { get => initialOrderTime; set => initialOrderTime = value; }
}
