using UnityEngine;

public class Entity : MonoBehaviour
{
    //MODEL
    [field:SerializeField] public int MaxLife { get; private set; } = 10;
    [field:SerializeField] public int Life { get; private set; } = 10;

    public void LoseHP() => Life = Mathf.Clamp(Life-1, 0, MaxLife);
    public void GainHP() => Life = Mathf.Clamp(Life+1, 0, MaxLife);


    public int PosX { get; private set; } = 0;
    public int PosY { get; private set; } = 0;

    public Direction dir { get; private set; } = Direction.North;

    public void MoveEntity(int x, int y)
    {
        PosX = x;
        PosY = y;
    }
    public void TurnEntity(Direction d) => dir = d;

    /// <summary>
    /// Renvoie les coordonnée de la case devant celle du joueur
    /// </summary>
    /// <returns></returns>
    /// <exception cref="System.Exception"></exception>
    public (int, int) GetInFront()
    {
        return dir switch
        {
            Direction.North => (PosY - 1, PosX),
            Direction.South => (PosY + 1, PosX),
            Direction.East => (PosY , PosX + 1),
            Direction.West => (PosY , PosX - 1),
            _ => throw new System.Exception("Erreur direction invalide"),
        };
    }


    public void MoveDown()
    {
        MovePlayer(PosX, PosY - 1, Direction.South);
    }
    public void MoveUp()
    {
        MovePlayer(PosX, PosY + 1, Direction.North);
    }
    public void MoveLeft()
    {
        MovePlayer(PosX - 1, PosY, Direction.West);
    }
    public void MoveRight()
    {
        MovePlayer(PosX + 1, PosY, Direction.East);
    }

    /// <summary>
    /// Déplace le joueur vers une position 
    /// </summary>
    /// <param name="posX"></param>
    /// <param name="posY"></param>
    /// <param name="dir"></param>
    public void MovePlayer(int posX, int posY, Direction dir = Direction.North)
    {
        MoveEntity(posX, posY);
        TurnEntity(dir);
    }
}
public enum Direction
{
    North,
    South,
    West,
    East
}
