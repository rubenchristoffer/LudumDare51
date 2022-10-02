using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerAttack : MonoBehaviour
{

    public float attackRange = 2f;
    public float attackDamage = 50f;
    public float attackCooldown = 1f;

    public Animator animator;

    private Entity playerEntity;
    private float attackCooldownTimeLeft;

    void Awake ()
    {
        playerEntity = GetComponent<Entity>();
    }

    void Update()
    {
        if (attackCooldownTimeLeft < 0f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                attackCooldownTimeLeft = attackCooldown;
                Attack();
            }
        }
        else
        {
            attackCooldownTimeLeft -= Time.deltaTime;
        }
    }

    void Attack ()
    {
        animator?.SetTrigger("Attack");

        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, 1f, playerEntity.GetLookDirectionVector(), attackRange);

        var entities = hits
            .Select(hit => hit.transform.GetComponentInParent<Entity>())
            .Where(entity => entity != null)
            .Distinct();

        foreach (Entity entity in entities)
        {
            entity.InflictDamage(attackDamage);
        }
    }

}
