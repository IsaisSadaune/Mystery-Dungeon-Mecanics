public sealed class PlayerData : EntityData
{
    public InventoryData Inventory { get; }

    public PlayerData(int _id, string _name, int _maxHealth, int _startX, int _startY)
        : base(_id, _name, _maxHealth, _startX, _startY, Direction.North)
    {
        Inventory = new InventoryData();
    }
}
