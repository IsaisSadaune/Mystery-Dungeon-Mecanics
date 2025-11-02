using UnityEngine;

public class Entity : MonoBehaviour
{
    //MODEL

    public (int, int) Pos { get; private set; }
    public Direction dir { get; private set; } = Direction.North;

    public bool isFlying { get; private set; } = false;

    public void GiveWings() => isFlying = true;
    public void MoveEntity(int x, int y) => Pos = (x, y);
    public void TurnEntity(Direction d) => dir = d;

    public (int, int) GetInFront()
    {
        return dir switch
        {
            Direction.North => (Pos.Item1, Pos.Item2 - 1),
            Direction.South => (Pos.Item1, Pos.Item2 + 1),
            Direction.East => (Pos.Item1 - 1, Pos.Item2),
            Direction.West => (Pos.Item1 + 1, Pos.Item2 - 1),
            _ => throw new System.Exception("Erreur direction invalide"),
        };
    }


    public enum Direction
    {
        North = 180,
        South = 0,
        West = 90,
        East = 270
    }
}
