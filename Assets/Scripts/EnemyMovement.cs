using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public Transform target;
    public float speed = 2f;

    [Tooltip("To prevent enemy from going inside player")]
    public float stopOffset = 2f;

    public float minStopOffsetRecalculationTime = 1f;
    public float maxStopOffsetRecalculationTime = 1.5f;

    private Vector3 currentStopOffset;
    private float currentStopOffsetTimer;

    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
        GetComponent<Entity>().onDie.AddListener(() => animator.SetTrigger("Death"));
    }
    void Update()
    {
        
        AnimatorStateInfo animationState = animator.GetCurrentAnimatorStateInfo(0);
        if (animationState.IsName("Attack") && animationState.normalizedTime < 1)
        {
        }
        else if (animationState.IsName("Death") )
        {
            if (animationState.normalizedTime > 1)
            {
                Object.Destroy(gameObject);
            }
        
        }
        else
        {
            Vector3 targetDirection = (target.position - transform.position).normalized;

            if (currentStopOffsetTimer < 0f)
            {
                currentStopOffset = stopOffset * Random.onUnitSphere;
                currentStopOffsetTimer = Random.Range(minStopOffsetRecalculationTime, maxStopOffsetRecalculationTime);
            }
            else
            {
                currentStopOffsetTimer -= Time.deltaTime;
            }

            transform.position = Vector3.MoveTowards(transform.position, target.position - currentStopOffset, Time.deltaTime * speed);
        }

    }
}
