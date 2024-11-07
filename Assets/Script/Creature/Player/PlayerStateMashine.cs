using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMashine
{
    public PlayerState currentState { get; private set; }

    public void Initialized(PlayerState _startState)
    {
        currentState = _startState;
        currentState.Enter();
    }

    public void ChangeState(PlayerState _newState)
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }
}
