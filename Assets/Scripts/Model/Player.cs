using UnityEngine;
using System.Collections.Generic;

public class Player : Entity
{
    public List<Items> inventory { get; private set; } = new();

    public void AddItem(Items item)
    {
        inventory.Add(item);
    }
}
