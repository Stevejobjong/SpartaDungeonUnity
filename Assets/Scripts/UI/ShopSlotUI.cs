using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlotUI : SlotUI
{
    [SerializeField] TMP_Text itemName;
    [SerializeField] TMP_Text itemDescription;
    [SerializeField] Image statIcon;
    [SerializeField] TMP_Text stat;
    [SerializeField] TMP_Text price;
    public void SetItem(ItemSO item)
    {
        curItem = item;
    }
    public void SetShopItemInfo()
    {
        image.sprite = curItem.icon;
        itemName.text = curItem.name;
        itemDescription.text = curItem.description;
        if (curItem.AdditionalPower > 0)
        {
            statIcon.sprite = Resources.Load<Sprite>("sword");
            stat.text = curItem.AdditionalPower.ToString();
        }
        else if (curItem.AdditionalDefense > 0)
        {
            statIcon.sprite = Resources.Load<Sprite>("belt");
            stat.text = curItem.AdditionalDefense.ToString();
        }
        else if (curItem.AdditionalCriticalHit > 0)
        {
            statIcon.sprite = Resources.Load<Sprite>("clover");
            stat.text = curItem.AdditionalCriticalHit.ToString();
        }
        price.text = string.Format("{0:#,###}", curItem.Price);
    }
    public void OnClickBuyButton()
    {
        if(curItem.Price> inven.gold)
        {
            Shop.instance.PurchaseResult(false);
            return;
        }
        else
        {
            if(!inven.AddItem(curItem))
            {
                Shop.instance.PurchaseResult(false);
                return;
            }
            inven.gold -= curItem.Price;
            GameManager.instance.GetGold();
            Shop.instance.PurchaseResult(true);
        }
    }
}
