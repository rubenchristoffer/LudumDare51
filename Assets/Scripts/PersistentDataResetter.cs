using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentDataResetter : MonoBehaviour
{

    public PersistentData persistentData;

    private static PersistentDataResetter Instance;

    // Start is called before the first frame update
    void Start()
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
