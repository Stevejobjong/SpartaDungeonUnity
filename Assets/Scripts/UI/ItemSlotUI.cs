using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ItemSlotUI : SlotUI, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
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
        PopupUI.Appear();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (curItem != null)
        {
            DragSlot.instance.dragSlot = this;
            DragSlot.instance.DragSetImage(curItem.icon);
            DragSlot.instance.transform.position = eventData.position;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (curItem != null)
            DragSlot.instance.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DragSlot.instance.SetAlpha(0);
        DragSlot.instance.dragSlot = null;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (DragSlot.instance.dragSlot != null)
            ChangeSlot();
    }

    private void ChangeSlot()
    {
        ItemSO _tempItem = curItem;

        Set(DragSlot.instance.dragSlot.curItem);

        if (_tempItem != null)
            DragSlot.instance.dragSlot.Set(_tempItem);
        else
            DragSlot.instance.dragSlot.Clear();
    }
}
