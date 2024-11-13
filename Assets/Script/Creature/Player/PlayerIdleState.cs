using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player _player, PlayerStateMashine _mashine, string _animBoolName) : base(_player, _mashine, _animBoolName)
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

        PlayerMoveControl();
    }
     
    private void PlayerMoveControl()
    {
        if (m_xInput > 0)
            m_player.mashine.ChangeState(m_player.rightMove); 
        else if (m_xInput < 0)
            m_player.mashine.ChangeState(m_player.leftMove);
        else if (m_yInput > 0)
            m_player.mashine.ChangeState(m_player.backMove);
        else if (m_yInput < 0)
            m_player.mashine.ChangeState(m_player.frontMove);
    }

}
