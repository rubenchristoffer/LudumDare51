using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public const float zValue = -10f;

    public float smoothing = 0.1f;

    private Transform player;

    private Vector3 positionV;

    void Awake ()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        // Move towards player
        transform.position = Vector3.SmoothDamp(transform.position, player.position, ref positionV, smoothing);

        // Make sure z value is always the same
        transform.position = new Vector3(transform.position.x, transform.position.y, zValue);
    }

}
