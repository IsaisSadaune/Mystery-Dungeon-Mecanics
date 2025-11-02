using System;
using System.Collections.Generic;
using UnityEngine;


//MODEL

public class Tiles : MonoBehaviour
{
    [field:SerializeField] public OranBerry oranBerry { get; private set; }
    //Sol, zone du bas
    public TilesTypes[,] Map { get; private set; } = 
        { 
        { TilesTypes.Wall, TilesTypes.Wall, TilesTypes.Wall, TilesTypes.Wall, TilesTypes.Wall }, 
        { TilesTypes.Wall, TilesTypes.Ground, TilesTypes.Ground, TilesTypes.Ground, TilesTypes.Wall }, 
        { TilesTypes.Wall, TilesTypes.Ground, TilesTypes.Ground, TilesTypes.Ground, TilesTypes.Wall }, 
        { TilesTypes.Wall, TilesTypes.Ground, TilesTypes.Ground, TilesTypes.Ground, TilesTypes.Wall }, 
        { TilesTypes.Wall, TilesTypes.Ground, TilesTypes.Ground, TilesTypes.Ground, TilesTypes.Wall }, 
        { TilesTypes.Wall, TilesTypes.Ground, TilesTypes.Ground, TilesTypes.Ground, TilesTypes.Wall }, 
        { TilesTypes.Wall, TilesTypes.Ground, TilesTypes.Ground, TilesTypes.Ground, TilesTypes.Wall }, 
        { TilesTypes.Wall, TilesTypes.Ground, TilesTypes.Ground, TilesTypes.Ground, TilesTypes.Wall }, 
        { TilesTypes.Wall, TilesTypes.Wall, TilesTypes.Wall, TilesTypes.Wall, TilesTypes.Wall }, 
    };

    //Au sol, zone milieu
    public Items[,] ItemsMap { get; private set; } =        
    {
        { null, null, null, null, null },
        { null, null, null, null, null },
        { null, null, null, null, null },
        { null, null, null, null, null },
        { null, null, null, null, null },
        { null, null, null, null, null },
        { null, null, null, null, null },
        { null, null, null, null, null },
        { null, null, null, null, null },
    };

    public void AddItemAt(Items i, int x, int y)
    {
        ItemsMap[x, y] = i;
    }

    public void RemoveItemAt(int x,int y)
    {
        ItemsMap[x, y] = null;
    }
}


public enum TilesTypes
{
    Ground = 0,
    Wall = 1,
    Water = 2
}