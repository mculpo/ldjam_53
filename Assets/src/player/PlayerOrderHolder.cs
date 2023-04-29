using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOrderHolder : MonoBehaviour
{
    [SerializeField]
    private int maximumOrderCapacity;
    private List<GameObject> orders;

    private void Start()
    {
        Orders = new List<GameObject>();
    }

    void Update()
    {

    }

    public void holdOrder(List<GameObject> orders)
    {
        if (Orders.Count == MaximumOrderCapacity)
        {
            return;
        }

        Orders.AddRange(orders);
    }

    public void dropOrder(int index)
    {
        Orders.RemoveAt(index);
    }

    public int MaximumOrderCapacity { get => maximumOrderCapacity; set => maximumOrderCapacity = value; }
    public List<GameObject> Orders { get => orders; set => orders = value; }
}
