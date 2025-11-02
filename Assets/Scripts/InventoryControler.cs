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
    private VisualMap vm => c.vm;

    //Ramasser Item en dessous de lui
    public void GrabItemBelow()
    {
        Items i = ItemBelowPlayer();
        if (i != null)
        {
            player.AddItem(i);
            vm.DeleteItem(posPlayerX, posPlayerY);
            i.OnPickup();
        }
    }

    public void EatItemBelow()
    {
        Items i = ItemBelowPlayer();
        if (i != null)
        {
            vm.DeleteItem(posPlayerX, posPlayerY);
            i.OnEat();
        }
    }



    private Items ItemBelowPlayer() => itemMap[posPlayerX, posPlayerY];

    //Lacher Item la ou il est
    //Lancer Item devant lui


}
