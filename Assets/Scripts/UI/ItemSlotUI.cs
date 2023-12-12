using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : SlotUI
{
    private EquipPopup PopupUI;
    public GameObject equipMark;

    public bool equipped;

    private new void Start()
    {
        base.Start();
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
        inven.selectedItemIndex = index;
        if (curItem == null)
            return;
        if (equipped)
            inven.Equip_text.text = "장착 해제 하시겠습니까?";
        else
            inven.Equip_text.text = "장착 하시겠습니까?";

        if (curItem.AdditionalPower > 0)
        {
            PopupUI.SetPopup(curItem.icon, Resources.Load<Sprite>("sword"), curItem.ItemName, curItem.description, curItem.AdditionalPower);
        }
        else if (curItem.AdditionalDefense > 0)
        {
            PopupUI.SetPopup(curItem.icon, Resources.Load<Sprite>("belt"), curItem.ItemName, curItem.description, curItem.AdditionalDefense);
        }
        else if (curItem.AdditionalCriticalHit > 0)
        {
            PopupUI.SetPopup(curItem.icon, Resources.Load<Sprite>("clover"), curItem.ItemName, curItem.description, curItem.AdditionalCriticalHit);
        }
        PopupUI.gameObject.SetActive(true);
    }

}
