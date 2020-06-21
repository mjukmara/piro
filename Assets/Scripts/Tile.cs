using System;
using UnityEngine;

public class Tile : MonoBehaviour, ITile
{
    public IAttachment attachment;
    private IClaimant claimant;

    public IAttachment GetAttachment()
    {
        return attachment;
    }

    public bool Attach(IAttachment attachment)
    {
        if (IsClaimed())
        {
            Debug.LogWarning("Could not attach object to tile, because it is already claimed by another claimant...");
            return false;
        }

        if (HasAttachment())
        {
            Debug.LogWarning("Failed to attach object to tile, because it is already occupied...");
            return false;
        }

        //GameObject go = Instantiate(attachmentPrefab);
        //go.transform.SetParent(transform);
        //go.transform.localPosition = Vector3.zero;
        //ITileAttachment attachment = go.GetComponent(typeof(ITileAttachment)) as ITileAttachment;
        this.attachment = attachment;
        attachment.OnAttached(this);
        return true;
    }

    public bool Detach(IAttachment attachment)
    {
        if (!HasAttachment())
        {
            Debug.LogWarning("Failed to detach specified object, because nothing is attached...");
            return false;
        }

        if (this.attachment == attachment)
        {
            this.attachment = null;
            this.attachment.OnDetached(this);
            return true;
        } else
        {
            Debug.LogWarning("Failed to detach specified object, because it is not attached...");
            return false;
        }
    }

    public bool DetachAny()
    {
        if (!HasAttachment())
        {
            Debug.LogWarning("Failed to detach any object, because nothing is attached...");
            return false;
        }

        if (IsClaimed())
        {
            Debug.LogWarning("Could not detach object from tile, because it is claimed by another tile, only the claimant can detach the attachment...");
            return false;
        }

        IAttachment attachment = this.attachment;
        this.attachment = null;
        attachment.OnDetached(this);
        return true;
    }

    public bool HasAttachment()
    {
        return (attachment != null);
    }

    public bool IsClaimed()
    {
        return (claimant != null);
    }

    public bool IsClaimedBy(IClaimant claimant)
    {
        throw new NotImplementedException();
    }

    public bool SetClaimant(IClaimant claimant)
    {
        if (IsClaimed())
        {
            Debug.LogWarning("Tile could not be claimed, because it already have a claimant...");
            return false;
        }

        this.claimant = claimant;
        return true;
    }

    public bool UnsetClaimant(IClaimant claimant)
    {
        if (!IsClaimed())
        {
            Debug.LogWarning("Tile could not be unclaimed, because it has no claimant...");
            return false;
        }

        this.claimant = null;
        return true;
    }

    public IClaimant GetClaimant()
    {
        return claimant;
    }

    public void OnNeighborChanged(ITile neighbor)
    {
        int dx = neighbor.GetCoordinate().x - GetCoordinate().x;
        int dz = neighbor.GetCoordinate().z - GetCoordinate().z;

        bool isRight = (dx == 1 && dz == 0);
        bool isLeft = (dx == -1 && dz == 0);
        bool isForward = (dx == 0 && dz == 1);
        bool isBackward = (dx == 0 && dz == -1);

        IAttachment attachment = GetAttachment();
        IAttachment neighborAttachment = neighbor.GetAttachment();
        if (attachment is Road)
        {
            Road road = (Road)attachment;

            bool isNeighborRoad = (neighborAttachment is Road);
            if (isNeighborRoad && isRight) road.connectRight = true;
            if (isNeighborRoad && isLeft) road.connectLeft = true;
            if (isNeighborRoad && isForward) road.connectForward = true;
            if (isNeighborRoad && isBackward) road.connectBackward = true;
        }
    }

    public Vector3Int GetCoordinate()
    {
        return Vector3Int.FloorToInt(transform.position);
    }
}
