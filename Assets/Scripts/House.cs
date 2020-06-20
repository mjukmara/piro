using UnityEngine;

public class House : MonoBehaviour, IAttachment
{
    public int width = 1;
    public int length = 1;

    public void OnAttached(IAttachPoint attachPoint)
    {
        //throw new System.NotImplementedException();
    }

    public void OnDetached(IAttachPoint attachPoint)
    {
        //throw new System.NotImplementedException();
    }

    public Vector3Int GetDimension()
    {
        return new Vector3Int(width, 0, length);
    }
}
