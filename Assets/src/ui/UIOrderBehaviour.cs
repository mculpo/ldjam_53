using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIOrderBehaviour : MonoBehaviour
{
    [SerializeField]
    private Image aroundImage;
    [SerializeField]
    private Image orderType;
    [SerializeField]
    private TextMeshProUGUI orderTime;
    private Order order;
    
    // Update is called once per frame
    void Update()
    {
        if(order != null)
        {
            DrawTime();
        }
    }
    private void OnEnable()
    {
        orderTime.color = Color.white;
    }
    public void DrawTime()
    {
        if (order.CurrentTime >= 0)
        {
            int minutes = Mathf.FloorToInt(order.CurrentTime / 60);
            int seconds = Mathf.FloorToInt(order.CurrentTime % 60);

            orderTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            orderTime.color = Color.red;
        }
    }

    public void Active(Order order)
    {
        this.order = order;
        orderType.sprite = order.RefIconShop.GetComponent<ArrowController>().spriteRenderContent.sprite;
        gameObject.SetActive(true);
    }

    public void setColorAroundImage(Color color)
    {
        aroundImage.color = color;
    }

    public Color getColorAroundImage()
    {
        return aroundImage.color;
    }

    public void Disable()
    {
        order = null;
        gameObject.SetActive(false);
    }

    public Order Order { get => order; }
}
