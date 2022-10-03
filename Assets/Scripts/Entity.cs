using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Entity : MonoBehaviour {

    [Min(0f)]
    public int health = 100;

    [Min(0f)]
    public int maxHealth = 100;

    public bool isDead { get; private set; }
    public GameObject damageText;

    public readonly UnityEvent<float> onInflictedDamage = new UnityEvent<float>();
    public readonly UnityEvent onDie = new UnityEvent();

    public Direction lookDirection { get; set; }

    public void InflictDamage(int damage)
    {
        DamageIndicator indicator = Instantiate(damageText, transform.position, Quaternion.identity).GetComponent<DamageIndicator>();
        indicator.SetDamageText(damage);
        onInflictedDamage.Invoke(damage);

        if (isDead)
        {
            return;
        }

        health -= damage;
       
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if (isDead)
        {
            return;
        }

        health = 0;
        isDead = true;
        onDie.Invoke();
    }

    public Vector3 GetLookDirectionVector () {
        switch (lookDirection) {
            case Direction.Top: return transform.up;
            case Direction.Bottom: return -transform.up;
            case Direction.Right: return transform.right;
            case Direction.Left: return -transform.right;
        }

        return Vector3.zero;
    }

}

