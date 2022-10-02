using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{

    public int cash;
    public int baseCashBonus = 1;
    public float cashBonusIncreaseMultiplier = 1.1f;

    public float tenSecondCashBonus;

    void Start()
    {
        tenSecondCashBonus = baseCashBonus;

        TenSecondCycle.Instance.onCycleTick.AddListener(() => {
            cash += Mathf.FloorToInt(tenSecondCashBonus);

            tenSecondCashBonus *= cashBonusIncreaseMultiplier;
        });
    }

}
