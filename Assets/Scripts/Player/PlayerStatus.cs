using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerStatus
{
    public StatusSO statusSO;
    [Range(1, 100)] public float Health;
}
