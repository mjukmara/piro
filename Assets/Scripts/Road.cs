using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Road : MonoBehaviour, IAttachment
{
    public int width = 1;
    public int length = 1;

    public enum TYPE
    {
        NOWAY,
        ONEWAY,
        TWOWAY,
        THREEWAY,
        FOURWAY,
        CURVE
    }

    public GameObject noway;
    public GameObject oneway;
    public GameObject twoway;
    public GameObject threeway;
    public GameObject fourway;
    public GameObject curve;

    public bool connectRight = false;
    public bool connectLeft = false;
    public bool connectForward = false;
    public bool connectBackward = false;

    public TYPE type;

    private GameObject _ways;

    void Update()
    {
        type = DetermineType();
        transform.rotation = Quaternion.Euler(new Vector3(0, DetermineRotationAngle(), 0));

        noway.SetActive(type == TYPE.NOWAY);
        oneway.SetActive(type == TYPE.ONEWAY);
        twoway.SetActive(type == TYPE.TWOWAY);
        threeway.SetActive(type == TYPE.THREEWAY);
        fourway.SetActive(type == TYPE.FOURWAY);
        curve.SetActive(type == TYPE.CURVE);
    }

    public void SetConnections(bool connectRight, bool connectLeft, bool connectForward, bool connectBackward)
    {
        this.connectRight = connectRight;
        this.connectLeft = connectLeft;
        this.connectForward = connectForward;
        this.connectBackward = connectBackward;
    }

    public TYPE DetermineType()
    {
        TYPE type = 0;
        if (connectRight) type += 1;
        if (connectLeft) type += 1;
        if (connectForward) type += 1;
        if (connectBackward) type += 1;

        if (type == TYPE.TWOWAY)
        {
            if (connectRight && connectLeft)
            {
                // Straight
            }
            else if (connectForward && connectBackward)
            {
                // Straight
            }
            else
            {
                // Curve
                type = TYPE.CURVE;
            }
        }

        return type;
    }

    public int DetermineRotationAngle()
    {
        if (type == TYPE.NOWAY || type == TYPE.FOURWAY) return 0;

        if (type == TYPE.ONEWAY)
        {
            if (connectLeft) { return 0; }
            if (connectRight) { return 180; }
            if (connectForward) { return 90; }
            if (connectBackward) { return 270; }
        }

        if (type == TYPE.TWOWAY)
        {
            if (connectRight && connectLeft) { return 0; }
            if (connectForward && connectBackward) { return 90; }
        }

        if (type == TYPE.THREEWAY)
        {
            if (!connectLeft) { return 180; }
            if (!connectRight) { return 0; }
            if (!connectForward) { return 270; }
            if (!connectBackward) { return 90; }
        }

        if (type == TYPE.CURVE)
        {
            if (connectRight && connectForward) { return 90; }
            if (connectForward && connectLeft) { return 0; }
            if (connectLeft && connectBackward) { return 270; }
            if (connectBackward && connectRight) { return 180; }
        }

        return 0;
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
