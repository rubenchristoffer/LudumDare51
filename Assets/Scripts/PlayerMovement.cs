using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }

    void Update()
    {
        HandleInputs();
    }

    void HandleInputs()
    {
        this.transform.position += transform.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        this.transform.position += transform.up * Input.GetAxis("Vertical") * Time.deltaTime * speed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Vector3Int pos = Vector3Int.RoundToInt(transform.position);
            Tile tile = TileSet.GetTile((Vector3)pos);
            if (tile != null) tile.Interact();
        }

    }
}
