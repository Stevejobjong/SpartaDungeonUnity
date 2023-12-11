using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int gold;
    public static Inventory instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
    }

    void Update()
    {
        
    }
}
