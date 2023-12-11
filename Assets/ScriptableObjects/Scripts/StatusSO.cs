using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Status", menuName = "Create Status SO", order = 0)]
public class StatusSO : ScriptableObject
{
    [Header("Status")]
    public float Power;
    public float Defense;
    public float CriticalHit;
}
