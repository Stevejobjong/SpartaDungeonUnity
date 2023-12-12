using DG.Tweening;
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
    private void Awake()
    {
        DOTween.Init();
        transform.localScale = Vector3.one * 0.1f;
    }
    public void Appear()
    {
        gameObject.SetActive(true);
        Sequence seq = DOTween.Sequence();

        seq.Append(transform.DOScale(1.1f, 0.2f));
        seq.Append(transform.DOScale(1f, 0.1f));

        seq.Play();
    }
    public void Hide()
    {
        var seq = DOTween.Sequence();

        transform.localScale = Vector3.one * 0.2f;

        seq.Append(transform.DOScale(1.1f, 0.1f));
        seq.Append(transform.DOScale(0.1f, 0.2f));

        //시퀀스의 플레이가 완료되면 Oncomplete에 인자로 전달되는 함수 실행 (여기서는 람다식)
        seq.Play().OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }
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
