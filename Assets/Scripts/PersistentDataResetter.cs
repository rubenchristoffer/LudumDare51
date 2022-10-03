using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentDataResetter : MonoBehaviour
{

    public PersistentData persistentData;

    private static PersistentDataResetter Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
        persistentData.Reset();
    }

}
