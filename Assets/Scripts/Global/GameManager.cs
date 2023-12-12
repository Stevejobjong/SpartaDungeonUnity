using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
    [SerializeField] TMP_Text gold;
    private void Awake()
    {
        playerstat=Player.GetComponent<PlayerStatusHandler>();
    }
    void Start()
    {
        GetGold();
        GetPlayerStat();
    }

    void Update()
    {

    }

    public void OnClickedStatusButton()
    {
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
    //�÷��̾��� ���ݷ�, ����, HP, ġ��Ÿ ������ ���� Statusâ�� Text ����
    public void GetPlayerStat()
    {
        attackValueText.text = playerstat.getPower().ToString();
        defenseValueText.text = playerstat.getDefense().ToString();
        healthValueText.text = playerstat.getHealth().ToString();
        criticalValueText.text = playerstat.getCritical().ToString();
    }
    public void GetGold()
    {
        gold.text = string.Format("{0:#,###}", Inventory.instance.gold);
    }
}
