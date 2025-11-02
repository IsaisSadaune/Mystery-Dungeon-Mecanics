using UnityEngine;

public class Controler : MonoBehaviour
{
    [field: SerializeField] public Model m { get; private set; }
    [field: SerializeField] public VisualMap vm { get; private set; }
    [field: SerializeField] public InventoryControler ic { get; private set; }
    [field: SerializeField] public PlayerMovement pm { get; private set; }
    private void Awake()
    {
        m.player.MoveEntity(2, 2);
        m.enemy.MoveEntity(1, 1);
        m.tileMap.AddItemAt(m.tileMap.oranBerry, 3, 3);

        vm.CreateMap(m.tileMap.Map);
        vm.CreateItemMap(m.tileMap.ItemsMap);
        vm.SetPlayer(m.player.Pos.Item1, m.player.Pos.Item2);
        vm.SetEnemy(m.enemy.Pos.Item1, m.enemy.Pos.Item2);
    }
}
