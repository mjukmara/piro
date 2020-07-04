using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericBrush : MonoBehaviour, IBrush
{
    GameObject previewObject;
    public GameObject drawObject;
    public IAttachment attachment;
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
        if (drawObject)
        {
            return map.Attach(coordinate.x, coordinate.z, drawObject);
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
            attachment = previewObject.GetComponentInChildren(typeof(IAttachment)) as IAttachment;
            previewObjectRenderers = previewObject.GetComponentsInChildren<Renderer>();
        }

        if (previewObject)
        {
            previewObject.transform.position = new Vector3(coordinate.x, 0, coordinate.z);

            if (map.IsWithinBounds(coordinate.x, coordinate.z) &&
                map.IsWithinBounds(coordinate.x + attachment.GetDimension().x - 1,
                coordinate.z + attachment.GetDimension().z - 1))
            {
                previewObject.SetActive(true);
            } else
            {
                previewObject.SetActive(false);
            }

            bool occupied = map.IsTileSpaceOccupied(coordinate.x,
               coordinate.z,
               attachment.GetDimension().x,
               attachment.GetDimension().z);

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
