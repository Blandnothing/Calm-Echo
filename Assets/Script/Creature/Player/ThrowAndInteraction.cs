using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ThrowAndInteraction : MonoBehaviour
{
    [Header("User Info")]
    [SerializeField] private Player player;
    [SerializeField] private float m_ThrowForce;//Ͷ������
    [SerializeField] private Vector2 m_ThrowDirection;//Ͷ������
    [SerializeField] private bool m_IsHold;//�Ƿ���������
    [SerializeField] private float PickupRange;//ʰȡ��Χ


    void Update()
    {
        m_ThrowDirection = player.playerFaceDirection;

        if(ItemOnHand.Instance.CurrentHoldItem() != null)
            m_IsHold = true;

        Throw();

        interaction();
    }

    //Ͷ��
    private void Throw()
    {
        if(Input.GetKeyDown(KeyCode.F) && m_IsHold && ItemOnHand.Instance.item.itemHeld > 0)
        {
            GameObject newItem = Instantiate(ItemOnHand.Instance.itemPrefab, transform.position, transform.rotation);

            newItem.GetComponent<Rigidbody2D>().velocity = m_ThrowDirection * m_ThrowForce;

            ItemOnHand.Instance.item.itemHeld--;
        }

    }
    //����
    private void interaction()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsObjectsAround())
        {
            //���ó����пɻ���������...��֪��дʲô,û����
        }
    }
    //����Ƿ��п��Ի���������
    private bool IsObjectsAround()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position, PickupRange);

        return collider2Ds.Length > 0? true: false;
    }

    //������ⷶΧ
    private void OnDrawGizmos() => Gizmos.DrawWireSphere(transform.position, PickupRange);
}
