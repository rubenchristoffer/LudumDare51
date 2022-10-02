using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Vector3Int pos = Vector3Int.RoundToInt(transform.position);
            Tile tile = TileSet.GetTile((Vector3)pos);
            if (tile != null) tile.Interact();
        }
    }
}
