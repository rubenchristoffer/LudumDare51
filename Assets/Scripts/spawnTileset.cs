using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTileset : MonoBehaviour
{
    public GameObject bottomTilePrefab;
    public GameObject fullTilePrefab;
    public int width;
    public int height;  

    void Start()
    {
        CreateTilesetAtLocation(Vector3.zero);
    }

    void CreateTilesetAtLocation(Vector3 bottom_left_start_position)
    // Creates a tile set a given location from bottom left anchor
    {
        Vector3 original_pos = bottom_left_start_position;
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (y == 0) { 
                //if tile is on the bottom row
                Instantiate(bottomTilePrefab, original_pos + new Vector3(x, y, 0), Quaternion.identity);
                }
                else
                {
                Instantiate(fullTilePrefab, original_pos + new Vector3(x, y, 0), Quaternion.identity); 
                }
            }
        }
    }

    void UpdateTileVariationWithRespectToSurroundingTiles()
    {
        Debug.Assert(false, "Not yet implemented!");
    }

    void Update()
    {
        
    }
}
