using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{

    public Entity playerEntity;

    public float attackDamage = 10f;
    public float attackDistance = 2f;
    public float attackCooldownTime = 1f;

    private float cooldownTimeLeft;

    void Update()
    {
        if (Vector3.Distance(transform.position, playerEntity.transform.position) <= attackDistance)
        {
            if (cooldownTimeLeft < 0f)
            {
                playerEntity.InflictDamage(attackDamage);
                cooldownTimeLeft = attackCooldownTime;
            }
            else
            {
                cooldownTimeLeft -= Time.deltaTime;
            }
        }
    }
}
