using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
    public string ItemName;
    public string Description;
    public Sprite spriteUI;

    public virtual void OnThrow()
    {
        Debug.Log("fiouuuuuuuuuuu");
    }
    public virtual void OnPickup(Entity e)
    {
        Debug.Log("objet ramassé");
    }
    public virtual void OnDrop()
    {
        Debug.Log("objet drop");
    }
    public virtual void OnCatch(Entity e)
    {
        Debug.Log("objet pris dans la gueule");
    }
}
