using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapePortal : MonoBehaviour
{

    public PersistentData persistentData;

    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < 1f) {
            persistentData.level++;
            persistentData.playerHealth *= 1.1f;
            persistentData.cash += 50;
            SceneManager.LoadScene("SceneLoader", LoadSceneMode.Single);
        }
    }
    
}
