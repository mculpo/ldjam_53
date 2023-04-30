using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    private OrderType type;
    private float maxTime;
    private float currentTime;
    private GameObject pos;

    public Order (OrderType type)
    {
        this.type = type;
    }

    void Start()
    {
        CurrentTime = MaxTime;
    }

    void Update()
    {
        
    }

    public OrderType Type { get => type; set => type = value; }
    public float MaxTime { get => maxTime; set => maxTime = value; }
    public float CurrentTime { get => currentTime; set => currentTime = value; }
    public GameObject Pos { get => pos; set => pos = value; }
}
