using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{

    public Entity playerEntity;

    public float attackDamage = 10f;
    public float attackDistance = 0.5f;
    public float attackCooldownTime = 2f;
    public float attackDelay = 0.5f;

    private float cooldownTimeLeft;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    bool IsWithinAttackDistance()
    {
        // check where the enemy has hit and validate if it has hit the player
        return (Vector3.Distance(transform.position, playerEntity.transform.position) <= attackDistance);
    }

    IEnumerator Attack () {
        yield return new WaitForSeconds(attackDelay);

        if (IsWithinAttackDistance()) {
            playerEntity.InflictDamage(Mathf.FloorToInt(attackDamage));
        }
    }

    void Update()
    {
        if (cooldownTimeLeft > 0f) {
            cooldownTimeLeft -= Time.deltaTime;
        } else {
            if (IsWithinAttackDistance()) {
                cooldownTimeLeft = attackCooldownTime;
                animator.SetTrigger("Attack");
                StartCoroutine(Attack());
            }
        }
    }

}
