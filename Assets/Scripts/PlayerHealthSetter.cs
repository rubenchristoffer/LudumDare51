using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSetter : MonoBehaviour
{
    
    public PersistentData persistentData;

    void Awake () {
        if (persistentData.playerHealth < 100f) {
            persistentData.playerHealth = 100f;
        }

        Entity entity = GetComponent<Entity>();
        entity.maxHealth = Mathf.FloorToInt(persistentData.playerHealth);
        entity.health = Mathf.FloorToInt(persistentData.playerHealth);
    }

}
