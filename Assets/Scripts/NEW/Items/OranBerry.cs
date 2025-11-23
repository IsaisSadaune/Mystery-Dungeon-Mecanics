using UnityEngine;

public class OranBerry : Items, IEatable
{
    public void OnEat(Entity p)
    {
        p.GainHP();
        Debug.Log("miam miam j'ai bien mangé");
    }
    public override void OnCatch(Entity e)
    {
        Debug.Log("se l'est prise dans la gueule");
    }
    public override void OnThrow()
    {
        Debug.Log("fiouuuuuuuuuuu");
    }
}
