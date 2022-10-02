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

    public float speed;
    public Vector3 startPosition;
    public float randomCoefficient;

    private void Start()
    {
        speed = 45f;
        transform.position += new Vector3(0, 20, 0);
    }
    private void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(coordinates.x, coordinates.y, 0), step);
    }


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
            return;
        }
        TileSet.CreateTileset(location);
    }
}
