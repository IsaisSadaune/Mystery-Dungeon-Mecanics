using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //CONTROLLER
    [SerializeField] private Controler c;

    //MODEL
    private Model model => c.m;
    private Entity player => c.m.player;
    private Entity enemy => c.m.enemy;
    private int playerPosX => c.m.player.Pos.Item1;
    private int playerPosY => c.m.player.Pos.Item2;
    private TilesTypes[,] map => c.m.tileMap.Map;
    //VIEW
    private VisualMap vm => c.vm;

    private void Awake()
    {
        player.MoveEntity(2, 2);
        enemy.MoveEntity(1, 1);
        model.tileMap.AddItemAt(model.tileMap.oranBerry, 3,3);

        vm.CreateMap(map);
        vm.CreateItemMap(model.tileMap.ItemsMap);
        vm.SetPlayer(playerPosX, playerPosY);
        vm.SetEnemy(enemy.Pos.Item1, enemy.Pos.Item2);
    }


    [ContextMenu("GoRight")]
    public void MoveRight()
    {
        int posToCheck = playerPosX + 1;
        MovePlayer(posToCheck, playerPosY, Entity.Direction.West);
    }

    [ContextMenu("GoLeft")]
    public void MoveLeft()
    {
        int posToCheck = playerPosX - 1;
        MovePlayer(posToCheck, playerPosY, Entity.Direction.East);
    }
    [ContextMenu("GoUp")]
    public void MoveUp()
    {
        int posToCheck = playerPosY + 1;
        MovePlayer(playerPosX, posToCheck, Entity.Direction.South);
    }


    [ContextMenu("GoDown")]
    public void MoveDown()
    {
        int posToCheck = playerPosY - 1;
        MovePlayer(playerPosX, posToCheck, Entity.Direction.North);
    }

    [ContextMenu("Attack")]
    public void Attack()
    {
        //visu anim
        (int, int) front = player.GetInFront();
        if (front.Item1 == enemy.Pos.Item1 && 
            front.Item2 == enemy.Pos.Item2)
        {
            Debug.Log("ennemy touché");
        }
        Debug.Log("FIN DE TOUR");
    }
    [ContextMenu("TurnLeft")]
    public void TurnLeft()
    {
        player.TurnEntity(Entity.Direction.East);
        ApplyVisuals();
    }
    [ContextMenu("TurnRight")]
    public void TurnRight()
    {
        player.TurnEntity(Entity.Direction.West);
        ApplyVisuals();
    }
    [ContextMenu("TurnUp")]
    public void TurnUp()
    {
        player.TurnEntity(Entity.Direction.South);
        ApplyVisuals();
    }
    [ContextMenu("TurnDown")]
    public void TurnDown()
    {
        player.TurnEntity(Entity.Direction.North);
        ApplyVisuals();
    }


    private void MovePlayer(int posX, int posY, Entity.Direction dir)
    {
        if (ValidPositionY(posY) && ValidPositionX(posX))
        {
            if (CanMoveHere(posX, posY))
            {
                model.player.MoveEntity(posX, posY);
            }
            model.player.TurnEntity(dir);
        }
        c.ic.GrabItemBelow();
        ApplyVisuals();
        Debug.Log("FIN DE TOUR");
        
    }

    [ContextMenu("FlyPlayer")]
    public void MakePlayerFly()
    {
        player.GiveWings();
        vm.AddWings();
    }

    private void ApplyVisuals()
    {
        Debug.Log(playerPosX + " | " + playerPosY);
        vm.UpdatePlayer(playerPosX, playerPosY, (int)player.dir);
    }

    private bool ValidPositionX(int posToCheck) => posToCheck >= 0 && posToCheck < map.GetLength(0);
    private bool ValidPositionY(int posToCheck) => posToCheck >= 0 && posToCheck < map.GetLength(1);

    private bool CanMoveHere(int posX,int posY)
    {
        //check si enemy
        if (enemy.Pos.Item1 == posX && enemy.Pos.Item2 == posY) return false;

        //check si placement possible sur Tile
        TilesTypes tt = map[posX, posY];
        return tt switch
        {
            TilesTypes.Ground => true,
            TilesTypes.Water => player.isFlying,
            TilesTypes.Wall => false,
            _ => false,
        };
        ;
    }

}
