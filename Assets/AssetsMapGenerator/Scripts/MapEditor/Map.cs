using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class Map 
{
    public int IdMap { get; set; }
    public Tile[,] TilesContainer { get; set; }

    public void GenerateMap(int width, int heigth)
    {
        TilesContainer = new Tile[width, heigth];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < heigth; y++)
            {
                Tile tile = new Tile(new Vector3(x, y, 1f));
                TilesContainer[x, y] = tile;
            }
        }
    }


}
