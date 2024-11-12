using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeftIdle : PlayerIdleState
{
    public PlayerLeftIdle(Player _player, PlayerStateMashine _mashine, string _animBoolName) : base(_player, _mashine, _animBoolName)
    {
    }
     
    public override void Enter() 
    {
        base.Enter(); 
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }
}
