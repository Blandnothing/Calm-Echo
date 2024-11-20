using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Player m_player;
    protected PlayerStateMashine m_mashine;
    private string m_animBoolName;

    protected float m_xInput; 
    protected float m_yInput;

    public PlayerState(Player _player, PlayerStateMashine _mashine, string _animBoolName)
    {
        this.m_player = _player;
        this.m_mashine = _mashine;
        this.m_animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        m_player.anim.SetBool(m_animBoolName, true);
    }

    public virtual void Update()
    {
        m_xInput = Input.GetAxisRaw("Horizontal");
        m_yInput = Input.GetAxisRaw("Vertical");

        m_player.anim.SetFloat("XInput", m_player.rb.velocity.x);
        m_player.anim.SetFloat("YInput", m_player.rb.velocity.y);
    }
    public virtual void Exit()
    {
        m_player.anim.SetBool(m_animBoolName, false);
    }
}
