using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class Tile: MonoBehaviour
{
    public Vector2 coordinates;
    public Direction? direction;

    public enum TileVariation
    {
        spooky,
        full,
        bottom,
        escape
    }

    public TileVariation tileVariation;
    public bool isInteractable = false;

    float randomCoefficient;
    Vector3 positionV;

    private void Start()
    {
        transform.position += new Vector3(0, -20, 0);
        randomCoefficient = UnityEngine.Random.Range(.04f, 0.055f);

    }
    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(coordinates.x, coordinates.y, 0), ref positionV, randomCoefficient);
        
    }



    public void Interact()
    {
        if (!isInteractable) return;
        isInteractable = false;
        
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
            return;
        }
        TileSet.CreateTileset(location);
    }
}
