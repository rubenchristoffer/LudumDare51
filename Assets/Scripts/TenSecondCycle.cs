using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TenSecondCycle : MonoBehaviour
{

    public const float cycle = 10f;

    public static TenSecondCycle Instance { get; private set; }

    public readonly UnityEvent onCycleTick = new UnityEvent();

    private float timeLeft;

    void Awake ()
    {
        Instance = this;
        timeLeft = cycle;
    }

    void Update ()
    {
        if (timeLeft < 0f)
        {
            timeLeft = cycle;
            onCycleTick.Invoke();
        } 
        else
        {
            timeLeft -= Time.deltaTime;
        }
    }

}
