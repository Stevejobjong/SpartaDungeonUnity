using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;


    [Header("Inventory Info")]
    public TMP_Text InventorySpace;
    public ItemSlotUI[] inventorySlots;
    public ItemSO[] slots;
    public int gold;
    [SerializeField] TMP_Text goldText;
    [SerializeField] private List<int> curEquipIndex;

    [Header("Popup Info")]
    public GameObject EquipPopup;
    public TMP_Text Equip_text;

    [Header("Selected Item Info")]
    public int selectedItemIndex;

    //시작하자마자 가지고있을 아이템 테스트
    public ItemSO[] test;
    private void Awake()
    {
        curEquipIndex = new List<int>();
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
    public void SetGold()
    {
        if (gold <= 0)
            goldText.text = "0";
        else
            goldText.text = string.Format("{0:#,###}", gold);
    }

    //UI 갱신
    public void UpdateUI()
    {
        int cnt = 0;
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] != null)
            {
                cnt++;
                inventorySlots[i].Set(slots[i]);
            }
            else
                inventorySlots[i].Clear();
        }
        InventorySpace.text = $"{cnt}/{inventorySlots.Length}";
    }

    //아이템 추가
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

    //장착 토글
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
        for (int i = 0; i < curEquipIndex.Count; i++)
        {
            if (inventorySlots[curEquipIndex[i]].equipped && inventorySlots[curEquipIndex[i]].type == inventorySlots[index].type)
            {
                UnEquip(curEquipIndex[i]);
                break;
            }
        }
        GameManager.instance.AddPlayerStat(slots[index], 1);
        inventorySlots[index].equipped = true;
        curEquipIndex.Add(index);
        UpdateUI();
    }
    public void UnEquip(int index)
    {
        GameManager.instance.AddPlayerStat(slots[index], -1);
        curEquipIndex.Remove(index);
        inventorySlots[index].equipped = false;
        UpdateUI();
    }
}
