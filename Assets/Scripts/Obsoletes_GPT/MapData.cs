public class MapData
{
    int width;
    int height;

    TileData[,] tiles;
    private bool IsInside(int x, int y) => width > x && height > y && x >= 0 && y >= 0;
    public TileData GetTile(int x, int y)
    { 
        if (IsInside(x, y)) 
            return tiles[x, y];
        return null;
    }
    private bool IsWalkable(int x, int y) => IsInside(x,y) && tiles[x, y].IsWalkable;
    public bool HasEntity(int x, int y) => IsInside(x,y) && tiles[x, y].Entity != null;
    public bool HasItem(int x, int y) => IsInside(x,y) && tiles[x, y].Item != null;

    public bool AddEntity(EntityData e, int x, int y) => IsInside(x, y) && tiles[x, y].TrySetEntity(e);

    public bool MoveEntity(EntityData e, int oldX, int oldY, int newX, int newY)
    {
        if (!IsInside(newX, newY)) return false;
        if (!IsWalkable(newX, newY)) return false;
        if (!IsInside(oldX, oldY)) return false;

        if (!tiles[oldX, oldY].TryRemoveEntity())
            return false;

        return tiles[newX, newY].TrySetEntity(e);
    }

    public bool RemoveEntity(int x, int y) => tiles[x, y].TryRemoveEntity();

    public bool CanMove(EntityData e, int x, int y) => !HasEntity(x, y) && IsWalkable(x, y) && IsInside(x, y);

}

