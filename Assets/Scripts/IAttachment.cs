using UnityEngine;

public interface IAttachment
{
    void OnAttached(IAttachPoint attachPoint);
    void OnDetached(IAttachPoint attachPoint);
    Vector3Int GetDimension();
}
