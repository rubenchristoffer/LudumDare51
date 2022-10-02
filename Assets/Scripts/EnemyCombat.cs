using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{

    public Entity playerEntity;

    public float attackDamage = 10f;
    public float attackDistance = .5f;
    public float attackCooldownTime = 2f;

    private float cooldownTimeLeft;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    bool HitAttack()
    {
        // check where the enemy has hit and validate if it has hit the player
        return (Vector3.Distance(transform.position, playerEntity.transform.position) <= attackDistance);
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, playerEntity.transform.position) <= attackDistance)
        {
            if (cooldownTimeLeft < 0f)
            {
                cooldownTimeLeft = attackCooldownTime;
                animator.SetTrigger("Attack");
                if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
                {
                }
                else
                {
                    if (HitAttack()) playerEntity.InflictDamage(attackDamage);
                }
            }
            else
            {
                cooldownTimeLeft -= Time.deltaTime;
            }
        }
    }

}
