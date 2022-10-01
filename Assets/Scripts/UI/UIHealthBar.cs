using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{

    public TMPro.TextMeshProUGUI label;
    public Image greenForeground;

    private Entity playerEntity;

    void Awake ()
    {
        playerEntity = GameObject.FindWithTag("Player").GetComponent<Entity>();
    }

    void Update()
    {
        label.text = Mathf.CeilToInt(playerEntity.health).ToString();
        greenForeground.fillAmount = playerEntity.health / playerEntity.maxHealth;
    }

}
