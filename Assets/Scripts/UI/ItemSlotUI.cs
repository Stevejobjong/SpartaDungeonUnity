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
        if (equipMark != null)
        {
            equipMark.SetActive(equipped);
        }
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
            ChangeSlot(DragSlot.instance.dragSlot);
    }

    private void ChangeSlot(ItemSlotUI dragSlot)
    {
        //Drop위치의 아이템 임시 저장
        ItemSO _tempItem = curItem;
        bool _tempEquip = equipped;

        //Drop위치에 Drag한 아이템 설정
        Set(dragSlot.curItem);        
        equipped = dragSlot.equipped;
        Inventory.instance.InsertItem(dragSlot.curItem, index);

        //Drag위치에 Drop위치 정보 설정
        dragSlot.equipped = _tempEquip;
        if (_tempItem != null)
        {
            //Drop위치에 아이템이 있었다면 Drag한 슬롯 위치에 현재 아이템 설정
            Inventory.instance.InsertItem(_tempItem, dragSlot.index);
            dragSlot.Set(_tempItem);
        }
        else
        {
            Inventory.instance.ClearItem(_tempItem, dragSlot.index);
            dragSlot.Clear();
        }
    }
}
