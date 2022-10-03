using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Vector3Int pos = Vector3Int.RoundToInt(transform.position);
            List<Tile> tiles = new List<Tile>();

            for (int x = -1; x <= 1; x++) {
                for (int y = -1; y <= 1; y++) {
                    Tile tile = TileSet.GetTile(new Vector3(pos.x + x, pos.y + y));

                    if (tile != null) {
                        if (playerResources.cash >= 1 && tile.Interact()) {
                            playerResources.RemoveCash(1);
                        }
                    }
                }
            }
        }
    }

}
