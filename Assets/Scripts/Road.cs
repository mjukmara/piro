using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Road : MonoBehaviour, ITileAttachment
{
    public int width = 1;
    public int length = 1;

    public Vector3Int GetDimension()
    {
        return new Vector3Int(width, 0, length);
    }

    public void OnAttached(Tile tile)
    {
        //throw new NotImplementedException();
    }

    public void OnDetached(Tile tile)
    {
        //throw new NotImplementedException();
    }
}
