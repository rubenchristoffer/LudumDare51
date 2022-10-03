using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillLoot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerResources playerResources = GameObject.FindWithTag("Player").GetComponent<PlayerResources>();

        GetComponent<Entity>().onDie.AddListener(() => {
            playerResources.AddCash(5);
        });
    }


}
