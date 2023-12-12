using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipPopup : MonoBehaviour
{
    public Image EquipItemIcon;
    public Image EquipStatIcon;
    public TMP_Text EquipStatValue;
    public TMP_Text EquipItemName;
    public TMP_Text EquipItemDescription;
    public void OnClickedEquipPopupYesButton()
    {
        gameObject.SetActive(false);
        Inventory.instance.EquipToggle();
    }
    public void OnClickedEquipPopupNoButton()
    {
        Inventory.instance.EquipPopup.gameObject.SetActive(false);
    }

    public void SetPopup(Sprite _equipIcon, Sprite _statIcon, string _itemName, string desc, float statValue)
    {
        EquipItemIcon.sprite = _equipIcon;
        EquipStatIcon.sprite = _statIcon;
        EquipItemName.text = _itemName;
        EquipItemDescription.text = desc;
        EquipStatValue.text = statValue.ToString();
    }
}
