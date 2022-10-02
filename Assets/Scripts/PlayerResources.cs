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

    public float tenSecondCashBonus;

    public int cash { get; private set; }

    void Start()
    {
        tenSecondCashBonus = baseCashBonus;

        TenSecondCycle.Instance.onCycleTick.AddListener(() => {
            AddCash(Mathf.FloorToInt(tenSecondCashBonus));

            tenSecondCashBonus *= cashBonusIncreaseMultiplier;
        });
    }

    public void AddCash (int cashToAdd) {
        cash += cashToAdd;
        onCashChanged.Invoke(cash, cashToAdd);
    }

    public void RemoveCash (int cashToRemove) {
        cash -= cashToRemove;
        onCashChanged.Invoke(cash, cashToRemove);
    }

}
