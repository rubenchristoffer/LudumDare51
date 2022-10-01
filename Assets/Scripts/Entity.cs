using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Entity : MonoBehaviour {

    [Min(0f)]
    public float health = 100f;

    [Min(0f)]
    public float maxHealth = 100f;

    public bool isDead { get; private set; }

    public readonly UnityEvent<float> onInflictedDamage = new UnityEvent<float>();
    public readonly UnityEvent onDie = new UnityEvent();

    public void InflictDamage(float damage)
    {
        if (isDead)
        {
            throw new System.InvalidCastException("Cannot inflict damage on dead entity!");
        }

        health -= damage;

        onInflictedDamage.Invoke(damage);

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die() {
        if (isDead)
        {
            throw new System.InvalidOperationException("Entity is already dead!");
        }

        health = 0;
        isDead = true;
        onDie.Invoke();
    }

}

