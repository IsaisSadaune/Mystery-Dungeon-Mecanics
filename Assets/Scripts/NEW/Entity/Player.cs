using UnityEngine;
using System.Collections.Generic;

public class Player : Entity
{
    public List<Items> inventory { get; private set; } = new();

    public void AddItem(Items item)
    {
        inventory.Add(item);
    }
    public void RemoveItem(int index)
    {
        inventory.RemoveAt(index);
    }

    public void OnMovement(new_Tile t)
    {
        if(t.item != null && inventory.Count < 16)
        {
            AddItem(t.item);
            t.RemoveItem();
        }
    }
}
