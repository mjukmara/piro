using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ResourceData
{
    public enum TYPE {
        MINERALS,
        WATER,
        FUEL
    }

    public string id;
    public int minerals = 135000;
    public int water =  68000;
    public int fuel = 21500;

    public int GetResource(TYPE type) {
        switch (type) {
            case TYPE.MINERALS:
                return minerals;
            case TYPE.WATER:
                return water;
            case TYPE.FUEL:
                return fuel;
            default:
                return 0;
        }
    }
}
