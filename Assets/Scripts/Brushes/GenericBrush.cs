using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericBrush : MonoBehaviour, IBrush
{
    GameObject previewObject;
    public ITileAttachment tileAttachment;
    public Renderer[] previewObjectRenderers;

    public bool DrawBegin(Map map, Vector3Int coordinate, GameObject brushPrefab)
    {
        if (brushPrefab)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool DrawEnd(Map map, Vector3Int coordinate, GameObject brushPrefab)
    {
        if (brushPrefab)
        {
            return map.Attach(coordinate.x, coordinate.z, brushPrefab);
        } else
        {
            return false;
        }
    }

    public void DrawPreview(Map map, Vector3Int coordinate, GameObject brushPrefab)
    {
        if (!previewObject && brushPrefab != null)
        {
            previewObject = Instantiate(brushPrefab);
            tileAttachment = previewObject.GetComponent(typeof(ITileAttachment)) as ITileAttachment;
            previewObjectRenderers = previewObject.GetComponentsInChildren<Renderer>();
        }

        if (previewObject)
        {
            previewObject.transform.position = new Vector3(coordinate.x, 0, coordinate.z);

            if (map.IsWithinBounds(coordinate.x, coordinate.z) &&
                map.IsWithinBounds(coordinate.x + tileAttachment.GetDimension().x - 1,
                coordinate.z + tileAttachment.GetDimension().z - 1))
            {
                previewObject.SetActive(true);
            } else
            {
                previewObject.SetActive(false);
            }

            bool occupied = map.IsTileSpaceOccupied(coordinate.x,
               coordinate.z,
               tileAttachment.GetDimension().x,
               tileAttachment.GetDimension().z);

            if (occupied)
            {
                foreach (Renderer rend in previewObjectRenderers)
                {
                    rend.material.color = Color.red;
                }
            }
            else
            {
                foreach (Renderer rend in previewObjectRenderers)
                {
                    rend.material.color = Color.green;
                }
            }
        }
    }

    public void Reset()
    {
        Destroy(previewObject);
    }
}
