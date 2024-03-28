// singleton gameobject component that swaps tiles between their corrupt and purified states

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilePurificationManager : MonoBehaviour
{
    public static TilePurificationManager instance;

    public List<Tilemap> tilemaps;

    public List<TilePair> tilePairs = new List<TilePair>();

    private void Awake()
    {
        instance = this;
    }

    public void PurifyTile(Vector3Int position)
    {
        foreach (Tilemap tilemap in tilemaps)
        {
            TileBase tile = tilemap.GetTile(position);

            if (tile == null)
                continue;

            foreach (TilePair pair in tilePairs)
            {
                if (tile == pair.corruptTile)
                {
                    tilemap.SetTile(position, pair.purifiedTile);
                }
            }
        }
    }

    public void CorruptTile(Vector3Int position)
    {
        foreach (Tilemap tilemap in tilemaps)
        {
            TileBase tile = tilemap.GetTile(position);

            if (tile == null)
                continue;

            foreach (TilePair pair in tilePairs)
            {
                if (tile == pair.purifiedTile)
                {
                    tilemap.SetTile(position, pair.corruptTile);
                }
            }
        }
    }

    public void PurifyAllTiles()
    {
        foreach (Tilemap tilemap in tilemaps)
        {
            BoundsInt bounds = tilemap.cellBounds;

            foreach (Vector3Int position in bounds.allPositionsWithin)
            {
                PurifyTile(position);
            }
        }
    }

    public void CorruptAllTiles()
    {
        foreach (Tilemap tilemap in tilemaps)
        {
            BoundsInt bounds = tilemap.cellBounds;

            foreach (Vector3Int position in bounds.allPositionsWithin)
            {
                CorruptTile(position);
            }
        }
    }

    public void PurifyTilesInRadius(Vector3Int center, int radius)
    {
        foreach (Tilemap tilemap in tilemaps)
        {
            BoundsInt bounds = new BoundsInt(center - new Vector3Int(radius, radius, 0), new Vector3Int(radius * 2, radius * 2, 1));

            foreach (Vector3Int position in bounds.allPositionsWithin)
            {
                if (Vector3Int.Distance(center, position) <= radius)
                {
                    PurifyTile(position);
                }
            }
        }
    }

    public void CorruptTilesInRadius(Vector3Int center, int radius)
    {
        foreach (Tilemap tilemap in tilemaps)
        {
            BoundsInt bounds = new BoundsInt(center - new Vector3Int(radius, radius, 0), new Vector3Int(radius * 2, radius * 2, 1));

            foreach (Vector3Int position in bounds.allPositionsWithin)
            {
                if (Vector3Int.Distance(center, position) <= radius)
                {
                    CorruptTile(position);
                }
            }
        }
    }
}

[Serializable]
public class TilePair
{
    public TileBase corruptTile;
    public TileBase purifiedTile;
}