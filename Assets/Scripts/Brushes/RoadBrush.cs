using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBrush : MonoBehaviour, IBrush
{
    private Vector3Int drawBeginCoordinate;
    public bool DrawBegin(Map map, Vector3Int coordinate, GameObject brushPrefab)
    {
        drawBeginCoordinate = coordinate;
        return true;
    }

    public bool DrawEnd(Map map, Vector3Int coordinate, GameObject brushPrefab)
    {
        map.Attach(drawBeginCoordinate.x, drawBeginCoordinate.z, brushPrefab);
        return map.Attach(coordinate.x, coordinate.z, brushPrefab);
    }

    public void DrawPreview(Map map, Vector3Int coordinate, GameObject brushPrefab)
    {

    }

    public void Reset()
    {

    }
}
