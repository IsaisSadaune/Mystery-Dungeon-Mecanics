using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ModificatorsMap : MonoBehaviour
{
    [SerializeField] private Player prefabPlayer;
    [SerializeField] private Entity prefabEnemy;
    [SerializeField] private new_Map map;
    [SerializeField] private VisualMap visual;

    public Player p => map.p;

    private void Awake()
    {
        CreateMap(7, 20);
        Player p = visual.SetPlayer(prefabPlayer);
        p.MoveEntity(5, 5);
        map.SetPlayer(p, 5, 5);
        visual.UpdatePlayer(p);
        Game_Manager.Instance.SetPlayer(p);

        Entity e = visual.SetEnemy(prefabEnemy);
        map.AddEntity(e, 1, 1);
        e.MoveEntity(1, 1);
        visual.UpdateEntity(e);

    }

    public void CreateMap(int x, int y)
    {
        new_Tile[,] nt = map.CreateMap(x, y);
        visual.CreateMap(nt);
    }
    public bool AddItemToMap(Items i, int x, int y)
    {
        bool b = map.AddItemToTile(i, x, y);
        visual.UpdateItem(i, x, y);
        return b;
    }

    public Items RemoveItemAtPosition(int x, int y)
    {
        if(!map.InBounds(x, y)) return null;
        Items i = map.RemoveItem(x, y);
        visual.UpdateItem(map.GetItem(x,y), x, y);
        return i;
    }

    public void ThrowItem(int posX, int posY, Items i, Direction d)
    {
        if (!map.InBounds(posX, posY)) return;

        int _x = posX;
        int _y = posY;

        switch(d)
        {
            case Direction.North:
                while(map.GetTile(posX,posY)._tt != TilesTypes.Wall && map.InBounds(_x,_y))
                {
                    _y++;
                }
                break;
            case Direction.South:
                while (map.GetTile(posX, posY)._tt != TilesTypes.Wall && map.InBounds(_x, _y))
                {
                    _y--;
                }
                break;
            case Direction.East:
                while (map.GetTile(posX, posY)._tt != TilesTypes.Wall && map.InBounds(_x, _y))
                {
                    _x++;
                }
                break;
            case Direction.West:
                while (map.GetTile(posX, posY)._tt != TilesTypes.Wall && map.InBounds(_x, _y))
                {
                    _x--;
                }
                break;
        }

        //Calculer la position d'arrivée
        //Verifier si elle est valide
    }

    private new_Tile RandomItemLessTileAdjacent(new_Tile t)
    {
        return null;
    }

}
