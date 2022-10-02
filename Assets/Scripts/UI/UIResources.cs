using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIResources : MonoBehaviour
{

    public TMPro.TextMeshProUGUI cashLabel;
    public TMPro.TextMeshProUGUI cashInfluxLabel;

    private PlayerResources playerResources;

    private float currentCashInfluxLabelAlpha;
    private float targetCashInfluxLabelAlpha;

    private float cashInfluxVisibilityTimeLeft;

    void Awake ()
    {
        playerResources = GameObject.FindWithTag("Player").GetComponent<PlayerResources>();

        playerResources.onCashChanged.AddListener((newCash, changeInCash) => {
            bool positive = changeInCash > 0;
            string symbol = positive ? "+" : "-";
            Color color = positive ? Color.green : Color.red;
            color.a = cashInfluxLabel.color.a;

            cashInfluxVisibilityTimeLeft = 0.5f;

            cashInfluxLabel.text = $"${symbol}{changeInCash}";
            cashInfluxLabel.color = color;
        });
    }

    void Update()
    {
        cashLabel.text = $"${playerResources.cash}";

        if (cashInfluxVisibilityTimeLeft < 0f) {
            targetCashInfluxLabelAlpha = 0f;
        } else {
            targetCashInfluxLabelAlpha = 1f;
            cashInfluxVisibilityTimeLeft -= Time.deltaTime;
        }

        currentCashInfluxLabelAlpha = Mathf.MoveTowards(currentCashInfluxLabelAlpha, targetCashInfluxLabelAlpha, 4f * Time.deltaTime);

        Color cashInfluxColor = cashInfluxLabel.color;
        cashInfluxColor.a = currentCashInfluxLabelAlpha;
        cashInfluxLabel.color = cashInfluxColor;
    }

}
