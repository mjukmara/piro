using UnityEngine;

public interface ITile: IClaimable, IClaimant, IAttachPoint
{
    Vector3Int GetCoordinate();
    void OnNeighborChanged(ITile neighbor);
}
