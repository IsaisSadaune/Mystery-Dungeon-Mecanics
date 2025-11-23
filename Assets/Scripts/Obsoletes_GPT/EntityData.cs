public class EntityData
{
    public int Id { get; }
    public string Name { get; }
    public int Health { get; private set; }
    public int MaxHealth { get; }
    public int PosX { get; set; }
    public int PosY { get; set; }
    public Direction dir { get; set; }

    public EntityData(int _id, string _name, int _maxHealth, int _x, int _y, Direction _dir)
    {
        Id = _id;
        Name = _name;
        Health = _maxHealth;
        MaxHealth = _maxHealth;
        PosX = _x;
        PosY = _y;
        dir = _dir;
    }
    public bool ApplyDamage(int amount)
    {
        Health = Health - amount > 0 ? Health-amount : 0;
        return Health != 0;
    }
    public void Heal(int amount) => 
        Health = Health + amount > MaxHealth ? MaxHealth : Health + amount;
    public bool IsDead => Health <= 0;

    public void Move(int x, int y)
    {
        PosX = x;
        PosY = y;
    }
}
