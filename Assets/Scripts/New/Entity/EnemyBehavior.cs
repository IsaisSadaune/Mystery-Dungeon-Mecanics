using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private Entity infoEntity;
    private int agroDistance = 5;

    private void Awake()
    {
        Game_Manager.Instance.OnEndTurn += ChooseAction;
    }
    private void ChooseAction()
    {
        if (!CanSeePlayer()) Debug.Log("Se déplace au hasard");
        else if (!CanATKPlayer())
            switch(EntityUtilities.PositionToGoCloser(infoEntity, Game_Manager.Instance.player))
            {
                case Movement.Left:
                    infoEntity.MoveLeft();
                    break;
                case Movement.Right:
                    infoEntity.MoveRight();
                    break;
                case Movement.Up:
                    infoEntity.MoveUp();
                    break;
                case Movement.Down:
                    infoEntity.MoveDown();
                    break;
            }

        else Debug.Log("attaque");

        //Si l'ennemi est au cac d'un joueur, il l'attaque
        //Si l'ennemi voit un joueur, il va vers lui
        //Sinon, direction random
        Game_Manager.Instance.UpdateEntity(infoEntity);
    }
    private bool CanATKPlayer() => EntityUtilities.GetDistanceBetweenTwoEntities(Game_Manager.Instance.player,infoEntity) == 1;
    private bool CanSeePlayer() => 
        EntityUtilities.GetXBetween2Entities(Game_Manager.Instance.player, infoEntity) <= agroDistance && 
        EntityUtilities.GetYBetween2Entities(Game_Manager.Instance.player, infoEntity) <= agroDistance;
}
public enum Movement
{
    Left,
    Right,
    Up,
    Down,
}