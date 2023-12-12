using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusHandler : MonoBehaviour
{
    [SerializeField] PlayerStatus baseStatus;
    private StatusSO playerStatusSO;
    private void Awake()
    {
        //기본 데이터를 건들지 않고 clone생성
        playerStatusSO = Instantiate(baseStatus.statusSO);
    }
    public float getHealth()
    {
        return baseStatus.Health;
    }
    public float getPower()
    {
        return playerStatusSO.Power;
    }
    public float getDefense()
    {
        return playerStatusSO.Defense;
    }
    public float getCritical()
    {
        return playerStatusSO.CriticalHit;
    }
    public void AddStat(StatType type, float value)
    {
        switch (type)
        {
            case StatType.Power:
                playerStatusSO.Power += value;
                break;
            case StatType.Defense:
                playerStatusSO.Defense += value;
                break;
            case StatType.CriticalHit:
                playerStatusSO.CriticalHit += value;
                break; ;
        }
    }
}
