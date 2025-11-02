using UnityEngine;

public class OranBerry : Items
{
    public override void OnEat()
    {
        Debug.Log("miam miam j'ai bien mangé");
    }
    public override void OnCatch()
    {
        Debug.Log("attrapé");
    }
    public override void OnThrow()
    {
        Debug.Log("fiouuuuuuuuuuu");
    }
    public override void OnPickup()
    {
        Debug.Log("objet ramassé");
    }
}
