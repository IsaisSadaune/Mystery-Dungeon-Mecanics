public class TileData
{
    public TilesTypes Type { get; }
    public ItemData Item { get; private set; }
    public EntityData Entity { get; private set; }

    public TileData(TilesTypes type)
    {
        Type = type;
        Item = null;
        Entity = null;
    }
    public bool HasItem => Item != null;
    public bool HasEntity => Entity != null;
    public bool IsWalkable => Type == TilesTypes.Ground && Entity == null;


    public bool TrySetItem(ItemData item)
    {
        if (Item != null) return false;
        Item = item;
        return true;
    }

    public bool TryRemoveItem()
    {
        if (Item == null) return false;
        Item = null;
        return true;
    }

    public bool TrySetEntity(EntityData e)
    {
        if (Entity != null) return false;
        Entity = e;
        return true;
    }

    public bool TryRemoveEntity()
    {
        if (Entity == null) return false;
        Entity = null;
        return true;
    }
}
