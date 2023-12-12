using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    protected Inventory inven;
    protected ItemSO curItem;

    public Image image;
    public int index;
    public ItemType type => curItem.ItemType;
    protected void Start()
    {
        inven = Inventory.instance;
    }

}
