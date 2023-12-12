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

    public ItemSlotUI[] uiSlots;
    public ItemSO[] slots;
    //TODO : select ���� �� active�� UI�� ������ ������, �̸�, ����, �����ϴ� ���� ǥ��
    public TMP_Text selectedItemName;
    public TMP_Text selectedItemDescription;
    public Image AttackIcon;
    public Image DefenseIcon;
    public Image CriticalIcon;
    public int gold;
    private List<int> curEquipIndex;
    public int selectedItemIndex;

    public ItemSO test;
    private void Awake()
    {
        curEquipIndex=new List<int>();
        instance = this;
    }
    void Start()
    {
        slots = new ItemSO[uiSlots.Length];

        for (int i = 0; i < slots.Length; i++)
        {
            uiSlots[i].index = i;
            uiSlots[i].Clear();
        }
        AddItem(test);
    }
    public void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] != null)
                uiSlots[i].Set(slots[i]);
            else
                uiSlots[i].Clear();
        }
    }
    public void AddItem(ItemSO item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == null)
            {
                slots[i] = item;
                return;
            }
        }
    }
    public void EquipToggle()
    {
        if (uiSlots[selectedItemIndex].equipped)
            UnEquip(selectedItemIndex);
        else
            OnEquip(selectedItemIndex);
    }
    public void OnEquip(int index)
    {
        //���� �������� �������� �ְ�, �� �����۰� �����Ϸ��� �������� Ÿ���� ���ٸ� UnEquip
        for(int i = 0; i < curEquipIndex.Count; i++)
        {
            if (uiSlots[curEquipIndex[i]].equipped && uiSlots[curEquipIndex[i]].type == uiSlots[index].type)
            {
                UnEquip(curEquipIndex[i]);
                break;
            }
        }

        uiSlots[index].equipped = true;
        curEquipIndex.Add(index);
        UpdateUI();
    }
    public void UnEquip(int index)
    {
        curEquipIndex.Remove(index);
        uiSlots[index].equipped = false;
        UpdateUI();
    }
}
