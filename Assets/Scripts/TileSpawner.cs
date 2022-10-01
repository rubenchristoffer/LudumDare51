using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public GameObject bottomTilePrefab;
    public GameObject fullTilePrefab;
    public GameObject spookyTilePrefab;
    public const float tileSize = 1;
    public int width;
    public int height;  
    public List<Tile> tiles = new List<Tile> (); 
    public static TileSpawner Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        TileSet.CreateTileset(new Vector2(0,0));
    }

    public Tile CreateTile(GameObject prefab, Vector2 coordinates)
    {
        Tile tile = Instantiate<GameObject>(prefab, GetWorldPosition(coordinates), Quaternion.identity).GetComponent<Tile>();
        tile.coordinates = coordinates;
        tiles.Add(tile);
        return tile;
    }

    public static Vector3 GetWorldPosition(Vector2 coordinates)
    {
        return coordinates * tileSize;
    }

    void UpdateTileVariationWithRespectToSurroundingTiles()
    {
        Debug.Assert(false, "Not yet implemented!");
    }

    void Update()
    {
        
    }
}
