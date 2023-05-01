using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIFinalBehaviour : MonoBehaviour
{
    public TextMeshProUGUI delivered;
    public TextMeshProUGUI late;
    public TextMeshProUGUI total;
    public TextMeshProUGUI points;


    // Update is called once per frame
    void Update()
    {
        int ordersDeliveredInTime = OrderManager.ordersDeliveredInTime;
        int ordersDeliveredLate = OrderManager.ordersDeliveredLate;

        int pointInTime = ordersDeliveredInTime * 50;
        int pointLate = ordersDeliveredLate * 10;

        delivered.text = ordersDeliveredInTime.ToString("000000");
        late.text = ordersDeliveredLate.ToString("000000");
        total.text = (ordersDeliveredInTime + ordersDeliveredLate).ToString("000000");
        points.text = (pointInTime + pointLate).ToString("000000");
    }
}

