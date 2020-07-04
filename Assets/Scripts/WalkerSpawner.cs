using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerSpawner : MonoBehaviour
{
    public GameObject walkerPrefab;
    private GameObject walker;
    private float spawnCooldown = 1f;
    private float spawnCooldownTimer = 0f;

    Map map;
    IAttachment attachment;

    void Start() {
        map = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>();
        attachment = GetComponent(typeof(IAttachment)) as IAttachment;

        Vector3Int pos = Vector3Int.FloorToInt(transform.position);
    }

    void Update()
    {
        spawnCooldownTimer -= Time.deltaTime;

        if (spawnCooldownTimer <= 0) {
            spawnCooldownTimer += spawnCooldown;

            if (walker == null) { 
                TrySpawnWalker();
            }
        }
    }

    void TrySpawnWalker() {
        ITile tile = FindSpawnTile();
        if (tile != null) {
            walker = Instantiate(walkerPrefab, tile.GetCoordinate(), Quaternion.identity);
        }
    }

    ITile FindSpawnTile() {
        Vector3Int myPos = Vector3Int.FloorToInt(transform.position);

        int x = 0;
        int z = -1;

        for (; x < attachment.GetDimension().x; x++) {
            ITile tile = map.GetTile(myPos.x + x, myPos.z + z);
            if (tile != null && tile.GetAttachment() is Road) {
                return tile;
            }
        }

        for (; z < attachment.GetDimension().z; z++) {
            ITile tile = map.GetTile(myPos.x + x, myPos.z + z);
            if (tile != null && tile.GetAttachment() is Road) {
                return tile;
            }
        }

        for (; x > -1; x--) {
            ITile tile = map.GetTile(myPos.x + x, myPos.z + z);
            if (tile != null && tile.GetAttachment() is Road) {
                return tile;
            }
        }

        for (; z >= -1; z--) {
            ITile tile = map.GetTile(myPos.x + x, myPos.z + z);
            if (tile != null && tile.GetAttachment() is Road) {
                return tile;
            }
        }

        return null;
    }
}
