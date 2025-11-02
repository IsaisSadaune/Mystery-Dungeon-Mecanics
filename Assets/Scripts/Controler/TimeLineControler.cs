using System;
using System.Collections.Generic;
using UnityEngine;

public class TimeLineControler : MonoBehaviour
{
    public List<Action> actions { get; private set; } = new();

    public void EndTurn()
    {
        foreach (var action in actions)
        {
            action.Invoke();
        }
        actions.Clear();
    }

    public void AddAction(Action action) => actions.Add(action);

}
