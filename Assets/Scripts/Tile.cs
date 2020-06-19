using System;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Walkable walkable;
    public ITileAttachment attachment;
    public Tile claimant;

    public enum Walkable
    {
        UNWALKABLE,
        WALKABLE
    }

    public bool isWalkable() {
        return walkable == Walkable.WALKABLE;
    }

    public ITileAttachment GetAttachment() {
        return attachment;
    }

    public bool Attach(GameObject attachmentPrefab) {
        if (IsClaimed()) {
            Debug.LogWarning("Could not attach object to tile, because it is already claimed by another claimant...");
            return false;
        }

        if (attachment == null) {
            GameObject go = Instantiate(attachmentPrefab);
            go.transform.SetParent(transform);
            go.transform.localPosition = Vector3.zero;
            ITileAttachment attachment = go.GetComponent(typeof(ITileAttachment)) as ITileAttachment;
            this.attachment = attachment;
            attachment.OnAttached(this);
            return true;
        } else
        {
            Debug.LogWarning("Failed to attach object to tile, because it is already occupied...");
            return false;
        }
    }

    public bool Detach()
    {
        if (IsClaimed())
        {
            Debug.LogWarning("Could not detach object from tile, because it is claimed by another tile, only the claimant can detach the attachment...");
            return false;
        }

        if (attachment != null) {
            attachment = null;
            attachment.OnDetached(this);
            return true;
        } else {
            Debug.LogWarning("Failed to detach object from tile, because no object is attached...");
            return false;
        }
    }

    public bool HasAttachment() {
        return (attachment != null);
    }

    public bool IsClaimed() {
        return (claimant != null);
    }

    public bool Claim(Tile claimant)
    {
        if (IsClaimed())
        {
            Debug.LogWarning("Tile could not be claimed, because it already have a claimant...");
            return false;
        }

        this.claimant = claimant;
        return true;
    }
    public bool Unclaim(Tile claimant)
    {
        if (!IsClaimed())
        {
            Debug.LogWarning("Tile could not be unclaimed, because it has no claimant...");
            return false;
        }

        this.claimant = null;
        return true;
    }
}
