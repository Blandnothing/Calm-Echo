using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ThrowAndInteraction : MonoBehaviour
{
    [Header("User Info")]
    [SerializeField] private Player player;
    [SerializeField] private float m_ThrowForce;//投掷力量
    [SerializeField] private Vector2 m_ThrowDirection;//投掷方向
    [SerializeField] private bool m_IsHold;//是否拿着物体
    [SerializeField] private float PickupRange;//拾取范围


    void Update()
    {
        m_ThrowDirection = player.playerFaceDirection;

        if(ItemOnHand.Instance.CurrentHoldItem() != null)
            m_IsHold = true;

        Throw();

        interaction();
    }

    //投掷
    private void Throw()
    {
        if(Input.GetKeyDown(KeyCode.F) && m_IsHold && ItemOnHand.Instance.item.itemHeld > 0)
        {
            GameObject newItem = Instantiate(ItemOnHand.Instance.itemPrefab, transform.position, transform.rotation);

            newItem.GetComponent<Rigidbody2D>().velocity = m_ThrowDirection * m_ThrowForce;

            ItemOnHand.Instance.item.itemHeld--;
        }

    }
    //互动
    private void interaction()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsObjectsAround())
        {
            //调用场景中可互动的物体...不知道写什么,没场景
        }
    }
    //检测是否有可以互动的物体
    private bool IsObjectsAround()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position, PickupRange);

        return collider2Ds.Length > 0? true: false;
    }

    //画出检测范围
    private void OnDrawGizmos() => Gizmos.DrawWireSphere(transform.position, PickupRange);
}
