using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class Tile: MonoBehaviour
{
    public Vector2 coordinates;
    public GameObject prefab;
    public Direction? direction;


    public bool isSpooky = false;
    public bool isInteractable = false;


    public void Interact()
    {
        if (!isInteractable) return;
        isInteractable = false;
        Debug.Log("succesfully attempted interaction");
        int range = 2;
        var location = direction switch
        {
            Direction.Left => coordinates - new Vector2(range, 0),
            Direction.Right => coordinates + new Vector2(range, 0),
            Direction.Bottom => coordinates - new Vector2(0, range),
            _ => coordinates + new Vector2(0, range),
        };
        if (TileSet.DoesTileExist(location))
        {
            Debug.Log("Tile exists"); 
            return;
        }
        TileSet.CreateTileset(location);
    }
}
