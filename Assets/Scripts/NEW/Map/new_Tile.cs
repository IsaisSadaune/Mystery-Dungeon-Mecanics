/// <summary>
/// DOIT ETRE REMPLACEE
/// </summary>
public class new_Tile
{
    public new_Tile(TilesTypes tt)
    {
        _tt = tt;
        entite = null;
        item = null;
    }
    public TilesTypes _tt;
    public Entity entite { get; private set; }
    public Items item { get; private set; }

    public bool SetItem(Items _i)
    {
        if (item == null)
        {
            item = _i;
            return true;
        }
        return false;
    }
    public Entity SetEntity(Entity _e)
    {
        if (entite == null)
        {
            entite = _e;
            return entite;
        }
        return null;
    }

    public Items RemoveItem()
    {
        Items i = item;
        item = null;
        return i;
    }
    public bool RemoveEntity()
    {
        if(entite == null) return false;
        entite = null;
        return true;
    }
}
