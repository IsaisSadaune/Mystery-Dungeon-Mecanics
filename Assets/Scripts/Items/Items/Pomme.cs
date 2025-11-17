using UnityEngine;

public class Pomme : Items, IMangeable, IAttrapable
{
    public void OnEat(Entity e)
    {
        Debug.Log("miammm j'ai bien mangé !");
        e.AddHPs(5);
    }

    public void OnLancer(Entity e)
    {
        Debug.Log("miammm j'ai bien mangé en me prenant cette pommme dans la gueule !");
        e.AddHPs(5);
    }
}
