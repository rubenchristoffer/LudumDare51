using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class TileSet
{
    public List<Tile> tiles = new List<Tile>();
    public Vector2 centerCoordinates;
    public const float width = 3;
    public const float height = 3;
    public TileSet[] neighbouringTilesets;



    public static TileSet CreateTileset(Vector2 centerCoordinates)
    {
        TileSet tileset = new TileSet();
        tileset.centerCoordinates =  centerCoordinates;
        int range = 1;
        int heightRange = 1;
        for (int x = -range; x < range; x++)
            for (int y = -heightRange; y < heightRange; y++)
            {
                float newX = centerCoordinates.x + x;
                float newY = centerCoordinates.y + y;
                GameObject prefab = (y== -heightRange) ? TileSpawner.Instance.bottomTilePrefab : TileSpawner.Instance.fullTilePrefab;
                Tile tile = TileSpawner.Instance.CreateTile(prefab, new Vector2(newX, newY));
                tileset.tiles.Add(tile);
            }
        return tileset;

    }
    public bool FindNeighouringTiles(List<TileSet> allTiles)
    {
        foreach (TileSet tileset in allTiles)
        {

        }
        return false;
    }
}
