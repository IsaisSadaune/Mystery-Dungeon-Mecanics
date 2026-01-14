using System.Collections.Generic;
using UnityEngine;


public class new_Map : MonoBehaviour
{
    private new_Tile[,] Map;

    public int MapLengthY => Map.GetLength(0);
    public int MapLengthX => Map.GetLength(1);

    public Player p { get; private set; }

    public Entity e { get; private set; }

    [SerializeField] private Items testItem;
    [SerializeField] private Items testItem2;

    private Items TMP_GetRandom_Berry()
    {
        int x = Random.Range(0,2);
        return x == 1 ? testItem : testItem2; 

    }

    /// <summary>
    /// Créé une carte.
    /// Les contours sont des murs, tout le reste est du sol.
    /// </summary>
    /// <param name="sizeX"></param>
    /// <param name="sizeY"></param>
    public new_Tile[,] CreateMap(int sizeX, int sizeY)
    {
        string dbg = "";

        Map = new new_Tile[sizeY, sizeX];

        for (int y = 0; y < sizeY; y++)
        {
            for (int x = 0; x < sizeX; x++)
            {
                if (y == 0 || x == 0 || y == sizeY - 1 || x == sizeX - 1)
                    Map[y, x] = new new_Tile(TilesTypes.Wall);
                else
                {
                    Map[y, x] = new new_Tile(TilesTypes.Ground);
                    RandomSpawnBerry(Map[y, x]);
                }
                dbg += Map[y, x]._tt.ToString();
            }
            //Debug.Log(dbg);
            dbg = "";
        }
        return Map;
    }

    public bool RandomSpawnBerry(new_Tile nt)
    {
        if (Random.Range(0, 10) == 5)
        {
            nt.SetItem(TMP_GetRandom_Berry());
            return true;
        }
        return false;
    }

    [ContextMenu("Debug Map 5x5")]
    public void CreateMap5x5() => CreateMap(5, 5);

    public bool AddItemToTile(Items i, int x, int y) => Map[y, x].SetItem(i);
    public Items RemoveItem(int x, int y) => Map[y, x].RemoveItem();

    public Items GetItem(int x, int y) => Map[x, y].item;

    public void SetPlayer(Player pl, int x, int y)
    {
        p = (Player)AddEntity(pl, x, y);
    }
    public Entity AddEntity(Entity e, int x, int y)
    {
        Map[y, x].SetEntity(e);
        e.MoveEntity(x, y);
        return e;
    }
    public bool RemoveEntity(int x, int y) => Map[y, x].RemoveEntity();

    public new_Tile GetTile(int x, int y) => Map[y, x];


    public bool CanMoveHere(int posX, int posY)
    {
        if (!ValidPositionX(posX) || !ValidPositionY(posY)) return false;
        //check si enemy
        //if (enemy.PosX == posX && enemy.PosY == posY) return false;

        //check si placement possible sur Tile
        TilesTypes tt = GetTile(posX, posY)._tt;
        //Debug.Log(tt);
        return tt switch
        {
            TilesTypes.Ground => true,
            TilesTypes.Wall => false,
            _ => false,
        };
        ;
    }

    private bool EntityHere(int x, int y) => GetTile(x, y).entite != null;
    private bool ValidPositionX(int posToCheck) => posToCheck >= 0 && posToCheck < MapLengthX;
    private bool ValidPositionY(int posToCheck) => posToCheck >= 0 && posToCheck < MapLengthY;

    public bool InBounds(int x, int y) => 
        x >= 0 && x < MapLengthX-1 && 
        y >= 0 && y < MapLengthY-1;
    
    public void MoveDown()
    {
        if (CanMoveHere(p.PosX, p.PosY - 1))
        {
            p.MoveDown();
            p.OnMovement(GetTile(p.PosX, p.PosY));
        }
    }
    public void MoveUp()
    {
        if (CanMoveHere(p.PosX, p.PosY + 1))
        {
            p.MoveUp(); 
            p.OnMovement(GetTile(p.PosX, p.PosY));
        }
    }
    public void MoveLeft()
    {
        if (CanMoveHere(p.PosX - 1, p.PosY))
        {
            p.MoveLeft();
            p.OnMovement(GetTile(p.PosX, p.PosY));
        }

    }
    public void MoveRight()
    {
        if (CanMoveHere(p.PosX + 1, p.PosY))
        {
            p.MoveRight(); 
            p.OnMovement(GetTile(p.PosX, p.PosY));
        }
    }

    public List<Items> GetInventory() => p.inventory;

}

public enum TilesTypes
{
    Wall,
    Ground,
}