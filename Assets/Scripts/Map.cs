using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Map : MonoBehaviour
{
    public MapData mapData;

    public Camera cam;
    public Tile[] tiles;
    //public int width = 8;
    //public int length = 8;
    public Tile tilePrefab;

    private Tuple<int,int>[] offsets = {
        Tuple.Create(1, 0),
        Tuple.Create(0, 1),
        Tuple.Create(-1, 0),
        Tuple.Create(0, -1)
    };

    void Awake()
    {
        mapData = Game.Instance.gameState.mapData;
        Generate(mapData.width, mapData.length);
    }

    public bool IsWithinBounds(int x, int z)
    {
        if (x < 0 || z < 0) return false;
        if (x >= GetWidth()) return false;
        if (z >= GetLength()) return false;
        return true;
    }

    public Vector3Int? MouseToCoordinateInt()
    {
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
        float entry;

        if (plane.Raycast(ray, out entry))
        {
            Vector3Int coordinate = Vector3Int.FloorToInt(ray.GetPoint(entry) + new Vector3(.5f, 0f, .5f));
            return coordinate;
        }

        return null;
    }

    public Vector3? MouseToCoordinate()
    {
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
        float entry;

        if (plane.Raycast(ray, out entry))
        {
            Vector3 coordinate = ray.GetPoint(entry) + new Vector3(.5f, 0f, .5f);
            return coordinate;
        }

        return null;
    }

    void Generate(int width, int length)
    {
        tiles = new Tile[width * length];
        for (int i = 0, z = 0; z < length; z++)
        {
            for (int x = 0; x < width; x++, i++)
            {
                CreateTile(Convert.ToInt32(x), Convert.ToInt32(z), tilePrefab);
            }
        }
    }

    public Tile CreateTile(int x, int z, Tile tilePrefab) {
        Tile tile = Instantiate(tilePrefab);
        tile.gameObject.transform.SetParent(gameObject.transform);
        tile.gameObject.transform.localPosition = new Vector3(x, 0, z);
        tile.gameObject.name = "Tile_" + Convert.ToInt32(x) + "x" + Convert.ToInt32(z);
        tiles[x + z * mapData.width] = tile;
        return tile;
    }
    
    public Tile GetTile(int x, int z)
    {
        if (x < 0 || x >= mapData.width || z < 0 || z >= mapData.length) {
            Debug.LogError("Impossible to find tile outside of map bounds...");
            return null;
        }

        return tiles[x + z * mapData.width];
    }

    public bool Attach(int x, int z, GameObject attachmentPrefab) {
        if (x < 0 || x >= mapData.width) return false;
        if (z < 0 || z >= mapData.length) return false;


        Tile tile = GetTile(x, z);

        if (!tile.HasAttachment())
        {
            GameObject attachmentGO = Instantiate(attachmentPrefab);
            attachmentGO.transform.SetParent(transform);
            attachmentGO.transform.localPosition = Vector3.zero;
            attachmentGO.transform.position = new Vector3(x, 0, z);
            IAttachment attachment = attachmentGO.GetComponent(typeof(IAttachment)) as IAttachment;

            // A large attachment occupies more than one tile, therefore we must ensure that none of the affected tiles have any attachment.
            Vector3Int dim = attachment.GetDimension();
            if (IsTileSpaceOccupied(x, z, dim.x, dim.z))
            {
                Debug.LogWarning("Can not attach object to tile. At least one tile is already occupied...");
                Destroy(attachmentGO);
                return false;
            }

            bool attached = tile.Attach(attachment);
            if (attached)
            {
                bool claimedTiles = AssignClaimantToTiles(x, z, dim.x, dim.z);
                if (!claimedTiles)
                {
                    Debug.LogError("Failed to claim nearby tiles!");
                    return false;
                }
                return true;
            }
            else
            {
                Debug.LogError("Failed to attach...");
                return false;
            }
        } else
        {
            Debug.LogWarning("Failed to attach, because the tile already has an attachment...");
            return false;
        }
    }

    public bool Detach(int x, int z) {
        Tile tile = GetTile(x, z);
        bool detached = tile.DetachAny();
        if (detached)
        {
            return true;
        }
        else
        {
            Debug.LogWarning("Failed to detach...");
            return false;
        }
    }

    public List<Tile> GetTiles(int x, int z, int width, int length) {
        List<Tile> tiles = new List<Tile>();

        for (int _z = z; _z < z+length; _z++)
        {
            if (_z >= mapData.length) break;

            for (int _x = x; _x < x+width; _x++)
            {
                if (_x >= mapData.width) break;

                Tile tile = GetTile(_x, _z);
                if (tile)
                {
                    tiles.Add(tile);
                }
            }
        }
        return tiles;
    }

    public bool IsTileSpaceOccupied(int x, int z, int width, int length)
    {
        if (x < 0) return true;
        if (z < 0) return true;
        if (x + width - 1 >= mapData.width) return true;
        if (z + length - 1 >= mapData.length) return true;

        List<Tile> affectedTiles = GetTiles(x, z, width, length);
        foreach (Tile affectedTile in affectedTiles)
        {
            if (affectedTile.HasAttachment())
            {
                return true;
            }
            if (affectedTile.IsClaimed()) {
                return true;
            }
        }
        return false;
    }

    public bool AssignClaimantToTiles(int x, int z, int width, int length) {
        Tile claimant = GetTile(x, z);

        for (int _z = z; _z < z + length; _z++)
        {
            for (int _x = x; _x < x + width; _x++)
            {
                Tile tile = GetTile(_x, _z);

                if (claimant == tile) continue;

                if (tile)
                {
                    bool claimed = tile.SetClaimant(claimant);
                    if (!claimed) {
                        Debug.LogError("Failed to claim tile!");
                        return false;
                    }
                }
            }
        }

        return true;
    }

    /*
    public void ReplaceTile(int x, int z, Tile newTilePrefab) {
        if (x < 0 || x >= width) return;
        if (z < 0 || z >= width) return;

        Tile tile = tiles[x + z * width];
        if (tile != null) {
            Destroy(tile.gameObject);
        }

        CreateTile(x, z, newTilePrefab);
    }*/

    public List<Tile> AdjacentWalkableTiles(int x, int z) {
        List<Tile> adjacentTiles = new List<Tile>();
        foreach (Tuple<int, int> offset in offsets) {
            int offsetX = offset.Item1;
            int offsetZ = offset.Item2;

            int tileX = x + offsetX;
            int tileZ = z + offsetZ;

            if (tileX < 0 || tileX >= mapData.width || tileZ < 0 || tileZ >= mapData.length) {
                continue;
            }

            Tile tile = GetTile(tileX, tileZ);
            if (tile == null) {
                continue;
            }

            adjacentTiles.Add(tile);
        }
        return adjacentTiles;
    }

    public int GetWidth()
    {
        return mapData.width;
    }

    public int GetLength()
    {
        return mapData.length;
    }

    public void SaveMap()
    {

    }
}
