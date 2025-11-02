using UnityEngine;

public class Items : MonoBehaviour
{
    [field: SerializeField] public GameObject model { get; private set; }

    //Au mangeage de l'objet
    public virtual void OnEat()
    {

    }

    //Au ramassage de l'objet apres lancement
    public virtual void OnCatch()
    {

    }
    //Au ramassage de l'objet
    public virtual void OnPickup()
    {

    }


    //Ce qu'il se passe quand on lance l'objet
    public virtual void OnThrow()
    {

    }
}
