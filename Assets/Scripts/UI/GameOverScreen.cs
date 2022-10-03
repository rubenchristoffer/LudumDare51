using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    public PersistentData persistentData;
    public TMPro.TextMeshProUGUI levelText;

    void Start()
    {
        GameObject.FindWithTag("Player").GetComponent<Entity>().onDie.AddListener(() => {
            levelText.text = $"- Level {persistentData.level} -";
            gameObject.SetActive(true);
            persistentData.Reset();
        });

        gameObject.SetActive(false);
    }

    void Update () {
        Time.timeScale = Mathf.MoveTowards(Time.timeScale, 0f, Time.deltaTime * 1f);
    }

    public void GoBackToMainMenu () {
        SceneManager.LoadScene("SceneLoader", LoadSceneMode.Single);
    }

}
