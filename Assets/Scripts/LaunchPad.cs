using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPad : MonoBehaviour, IAttachment
{
    public int width = 1;
    public int length = 1;

    void Start() {
    
    }

    public Vector3Int GetDimension()
    {
        return new Vector3Int(width, 0, length);
    }

    public void OnAttached(IAttachPoint attachPoint)
    {
        //throw new System.NotImplementedException();
    }

    public void OnDetached(IAttachPoint attachPoint)
    {
        //throw new System.NotImplementedException();
    }
}
