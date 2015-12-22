using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

class MapPrefab : MonoBehaviour
{
    //public file map
    public int widthMap = 12;
    public int heigthMap = 12;
    public float centerMapXWithTile = 0;
    public float centerMapYWithTile = 0;
    public float centerMapX = 0;
    public float centerMapY = 0;

    public TilePrefab tilePrototype;

    private Dictionary<Vector2, TilePrefab> tilePrefabContainer;
    private Map MapPlayer;
    private BoxCollider2D colliderMap2d;
    void Awake()
    {
        if (tilePrototype == null)
            Debug.LogError("Miss till prototype reference in map prefab script");


        tilePrefabContainer = new Dictionary<Vector2, TilePrefab>();
        MapPlayer = new Map();
    }
    void Start()
    {
        MapPlayer.GenerateMap(widthMap, heigthMap);
        //test
        int i = 0;
        foreach (Tile tile in MapPlayer.TilesContainer)
        {
            AddTileToMap(tile, i);
            //test
            i++;
        }

        SetCenterMap();
        SetMapCollider();
        gameObject.transform.position -= new Vector3(centerMapXWithTile, centerMapYWithTile, 0f);
    }

    private void SetMapCollider()
    {
        colliderMap2d = gameObject.AddComponent<BoxCollider2D>();
        colliderMap2d.offset = new Vector2(centerMapXWithTile, centerMapYWithTile);
        colliderMap2d.size = new Vector2(widthMap, heigthMap);
    }

    private void SetCenterMap()
    {
        centerMapX = ((float)widthMap / 2);
        centerMapY = ((float)heigthMap / 2);

        centerMapXWithTile = (centerMapX - (tilePrototype.widthTile / 2));
        centerMapYWithTile = (centerMapY - (tilePrototype.heigthTile / 2));

    }

    private void AddTileToMap(Tile tile, int i)
    {
        TilePrefab newTile = GameObject.Instantiate<TilePrefab>(tilePrototype);
        newTile.transform.SetParent(gameObject.transform);
        newTile.InitTile(tile);
        //test
        newTile.name = "tile no " + i;
        newTile.spriteRendererTile.color = Color.blue;
        tilePrefabContainer.Add(newTile.GetTilePosition(), newTile);
    }

    public TilePrefab GetTilPrefeb(Vector2 tileKey)
    {
        if (tilePrefabContainer.ContainsKey(tileKey))
            return tilePrefabContainer[tileKey];
        else
            return null;
    }
}

