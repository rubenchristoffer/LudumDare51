using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Animator animator;
    public Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Entity playerEntity;

    void Start()
    {
        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();     
        playerEntity = GetComponent<Entity>();
    }

    void Update()
    {
        HandleInputs();
    }

    void HandleInputs()
    {

        Vector3 velocity = Vector3.zero;
        Vector3 startPos = transform.position;
        velocity += transform.right * Input.GetAxis("Horizontal") * speed;
        velocity += transform.up * Input.GetAxis("Vertical") * speed;

        rb.velocity = velocity;
        if (velocity.x < 0) spriteRenderer.flipX = true;
        else spriteRenderer.flipX = false;
        animator.SetBool("isWalking", velocity.magnitude > 0);


    }
}
