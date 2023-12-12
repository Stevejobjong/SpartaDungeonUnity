using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    private EquipPopup PopupUI;
    private Inventory inven;
    public GameObject equipMark;
    public Button button;
    public Image image;
    private ItemSO curItem;

    public int index;
    public bool equipped;
    public ItemType type => curItem.ItemType;

    private void Start()
    {
        inven = Inventory.instance;
        PopupUI = inven.EquipPopup.GetComponent<EquipPopup>();
    }
    private void OnEnable()
    {
        equipMark.SetActive(equipped);
    }
    public void Set(ItemSO slot)
    {
        curItem = slot;
        image.gameObject.SetActive(true);
        image.sprite = slot.icon;

        if (equipMark != null)
        {
            equipMark.SetActive(equipped);
        }
    }
    public void Clear()
    {
        curItem = null;
        image.gameObject.SetActive(false);
    }
    public void OnClicked()
    {
        //inven = Inventory.instance;
        inven.selectedItemIndex = index;
        //PopupUI = inven.EquipPopup.GetComponent<EquipPopup>();
        if (curItem == null)
            return;
        if (equipped)
            inven.Equip_text.text = "장착 해제 하시겠습니까?";
        else
            inven.Equip_text.text = "장착 하시겠습니까?";

        PopupUI.EquipItemIcon.sprite = curItem.icon;
        PopupUI.EquipItemName.text = curItem.name;
        PopupUI.EquipItemDescription.text= curItem.description;
        if (curItem.AdditionalPower > 0)
        {
            PopupUI.EquipStatIcon.sprite = Resources.Load<Sprite>("sword");
            PopupUI.EquipStatValue.text = curItem.AdditionalPower.ToString();
            inven.selectedItemStatValue = curItem.AdditionalPower;
            inven.selectedItemStatType = StatType.Power;
        }
        else if (curItem.AdditionalDefense > 0)
        {
            PopupUI.EquipStatIcon.sprite = Resources.Load<Sprite>("belt");
            PopupUI.EquipStatValue.text = curItem.AdditionalDefense.ToString();
            inven.selectedItemStatValue = curItem.AdditionalDefense;
            inven.selectedItemStatType = StatType.Defense;
        }
        else if (curItem.AdditionalCriticalHit > 0)
        {
            PopupUI.EquipStatIcon.sprite = Resources.Load<Sprite>("clover");
            PopupUI.EquipStatValue.text = curItem.AdditionalCriticalHit.ToString();
            inven.selectedItemStatValue = curItem.AdditionalCriticalHit;
            inven.selectedItemStatType = StatType.CriticalHit;
        }
        PopupUI.gameObject.SetActive(true);
    }

}
