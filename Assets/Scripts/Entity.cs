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
    public GameObject damageText;

    public readonly UnityEvent<float> onInflictedDamage = new UnityEvent<float>();
    public readonly UnityEvent onDie = new UnityEvent();

    public Direction lookDirection { get; set; }

    public void InflictDamage(float damage)
    {
        DamageIndicator indicator = Instantiate(damageText, transform.position, Quaternion.identity).GetComponent<DamageIndicator>();
        indicator.SetDamageText(damage);
        onInflictedDamage.Invoke(damage);

        if (isDead)
        {
            throw new System.InvalidCastException("Cannot inflict damage on dead entity!");
        }

        health -= damage;
       
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

