using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerResources : MonoBehaviour
{

    // <new cash value, change in cash>
    public readonly UnityEvent<int, int> onCashChanged = new UnityEvent<int, int>();

    public int baseCashBonus = 1;
    public float cashBonusIncreaseMultiplier = 1.1f;
    public PersistentData persistentData;

    public int cash {
        get => persistentData.cash;
        set => persistentData.cash = value;
    }

    void Start()
    {
        if (persistentData.tenSecondCashBonus < 1) {
            persistentData.tenSecondCashBonus = 1f;
        }

        TenSecondCycle.Instance.onCycleTick.AddListener(() => {
            AddCash(Mathf.FloorToInt(persistentData.tenSecondCashBonus));

            persistentData.tenSecondCashBonus *= cashBonusIncreaseMultiplier;
        });
    }

    public void AddCash (int cashToAdd) {
        cash += cashToAdd;
        onCashChanged.Invoke(cash, cashToAdd);
    }

    public void RemoveCash (int cashToRemove) {
        cash -= cashToRemove;
        onCashChanged.Invoke(cash, -cashToRemove);
    }

}
