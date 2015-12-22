using UnityEngine;
using System.Collections;

public class Tile 
{
    public Vector3 Position { get; set; }
    public bool IsBuildable { get; set; }
    public bool IsAvailble { get; set; }
    
    public Tile(Vector3 position, bool isBuildable = true, bool isAvailable = true)
    {
        this.Position = position;
        this.IsBuildable = isBuildable;
        this.IsAvailble = isAvailable;
    }

    public Tile(TileVO dataTile)
    {
        this.Position = dataTile.Position;
        this.IsBuildable = dataTile.IsBuildable;
        this.IsAvailble = dataTile.IsAvailable;
    }

    public Tile()
    {
        this.Position = Vector3.zero;
        this.IsBuildable = true;
        this.IsAvailble = true;
    }
}
