using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAndInteraction : MonoBehaviour
{
    [Header("User Info")]
    [SerializeField] private Player player;
    [SerializeField] private float m_ThrowForce;//Ͷ������
    [SerializeField] private Vector2 m_ThrowDirection;//Ͷ������
    [SerializeField] private bool m_IsHold;//�Ƿ���������

    void Start()
    {
       
    }


    void Update()
    {
        m_ThrowDirection = player.playerFaceDirection;

        Throw ();
        interaction();
    }

    private void Throw()
    {
       // if(Input.GetKeyDown(KeyCode.F) && m_IsHold )

    }

    private void interaction()
    {
        //if(Input.GetKeyDown(KeyCode.E))
    }
}
