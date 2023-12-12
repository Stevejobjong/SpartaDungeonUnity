using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType
{
    Weaopn,
    Armor
}
public enum StatType
{
    Power,
    Defense,
    CriticalHit
}
[CreateAssetMenu(fileName = "New Item",menuName = "Create Item SO",order = 1)]
public class ItemSO : ScriptableObject
{
    [Header("Info")]
    public ItemType ItemType;
    public string ItemName;
    public string description;
    public float AdditionalPower;
    public float AdditionalDefense;
    public float AdditionalCriticalHit;
    public int Price;
    public Sprite icon;
}
