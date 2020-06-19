using UnityEngine;

public interface ITileAttachment
{
    Vector3Int GetDimension();
    void OnAttached(Tile tile);
    void OnDetached(Tile tile);
}
