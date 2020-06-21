using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBrush : MonoBehaviour, IBrush
{
    private Vector3Int? drawBeginCoordinate = null;

    List<GameObject> previewObjectsX = new List<GameObject>();
    List<GameObject> previewObjectsZ = new List<GameObject>();

    public bool DrawBegin(Map map, Vector3Int coordinate, GameObject brushPrefab)
    {
        drawBeginCoordinate = coordinate;
        return true;
    }

    public bool DrawEnd(Map map, Vector3Int coordinate, GameObject brushPrefab)
    {
        foreach (GameObject previewObject in previewObjectsX)
        {
            if (previewObject.activeSelf)
            {
                Vector3Int pos = Vector3Int.FloorToInt(previewObject.transform.position);
                map.Attach(pos.x, pos.z, brushPrefab);
                previewObject.SetActive(false);
            }
        }

        foreach (GameObject previewObject in previewObjectsZ)
        {
            if (previewObject.activeSelf)
            {
                Vector3Int pos = Vector3Int.FloorToInt(previewObject.transform.position);
                map.Attach(pos.x, pos.z, brushPrefab);
                previewObject.SetActive(false);
            }
        }

        return true;
    }

    public void DrawPreview(Map map, Vector3Int coordinate, GameObject brushPrefab)
    {
        if (drawBeginCoordinate == null) return;

        DrawPreviewRepeat(map, previewObjectsX, drawBeginCoordinate.GetValueOrDefault(), coordinate, brushPrefab, new Vector3Int(0, 0, 1), false);
        DrawPreviewRepeat(map, previewObjectsZ, drawBeginCoordinate.GetValueOrDefault(), coordinate, brushPrefab, new Vector3Int(1, 0, 0), true);
    }

    public void Reset()
    {
        drawBeginCoordinate = null;
        
        foreach (GameObject previewObject in previewObjectsX)
        {
            previewObject.SetActive(false);
        }

        foreach (GameObject previewObject in previewObjectsZ)
        {
            previewObject.SetActive(false);
        }
    }

    public void DrawPreviewRepeat(Map map, List<GameObject> previewObjects, Vector3Int begin, Vector3Int end, GameObject brushPrefab, Vector3Int direction, bool invert)
    {
        int d = direction.x * (end.x - begin.x) + direction.z * (end.z - begin.z);
        int count = Mathf.Abs(d) + 1;

        for (int i = count; i < previewObjects.Count; i++)
        {
            previewObjects[i].SetActive(false);
        }

        for (int i = 0; i < count; i++)
        {
            int x = drawBeginCoordinate.GetValueOrDefault().x + direction.x * (int)Mathf.Sign(d) * i;
            int z = drawBeginCoordinate.GetValueOrDefault().z + direction.z * (int)Mathf.Sign(d) * i;

            if (invert) {
                if (direction.x != 0)
                {
                    z = end.z;
                }
                if (direction.z != 0)
                {
                    x = end.x;
                }
            }

            if (!map.IsWithinBounds(x, z)) continue;

            GameObject previewObject;
            if (i >= previewObjects.Count)
            {
                previewObject = Instantiate(brushPrefab);
                previewObjects.Add(previewObject);
            }
            else
            {
                previewObject = previewObjects[i];
            }
            previewObject.transform.position = new Vector3(x, 0, z);
            previewObject.SetActive(true);

            if (map.IsTileSpaceOccupied(x, z, 1, 1))
            {
                previewObject.SetActive(false);
            };
        }
    }
}
