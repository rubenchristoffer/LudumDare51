using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageIndicator : MonoBehaviour
{
    public Text text;
    public float lifetime = 4f;
    public float minDist = 2f;
    public float maxDist = 3f;

    private Vector3 iniPos;
    private Vector3 targetPos;
    private float timer;
    
    void Start()
    {
    }

    void Update()
    {    
        lifetime -= Time.deltaTime;  
        if (lifetime < 0)
        {
            Destroy(gameObject);
        }
        float inverseLifetime = 1 / lifetime;
        transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime, 0);
        
    }

    public void SetDamageText(float damage)
    {
        text.text = damage.ToString();
    }
}
