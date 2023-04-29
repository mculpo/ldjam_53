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
        orders = new List<GameObject>();
    }

    void Update()
    {

    }

    public void holdOrder(GameObject order)
    {
        if (orders.Count == maximumOrderCapacity)
        {
            return;
        }

        orders.Add(order);
    }

    public void dropOrder(int index)
    {
        orders.RemoveAt(index);
    }
}
