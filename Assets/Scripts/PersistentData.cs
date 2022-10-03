using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PersistentData", menuName = "ScriptableObjects/PersistentData", order = 1)]
public class PersistentData : ScriptableObject
{

    public int level = 1;
    public float enemiesToSpawn = 1;

    public int cash = 20;
    public float tenSecondCashBonus = 2;
    public float playerHealth = 100;

    public void Reset () {
        level = 1;
        enemiesToSpawn = 1;
        cash = 20;
        tenSecondCashBonus = 2;
        playerHealth = 100;
    }

}
