﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class TurretBlueprint {
    public GameObject prefab;
    public int cost;
    
    public GameObject upgradedPrefab;
    public int upgradeCost;
    

    public int getSell() {
        return cost / 2;
    }

    public int getSellUp() {
        return upgradeCost / 2;
    }
}
