using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public Transform target;
    public float speed = 2f;

    [Tooltip("To prevent enemy from going inside player")]
    public float stopOffset = 1f;

    void Update ()
    {
        Vector3 targetDirection = (target.position - transform.position).normalized;

        transform.position = Vector3.MoveTowards(transform.position, target.position - targetDirection * stopOffset, Time.deltaTime * speed);
    }

}
