using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    PlayerResources playerResources;

    // Start is called before the first frame update
    void Start()
    {
        playerResources = GetComponent<PlayerResources>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && playerResources.cash >= 1)
        {
            Vector3Int pos = Vector3Int.RoundToInt(transform.position);
            Tile tile = TileSet.GetTile((Vector3)pos);

            if (tile != null){ 
                if (tile.Interact()) {
                    playerResources.RemoveCash(1);    
                }
            }
        }
    }

}
