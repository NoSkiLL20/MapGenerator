using UnityEngine;

public class TileVO
{
    public Vector3 Position { get; set; }
    public bool IsBuildable { get; set; }
    public bool IsAvailable { get; set; }

    public TileVO(Vector3 position, bool isBuildable = true, bool isAvailable = true)
    {
        this.Position = position;
        this.IsBuildable = IsBuildable;
        this.IsAvailable = isAvailable;
    }
}

