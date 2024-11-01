using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creature : MonoBehaviour
{
    //生命值
    public float maxHealth;
    protected float m_currentHealth;
    //移速
    protected float m_speed;
    //攻击力
    protected float m_ATK;  
}
