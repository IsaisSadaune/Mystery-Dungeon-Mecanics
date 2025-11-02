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

    /// <summary>
    /// Renvoie la position devant celle du joueur
    /// </summary>
    /// <returns></returns>
    /// <exception cref="System.Exception"></exception>
    public (int, int) GetInFront()
    {
        return dir switch
        {
            Direction.North => (Pos.Item1 - 1, Pos.Item2),
            Direction.South => (Pos.Item1 + 1, Pos.Item2),
            Direction.East => (Pos.Item1 , Pos.Item2 + 1),
            Direction.West => (Pos.Item1 , Pos.Item2 - 1),
            _ => throw new System.Exception("Erreur direction invalide"),
        };
    }


    public enum Direction
    {
        North = 0,
        South = 180,
        West = 270,
        East = 90
    }
}
