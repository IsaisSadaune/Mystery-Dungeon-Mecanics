using UnityEngine;

public class Model : MonoBehaviour
{
    //MODEL

    [field: SerializeField] public Player player { get; private set; }
    [field: SerializeField] public Entity enemy { get; private set; }
    [field: SerializeField] public Tiles tileMap { get; private set; }
}
