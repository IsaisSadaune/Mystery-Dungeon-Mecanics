
using System.Collections.Generic;

public sealed class InventoryData
{
    private readonly List<ItemData> items = new();
    public IReadOnlyList<ItemData> Items => items;

    public bool AddItem(ItemData item)
    {
        if (items.Count >= 16) return false; // limite d’inventaire
        items.Add(item);
        return true;
    }

    public bool RemoveItem(ItemData item) => items.Remove(item);
}
