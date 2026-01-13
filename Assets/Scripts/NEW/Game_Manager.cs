using System;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager Instance { get; private set; }
    public Player player { get; private set; }
    public bool isPlayerMoving { get; private set; }

    public event Action OnEndTurn;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    public void SetPlayer(Player p) => player = player == null ? player = p : player = player;
    public bool CanApplyMovement()
    {
        if (!isPlayerMoving)
        {
            isPlayerMoving = true;
            return true;
        }
        return false;
    }

    public void EndMovement() => isPlayerMoving = false;


    [ContextMenu("Fin de tour")]
    public void EndTurn()
    {
        Debug.Log("Fin du tour");
        OnEndTurn?.Invoke();
    }
}
