using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private OrderManager orderManager;
    [SerializeField]
    private TimeManager timeManager;

    // Start is called before the first frame update
    void Start()
    {
        orderManager = GetComponent<OrderManager>();
        timeManager = GetComponent<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public OrderManager OrderManager { get => orderManager; set => orderManager = value; }
    public TimeManager TimeManager { get => timeManager; set => timeManager = value; }
}
