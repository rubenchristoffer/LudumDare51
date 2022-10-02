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


    
    public static Tile GetTile(Vector2 coordinates)
    {
        foreach (Tile tile in TileSpawner.Instance.tiles)
        {
            if ((coordinates -  tile.coordinates).sqrMagnitude < 0.1f) return tile;
        }
        return null;
    }
    public static bool DoesTileExist(Vector2 coordinates)
    {
        bool found = GetTile(coordinates) != null;
        
        return found;
    }

    public static void CreateSpookyBarrier(Vector2 centerCoordinates, int range, int heightRange)
    {
        Vector2 evalutingCoordinates;
        Tile.TileVariation prefab = Tile.TileVariation.spooky;
        for (int x = -range-1; x <= range+1; x++)
        {
            evalutingCoordinates = new Vector2(centerCoordinates.x + x, centerCoordinates.y - heightRange - 1);
            if (GetTile(evalutingCoordinates) == null) TileSpawner.Instance.CreateTile(prefab, evalutingCoordinates);
            evalutingCoordinates = new Vector2(centerCoordinates.x + x, centerCoordinates.y + heightRange + 1);
            if (GetTile(evalutingCoordinates) == null) TileSpawner.Instance.CreateTile(prefab, evalutingCoordinates);
        }
        for (int y = -heightRange-1; y <= heightRange+1; y++)
        {
            evalutingCoordinates = new Vector2(centerCoordinates.x - range - 1, centerCoordinates.y + y);
            if (GetTile(evalutingCoordinates) == null) TileSpawner.Instance.CreateTile(prefab, evalutingCoordinates);
            evalutingCoordinates = new Vector2(centerCoordinates.x + range + 1, centerCoordinates.y + y);
            if (GetTile(evalutingCoordinates) == null) TileSpawner.Instance.CreateTile(prefab, evalutingCoordinates);
        }

    }
    public static TileSet CreateTileset(Vector2 centerCoordinates)
    {
        TileSet tileset = new TileSet();
        Tile.TileVariation prefab;
        tileset.centerCoordinates = centerCoordinates;
        int range = 1;
        int heightRange = 1;
        for (int x = -range; x <= range; x++)
            for (int y = -heightRange; y <= heightRange; y++)
            {
                Tile tile;
                float newX = centerCoordinates.x + x;
                float newY = centerCoordinates.y + y;
                tile = GetTile(new Vector2(newX, newY));
                if (tile != null)
                {
                    TileSpawner.Instance.tiles.Remove(tile);
                    UnityEngine.Object.Destroy(tile.gameObject);
                }
                Tile tileBelow = GetTile(new Vector2(newX, newY - 1));
                prefab = (tileBelow == null) ? Tile.TileVariation.bottom : Tile.TileVariation.full;
                tile = TileSpawner.Instance.CreateTile(prefab, new Vector2(newX, newY));
                if (x == 0 && y == 1)
                {
                    tile.direction = Direction.Top;
                    tile.isInteractable = true;
                }
                if (x == 0 && y == -1)
                {
                    tile.direction = Direction.Bottom;
                    tile.isInteractable = true;
                }
                if (x == 1 && y == 0)
                {
                    tile.direction = Direction.Right;
                    tile.isInteractable = true;
                }
                if (x == -1 && y == 0)
                { 
                    tile.direction = Direction.Left;
                    tile.isInteractable = true;
                }
                tileset.tiles.Add(tile);
            } 
        CreateSpookyBarrier(centerCoordinates, range, heightRange);


        return tileset;

    }

}
