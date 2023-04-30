using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconsFindManager : Singleton<IconsFindManager>
{
    public GameObject shopIcon;
    public GameObject arrowFindIcon;
    public Sprite hamburguer;
    public Sprite pizza;

    // Start is called before the first frame update
    void Awake()
    {
        PoolManager.instance.createList("ShopIcon", shopIcon, 10);
        PoolManager.instance.createList("ArrowFindIcon", arrowFindIcon, 4);
    }

    public GameObject getShopIcon(OrderType orderType)
    {
        GameObject go = PoolManager.instance.GetObjectDictionary("ShopIcon");
        if(go != null)
        {
            go.GetComponent<ArrowController>()
                .spriteRenderContent
                .sprite = orderType.Equals(OrderType.Pizza) ? pizza : hamburguer;
            go.SetActive(true);
        }
        return go;
    }

    public GameObject getArrowFindIcon()
    {
        return PoolManager.instance.GetObjectDictionary("ArrowFindIcon");
    }

}
