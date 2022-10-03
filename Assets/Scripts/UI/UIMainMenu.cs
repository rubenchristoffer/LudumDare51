using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
 
    public PersistentData persistentData;

    void Start()
    {
        if (persistentData.level > 1) {
            gameObject.SetActive(false);   
        } else {
            Time.timeScale = 0;
        }
    }

    public void OnStartGame () {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }

    public void OnQuitGame () {
        Application.Quit();
    }

}
