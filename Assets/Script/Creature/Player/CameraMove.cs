using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player;

    [Header("CameraMove Info")]
    [SerializeField] public float cameraMoveSpeed = 0.3f;//��ͷ�ƶ��ٶ�
    [SerializeField] private Vector3 mousePosition; // ��һ�����λ�ã����ڼ�������ƶ�
    [SerializeField] private Vector3 mouseCurrentPosition;//��ǰλ��
    [SerializeField] protected Vector3 mouseMovePosition;//���ƫ��λ��


    void Start()
    {
        player = GetComponentInParent<Transform>();

        //��ȡ����ʼλ��
        mousePosition = Input.mousePosition;
    } 
     
        
    void Update()
    {
        CameraMoveControl();

    }
     
    ///��ͷ�ƶ�
    private void CameraMoveControl()
    {
        if (Input.mousePosition != mousePosition)
        {
            mouseCurrentPosition = Input.mousePosition;

            //���ƫ��
            mouseMovePosition = mouseCurrentPosition - mousePosition;

            //�϶�����ͷ
            transform.position += mouseMovePosition * cameraMoveSpeed * Time.deltaTime;

            mousePosition = mouseCurrentPosition;
        }
    }

}
