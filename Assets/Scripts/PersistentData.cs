using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PersistentData", menuName = "ScriptableObjects/PersistentData", order = 1)]
public class PersistentData : ScriptableObject
{

    public int level = 1;
    public float enemiesToSpawn = 1;

    public int cash = 20;
    public float tenSecondCashBonus = 1;
    public float playerHealth = 100;

    public void Reset () {
        level = 1;
        enemiesToSpawn = 1;
        cash = 20;
        tenSecondCashBonus = 1;
        playerHealth = 100;
    }

}
