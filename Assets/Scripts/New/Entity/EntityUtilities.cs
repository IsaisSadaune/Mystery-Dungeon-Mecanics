using UnityEngine;

public static class EntityUtilities
{
    public static int GetDistanceBetweenTwoEntities(Entity a, Entity b)
    {
        return Mathf.Abs(a.PosX - b.PosX) + Mathf.Abs(a.PosX - b.PosY);
    }
    public static int GetXBetween2Entities(Entity a, Entity b) => Mathf.Abs(a.PosX - b.PosX);
    public static int GetYBetween2Entities(Entity a, Entity b) => Mathf.Abs(a.PosY - b.PosY);

    public static Movement PositionToGoCloser(Entity from, Entity to)
    {
        if(Mathf.Abs(from.PosX - to.PosX) > Mathf.Abs(from.PosY - to.PosY))
        {
            if (from.PosX < to.PosX) 
                return Movement.Right;
            return Movement.Left;
        }
        if (from.PosY < to.PosY)
            return Movement.Up;
        return Movement.Down;
    }

}
