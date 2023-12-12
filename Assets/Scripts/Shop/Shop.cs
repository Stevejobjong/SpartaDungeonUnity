using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Shop instance;
    public ShopSlotUI[] shopSlots;
    public ItemSO[] slots;
    [SerializeField] GameObject successUI;
    [SerializeField] GameObject faildUI;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            shopSlots[i].index = i;
            shopSlots[i].SetItem(slots[i]);
            shopSlots[i].SetShopItemInfo();
        }
    }
    public void PurchaseResult(bool isSuccess)
    {
        if(isSuccess)
            successUI.SetActive(true);
        else
            faildUI.SetActive(true);
    }
}
