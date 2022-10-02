using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{

    public Entity playerEntity;

    public float attackDamage = 10f;
    public float attackDistance = .045f;
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
                AnimatorStateInfo animationState = animator.GetCurrentAnimatorStateInfo(0);
                if (animationState.normalizedTime < 1 && animationState.IsName("Attack"))
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
