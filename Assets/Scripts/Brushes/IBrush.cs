using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBrush
{
    void DrawPreview(Map map, Vector3Int coordinate, GameObject brushPrefab);
    bool DrawBegin(Map map, Vector3Int coordinate, GameObject brushPrefab);
    bool DrawEnd(Map map, Vector3Int coordinate, GameObject brushPrefab);
    void Reset();
}
