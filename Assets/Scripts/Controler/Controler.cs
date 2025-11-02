using UnityEngine;

public class Controler : MonoBehaviour
{
    [field: SerializeField] public Model m { get; private set; }
    [field: SerializeField] public VisualMap vm { get; private set; }
    [field: SerializeField] public InventoryControler ic { get; private set; }
    [field: SerializeField] public PlayerMovement pm { get; private set; }
}
