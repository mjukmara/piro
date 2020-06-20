using UnityEngine;

public interface IAttachPoint
{
    bool Attach(IAttachment attachment);
    bool Detach(IAttachment attachment);
    bool DetachAny();
    IAttachment GetAttachment();
    bool HasAttachment();
}
