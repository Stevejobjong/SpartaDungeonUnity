using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusHandler : MonoBehaviour
{
    [SerializeField] PlayerStatus baseStatus;

    public float getHealth()
    {
        return baseStatus.Health;
    }
    public float getPower()
    {
        return baseStatus.statusSO.Power;
    }
    public float getDefense()
    {
        return baseStatus.statusSO.Defense;
    }
    public float getCritical()
    {
        return baseStatus.statusSO.CriticalHit;
    }
    public void AddStat(StatType type, float value)
    {
        switch (type)
        {
            case StatType.Power:
                baseStatus.statusSO.Power += value;
                break;
            case StatType.Defense:
                baseStatus.statusSO.Defense += value;
                break;
            case StatType.CriticalHit:
                baseStatus.statusSO.CriticalHit += value;
                break; ;
        }
    }
}
