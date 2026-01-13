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
        else if (!CanATKPlayer()) Debug.Log("va vers le joueur");
        else Debug.Log("attaque");

        //Si l'ennemi est au cac d'un joueur, il l'attaque
        //Si l'ennemi voit un joueur, il va vers lui
        //Sinon, direction random
    }
    private bool CanATKPlayer() => EntityUtilities.GetDistanceBetweenTwoEntities(Game_Manager.Instance.player,infoEntity) == 1;
    private bool CanSeePlayer() => EntityUtilities.GetDistanceBetweenTwoEntities(Game_Manager.Instance.player, infoEntity) <= agroDistance;
}