using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    public Button button;
    public Image image;
    private ItemSO curItem;
    public GameObject equipMark;
    public int index;
    public bool equipped;
    public ItemType type => curItem.ItemType;
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
        Inventory inven = Inventory.instance;
        inven.selectedItemIndex = index;
        if (curItem == null)
            return;
        if (equipped)
            inven.Equip_text.text = "장착 해제 하시겠습니까?";
        else
            inven.Equip_text.text = "장착 하시겠습니까?";
        inven.EquipPopup.SetActive(true);
    }
    public void OnClickedYesButton()
    {
        Inventory inven = Inventory.instance;
        inven.EquipPopup.SetActive(false);
        inven.EquipToggle();
    }
    public void OnClickedNoButton()
    {
        Inventory inven = Inventory.instance;
        inven.EquipPopup.SetActive(false);
    }
}
