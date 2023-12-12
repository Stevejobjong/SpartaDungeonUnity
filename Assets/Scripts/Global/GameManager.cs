using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("Canvas")]
    public GameObject StatusUI;
    public GameObject InventoryUI;
    public GameObject ShopUI;

    [Header("Button")]
    public GameObject StatusButton;
    public GameObject InventoryButton;
    public GameObject ShopButton;

    [Header("Player Information")]
    public Transform Player;
    private PlayerStatusHandler playerstat;
    [SerializeField] TMP_Text attackValueText;
    [SerializeField] TMP_Text defenseValueText;
    [SerializeField] TMP_Text healthValueText;
    [SerializeField] TMP_Text criticalValueText;
    private void Awake()
    {
        instance = this;
        playerstat = Player.GetComponent<PlayerStatusHandler>();
    }
    void Start()
    {
        GetPlayerStat();
    }

    public void OnClickedStatusButton()
    {
        GetPlayerStat();
        StatusButton.SetActive(false);
        InventoryButton.SetActive(false);
        ShopButton.SetActive(false);
        StatusUI.SetActive(true);
    }
    public void OnClickedStatusCloseButton()
    {
        StatusUI.SetActive(false);
        StatusButton.SetActive(true);
        InventoryButton.SetActive(true);
        ShopButton.SetActive(true);
    }
    public void OnClickedInventoryButton()
    {
        StatusButton.SetActive(false);
        InventoryButton.SetActive(false);
        ShopButton.SetActive(false);
        Inventory.instance.UpdateUI();
        InventoryUI.SetActive(true);
    }
    public void OnClickedInventoryCloseButton()
    {
        InventoryUI.SetActive(false);
        StatusButton.SetActive(true);
        InventoryButton.SetActive(true);
        ShopButton.SetActive(true);
    }
    public void OnClickedShopButton()
    {
        ShopUI.SetActive(true);
    }
    public void OnClickedShopCloseButton()
    {
        ShopUI.SetActive(false);
    }
    //플레이어의 공격력, 방어력, HP, 치명타 정보를 얻어와 Status창의 Text 갱신
    public void GetPlayerStat()
    {
        attackValueText.text = playerstat.getPower().ToString();
        defenseValueText.text = playerstat.getDefense().ToString();
        healthValueText.text = playerstat.getHealth().ToString();
        criticalValueText.text = playerstat.getCritical().ToString();
    }
    public void AddPlayerStat(ItemSO itemSo, int sign)
    {
        float value;
        if (itemSo.StatType == StatType.Power)
            value = itemSo.AdditionalPower;
        else if (itemSo.StatType == StatType.Defense)
            value = itemSo.AdditionalDefense;
        else
            value = itemSo.AdditionalCriticalHit;
        playerstat.AddStat(itemSo.StatType, value * sign);
    }
}
