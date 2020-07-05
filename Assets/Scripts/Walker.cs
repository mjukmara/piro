﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Walker : MonoBehaviour
{
    private Map map;

    private float walkRate = 1.25f;
    private ITile lastTile;
    private ITile destinationTile;
    private float walkStart = 0f;

    private int maxSteps = 16;
    private int steps = 0;
    private List<ITile> memory = new List<ITile>();

    void Start()
    {

    }

    void Update() {
        if (lastTile != null && destinationTile != null) {
            // Tween move
            float progress = (Time.time - walkStart) / (1f / walkRate);
            transform.position = Vector3.Lerp(lastTile.GetCoordinate(), destinationTile.GetCoordinate(), LeanTween.easeInOutCubic(0f, 1f, progress));
        }

        if (Time.time > walkStart + 1f / walkRate) {
            if (!map) {
                GameObject go = GameObject.FindGameObjectWithTag("Map");
                if (go != null) {
                    map = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>();
                }
            }


            if (steps >= maxSteps * 2 || (steps > 0 && memory.Count == 0)) {
                Destroy(gameObject);
            }

            TryWalk();
        }
    }

    void TryWalk() {

        if (map) {
            ITile roadTile = GetDestinationRoadTile();
            if (roadTile != null) {
                Vector3Int pos = Vector3Int.FloorToInt(transform.position);
                lastTile = map.GetTile(pos.x, pos.z);
                destinationTile = roadTile;
                walkStart = Time.time;

                bool backtraced = false;
                for (int i=0; i<memory.Count; i++) {
                    ITile tile = memory[i];
                    if (tile == destinationTile) {
                        Debug.Log("Already been here");
                        memory = memory.Take(i).ToList();
                        backtraced = true;
                        break;
                    }
                }

                if (!backtraced) {
                    if (steps < maxSteps) {
                        memory.Add(lastTile);
                    }
                }

                steps++;
            }
        }
    }

    ITile GetDestinationRoadTile() {
        if (steps >= maxSteps && memory.Count > 0) {
            ITile destinationTile = memory[memory.Count - 1];
            memory.RemoveAt(memory.Count - 1);
            return destinationTile;
        }

        Vector3Int pos = Vector3Int.FloorToInt(transform.position);

        ITile tile = map.GetTile(pos.x, pos.z);
        IAttachment attachment = tile.GetAttachment();
        if (attachment != null) {

            if (attachment is Road) {
                Road road = (Road)attachment;

                List<ITile> adjacentRoadTiles = new List<ITile>();
                List<ITile> adjacentTiles = map.GetAdjacentTiles(pos.x, pos.z);
                foreach (ITile adjacentTile in adjacentTiles) {
                    if (adjacentTile.GetAttachment() is Road) {
                        adjacentRoadTiles.Add(adjacentTile);
                    }
                }

                if (adjacentRoadTiles.Count > 1) {
                    adjacentRoadTiles.Remove(lastTile);
                }

                if (adjacentRoadTiles.Count > 0) {
                    return adjacentRoadTiles[Random.Range(0, adjacentRoadTiles.Count)];
                } else {
                    // NOP
                }
            }
        }

        return null;
    }
}
