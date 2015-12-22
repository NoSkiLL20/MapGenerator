using System;
using System.Collections.Generic;
using UnityEngine;
class TilePrefab : MonoBehaviour
{
    private Tile tile;

    public float widthTile = 0;
    public float heigthTile = 0;

    public Collider2D colliderTile;
    public SpriteRenderer spriteRendererTile;
    
    private Color itemToApplied;
    void Awake()
    {
        colliderTile = gameObject.GetComponent<Collider2D>();
        spriteRendererTile = gameObject.GetComponent<SpriteRenderer>();
        itemToApplied = Color.blue;
    }

    void Start()
    {
       widthTile = gameObject.GetComponent<RectTransform>().rect.width;
       heigthTile = gameObject.GetComponent<RectTransform>().rect.height;
    }

    public void InitTile(Tile tile)
    {
        this.tile = tile;

        SetTilePosition(tile.Position);
    }

    public Vector3 GetTilePosition()
    {
        return tile.Position;
    }

    public bool IsBuildable()
    {
        return tile.IsBuildable;
    }

    public bool IsAvailable()
    {
        return tile.IsAvailble;
    }

    private void SetTilePosition(Vector3 tilePosition)
    {
        gameObject.transform.position = new Vector3(tilePosition.x, tilePosition.y, tilePosition.z);
    }

    private void SetContructableItem(Color itemSelected)
    {
        itemToApplied = itemSelected;
    }


}

