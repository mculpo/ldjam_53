using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class UIGameManager : Singleton<UIGameManager>
{
    [SerializeField]
    private PlayerOrderHolder player;
    [SerializeField]
    private TextMeshProUGUI order;
    [SerializeField]
    private TextMeshProUGUI currentTime;
    [SerializeField]
    private TextMeshProUGUI maxOrder;
    [SerializeField]
    private List<GameObject> objectsOrdersReady;
    [SerializeField]
    private List<GameObject> objectsOrdersDelivering;
    [SerializeField]
    private List<Color> availableColors = new List<Color>();
    private List<Color> usedColors = new List<Color>();


    void Update()
    { 
        DrawTime();
        DrawOrders();
        maxOrder.text = player.AmountOrder.ToString() + "/" + player.MaximumOrderCapacity.ToString();
    }

    public void DrawTime()
    {
        int minutes = Mathf.FloorToInt(TimeManager.instance.CurrentlGameTime / 60);
        int seconds = Mathf.FloorToInt(TimeManager.instance.CurrentlGameTime % 60);

        currentTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void DrawOrders()
    {
        order.text = OrderManager.instance.getTotalOrdersDelivered().ToString("00000");
    }

    public void EnableUIOrder(Order order)
    {
        GameObject use = objectsOrdersReady.FirstOrDefault(g => !g.activeSelf);
        if(use != null)
        {
            UIOrderBehaviour uIOrderBehaviour = use.GetComponent<UIOrderBehaviour>();
            uIOrderBehaviour.Active(order);
        }
    }

    public void DisableUIOrder(Order order)
    {
        GameObject obj = objectsOrdersReady.Find(g => g.activeSelf && g.GetComponent<UIOrderBehaviour>().Order.GetHashCode().Equals(order.GetHashCode()));
        if (obj != null)
        {
            UIOrderBehaviour uIOrderBehaviour = obj.GetComponent<UIOrderBehaviour>();
            uIOrderBehaviour.Disable();
        }
    }

    public void EnableUIDelivering(Order order)
    {
        GameObject use = objectsOrdersDelivering.FirstOrDefault(g => !g.activeSelf);
        if (use != null)
        {
            UIOrderBehaviour uIOrderBehaviour = use.GetComponent<UIOrderBehaviour>();
            Color color = getRandomColorToUsed();
            uIOrderBehaviour.Active(order);
            order.RefIconTarget.GetComponent<ArrowController>().spriteRenderContent.color = color;
            uIOrderBehaviour.setColorAroundImage(color);
        }
    }

    public void DisableUIDelivering(Order order)
    {
        GameObject obj = objectsOrdersDelivering.Find(g => g.activeSelf && g.GetComponent<UIOrderBehaviour>().Order.GetHashCode().Equals(order.GetHashCode()));
        if (obj != null)
        {
            UIOrderBehaviour uIOrderBehaviour = obj.GetComponent<UIOrderBehaviour>();
            usedColors.Remove(uIOrderBehaviour.getColorAroundImage());
            uIOrderBehaviour.Disable();
        }
    }

    public Color getRandomColorToUsed()
    {
        Color colorToMove = new Color(0,0,0);
        List<Color> unusedColors = availableColors.Except(usedColors).ToList();

        if (unusedColors.Count > 0)
        {
            int randomIndex = Random.Range(0, unusedColors.Count);
            colorToMove = unusedColors[randomIndex];
            usedColors.Add(colorToMove);
        }
        return colorToMove;
    }

}

