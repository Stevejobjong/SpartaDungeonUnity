using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject StatusUI;
    public GameObject InventoryUI;
    public GameObject StatusButton;
    public GameObject InventoryButton;
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
        attackValueText.text = playerstat.getPower().ToString();
        defenseValueText.text = playerstat.getDefense().ToString();
        healthValueText.text = playerstat.getHealth().ToString();
        criticalValueText.text = playerstat.getCritical().ToString();
    }
    void Start()
    {
        gold.text = string.Format("{0:#,###}", Inventory.instance.gold);

    }

    void Update()
    {

    }

    public void OnClickedStatusButton()
    {
        StatusButton.SetActive(false);
        InventoryButton.SetActive(false);
        StatusUI.SetActive(true);
    }
    public void OnClickedStatusCloseButton()
    {
        StatusUI.SetActive(false);
        StatusButton.SetActive(true);
        InventoryButton.SetActive(true);
    }
    public void OnClickedInventoryButton()
    {
        StatusButton.SetActive(false);
        InventoryButton.SetActive(false);
        InventoryUI.SetActive(true);
    }
    public void OnClickedInventoryCloseButton()
    {
        InventoryUI.SetActive(false);
        StatusButton.SetActive(true);
        InventoryButton.SetActive(true);
    }
}
