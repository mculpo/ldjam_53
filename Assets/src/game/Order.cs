using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    private OrderType type;
    private GameObject shopTarget;
    private float maxTime;
    private float currentTime;
    private GameObject pos;
    private GameObject refIconShop;
    private GameObject refIconTarget;

    public Order (OrderType type)
    {
        this.type = type;
    }

    void Start()
    {
        CurrentTime = MaxTime;
    }

    void Update ()
    {
        if (CurrentTime <= 0)
        {
            return;
        }

        CurrentTime -= Time.deltaTime;
    }

    public void DisableArrowDelivering()
    {
        refIconTarget.SetActive(false);
    }
    public void DisableArrowOrder()
    {
        refIconShop.SetActive(false);
    }

    public void EnableArrowOrder()
    {
        refIconShop = IconsFindManager.instance.getShopIcon(type);
        refIconShop.GetComponent<ArrowController>().target = shopTarget.transform;
        refIconShop.SetActive(true);
    }

    public void EnableArrowDelivering()
    {
        refIconTarget = IconsFindManager.instance.getArrowFindIcon();
        refIconTarget.GetComponent<ArrowController>().target = pos.transform;
        refIconTarget.SetActive(true);
    }

    public OrderType Type { get => type; set => type = value; }
    public float MaxTime { get => maxTime; set => maxTime = value; }
    public float CurrentTime { get => currentTime; set => currentTime = value; }
    public GameObject Pos { get => pos; set => pos = value; }
    public GameObject ShopTarget { get => shopTarget; set => shopTarget = value; }
    public GameObject RefIconShop { get => refIconShop; set => refIconShop = value; }
    public GameObject RefIconTarget { get => refIconTarget; set => refIconTarget = value; }

}
