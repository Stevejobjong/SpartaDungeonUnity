using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;


    public GameObject EquipPopup;
    public TMP_Text Equip_text;

    public ItemSlotUI[] inventorySlots;
    public ItemSO[] slots;
    //TODO : select 됐을 때 active할 UI에 아이템 아이콘, 이름, 설명, 증가하는 스탯 표시
    public int gold;
    private List<int> curEquipIndex;
    public int selectedItemIndex;
    public StatType selectedItemStatType;
    public float selectedItemStatValue;

    public ItemSO[] test;
    private void Awake()
    {
        curEquipIndex=new List<int>();
        instance = this;
    }
    void Start()
    {
        slots = new ItemSO[inventorySlots.Length];

        for (int i = 0; i < slots.Length; i++)
        {
            inventorySlots[i].index = i;
            inventorySlots[i].Clear();
        }
        for (int i = 0; i < test.Length; i++)
            AddItem(test[i]);
    }
    public void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] != null)
                inventorySlots[i].Set(slots[i]);
            else
                inventorySlots[i].Clear();
        }
    }
    public bool AddItem(ItemSO item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == null)
            {
                slots[i] = item;
                return true;
            }
        }
        return false;
    }
    public void EquipToggle()
    {
        if (inventorySlots[selectedItemIndex].equipped)
            UnEquip(selectedItemIndex);
        else
            OnEquip(selectedItemIndex);
    }
    public void OnEquip(int index)
    {
        //현재 장착중인 아이템이 있고, 그 아이템과 장착하려는 아이템의 타입이 같다면 UnEquip
        for(int i = 0; i < curEquipIndex.Count; i++)
        {
            if (inventorySlots[curEquipIndex[i]].equipped && inventorySlots[curEquipIndex[i]].type == inventorySlots[index].type)
            {
                UnEquip(curEquipIndex[i]);
                break;
            }
        }
        GameManager.instance.AddPlayerStat(selectedItemStatType,selectedItemStatValue);
        inventorySlots[index].equipped = true;
        curEquipIndex.Add(index);
        UpdateUI();
    }
    public void UnEquip(int index)
    {
        GameManager.instance.AddPlayerStat(selectedItemStatType, -selectedItemStatValue);
        curEquipIndex.Remove(index);
        inventorySlots[index].equipped = false;
        UpdateUI();
    }
}
