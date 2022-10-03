using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public GameObject bottomTilePrefab;
    [SerializeField]
    public WeightedPrefab[] fullTilePrefab;

    public GameObject[] escapeTilePrefabs;
    public GameObject escapePortalPrefab;

    [System.Serializable]
    public struct WeightedPrefab
    {
        public GameObject prefab;
        public int weight;
    }
    List<GameObject> fullTileWeightedPrefabs = new List<GameObject>();
    public GameObject spookyTilePrefab;
    public Transform MapParent;
    public const float tileSize = 1;
    public int width;
    public int height;  
    public List<Tile> tiles = new List<Tile> (); 
    public static TileSpawner Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        foreach (WeightedPrefab pref in fullTilePrefab)
        {
            for (int i = 0; i < pref.weight ; i++)
            {
                fullTileWeightedPrefabs.Add(pref.prefab);
            }
        }
    }
    void Start()
    {
        // Calculate escape tile coordinates
        float distanceFromSpawn = Random.Range(8f, 10f) * 3f;
        Vector2 direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

        TileSet.escapeTileCenterCoordinates = direction * distanceFromSpawn;
        TileSet.escapeTileCenterCoordinates = new Vector2(Mathf.Floor(TileSet.escapeTileCenterCoordinates.x), Mathf.Floor(TileSet.escapeTileCenterCoordinates.y)) * 3;

        TileSet.CreateTileset(new Vector2(0,0));
    }

    public Tile CreateTile(Tile.TileVariation variation, Vector2 coordinates)
    {
        GameObject prefab;
        switch (variation){
            case Tile.TileVariation.spooky: 
                prefab = spookyTilePrefab;
                break;

            case Tile.TileVariation.bottom:
                prefab = bottomTilePrefab;
                break;

            default:
                int index = Random.Range(0, fullTileWeightedPrefabs.Count);
                prefab = fullTileWeightedPrefabs[index];
                break;

        }
        
        return InstantiateTile(prefab, coordinates, variation);
    }

    private Tile InstantiateTile (GameObject prefab, Vector2 coordinates, Tile.TileVariation variation)
    {
        Tile tile = Instantiate<GameObject>(prefab, GetWorldPosition(coordinates), Quaternion.identity).GetComponent<Tile>();
        tile.transform.SetParent(MapParent);
        tile.tileVariation = variation;
        tile.coordinates = coordinates;
        tiles.Add(tile);
        return tile;
    }

    public Tile CreateEscapeTile (Vector2 coordinates, int prefabNumber)
    {
        return InstantiateTile(escapeTilePrefabs[prefabNumber], coordinates, Tile.TileVariation.escape);
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
