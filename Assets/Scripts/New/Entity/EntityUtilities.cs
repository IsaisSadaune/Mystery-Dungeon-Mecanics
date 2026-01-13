using UnityEngine;

public static class EntityUtilities
{
    public static int GetDistanceBetweenTwoEntities(Entity a, Entity b)
    {
        return Mathf.Abs(a.PosX - b.PosX) + Mathf.Abs(a.PosX - b.PosY);
    }
}
