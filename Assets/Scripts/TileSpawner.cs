using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public GameObject bottomTilePrefab;
    [SerializeField]
    public WeightedPrefab[] fullTilePrefab;
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
        Tile tile = Instantiate<GameObject>(prefab, GetWorldPosition(coordinates), Quaternion.identity).GetComponent<Tile>();
        tile.transform.SetParent(MapParent);
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
