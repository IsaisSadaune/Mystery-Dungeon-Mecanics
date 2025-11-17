using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class InventoryControler : MonoBehaviour
{
    [SerializeField] private Controler c;
    private int posPlayerX => c.m.player.Pos.Item1;
    private int posPlayerY => c.m.player.Pos.Item2;
    private Player player => c.m.player;
    private Items[,] itemMap => c.m.tileMap.ItemsMap;
    private Tiles tileMap => c.m.tileMap;
    private VisualMap vm => c.vm;

    /// <summary>
    /// Ramasse l'objet devant le joueur.
    /// Le joueur est supposé le ramasser quand il passe dessus (désactivé atm)
    /// </summary>
    public void PickupItemBelow()
    {
        Items i = ItemBelowPlayer();
        if (i != null)
        {
            player.AddItem(i);
            RemoveItem(posPlayerX, posPlayerY);
            //i.OnPickup();
            Debug.Log("grab");
        }
    }

    /// <summary>
    /// Mange l'objet sous le joueur
    /// </summary>
    public void EatItemBelow()
    {
        Items i = ItemBelowPlayer();
        if (i is IMangeable m)
        {
            RemoveItem(posPlayerX, posPlayerY);
            m.OnEat(player);
        }
    }

    /// <summary>
    /// Lance l'objet situé sous le joueur
    /// </summary>
    public void ThrowItemBelow()
    {
        Items i = ItemBelowPlayer();
        Debug.Log(i);
        if (i != null)
        {
            RemoveItem(posPlayerX, posPlayerY);
            (int _x,int _y) = GetLastTilePosBeforeWall(posPlayerX, posPlayerY, player.dir);
            //i.OnThrow();
            //Debug.Log("throw "+ _x + ", "+_y );
            AddItem(i, _x, _y);
            c.pm.ApplyVisuals();

            
        }
    }

    /// <summary>
    /// Obtient la position de la derniere tuile devant le joueur qui ne soit pas un mur
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="dir"></param>
    /// <returns></returns>
    public (int, int) GetLastTilePosBeforeWall(int x, int y, Player.Direction dir)
    {
        int _x = x;
        int _y = y;
        TilesTypes tt = c.m.tileMap.GetTT(_x, _y);
        while (tt != TilesTypes.Wall)
        {
            switch (dir)
            {
                case Player.Direction.North:
                    _x = _x - 1;
                    break;
                case Player.Direction.South:
                    _x = _x + 1;
                    break;
                case Player.Direction.East:
                    _y = _y + 1;
                    break;
                case Player.Direction.West:
                    _y = _y - 1;
                    break;
                default:
                    break;
            }
            tt = c.m.tileMap.GetTT(_x, _y);
        }
        switch (dir)
        {
            case Player.Direction.North:
                _x = _x + 1;
                break;
            case Player.Direction.South:
                _x = _x - 1;
                break;
            case Player.Direction.East:
                _y = _y - 1;
                break;
            case Player.Direction.West:
                _y = _y + 1;
                break;
            default:
                break;
        }
        return (_x, _y);
    }


    private void RemoveItem(int x, int y)
    {
        tileMap.RemoveItemAt(posPlayerX, posPlayerY);
        vm.DeleteItem(posPlayerX, posPlayerY);
    }

    public void AddItem(Items i, int x, int y)
    {
        tileMap.AddItemAt(i, x, y);
        vm.AddItem(i.gameObject, x, y);
    }
    private Items ItemBelowPlayer() => itemMap[posPlayerX, posPlayerY];



}
