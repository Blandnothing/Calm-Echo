using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : PlayerState
{
    public PlayerMove(Player _player, PlayerStateMashine _mashine, string _animBoolName) : base(_player, _mashine, _animBoolName)
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

        m_player.SetPlayerSpeed(m_xInput, m_yInput);

        if (m_xInput == 0 && m_yInput == 0)
            m_player.mashine.ChangeState(m_player.idle);
    }
}
