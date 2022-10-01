using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public GameObject bottomTilePrefab;
    public GameObject fullTilePrefab;
    public const float tileSize = 1;
    public int width;
    public int height;  
    private List<TileSet> tilesets = new List<TileSet>();
    public static TileSpawner Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        TileSet.CreateTileset(new Vector2(0,0));
        TileSet.CreateTileset(new Vector2(2,0));
        TileSet.CreateTileset(new Vector2(4,0));
        TileSet.CreateTileset(new Vector2(4,2));
        TileSet.CreateTileset(new Vector2(2,-2));
    }

    public Tile CreateTile(GameObject prefab, Vector2 coordinates)
    {
        Tile tile = Instantiate<GameObject>(prefab, GetWorldPosition(coordinates), Quaternion.identity).GetComponent<Tile>();
        tile.coordinates = coordinates;
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
