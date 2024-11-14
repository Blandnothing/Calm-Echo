using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMove : MonoBehaviour
{
    public Transform player;
    public Camera cameraToUse;

    [Header("CameraMove Info")]
    [SerializeField] public float cameraMoveSpeed = 0.3f;//��ͷ�ƶ��ٶ�
    [SerializeField] private Vector3 mousePosition; // ��һ�����λ�ã����ڼ�������ƶ�
    [SerializeField] private Vector3 mouseCurrentPosition;//��ǰλ��
    [SerializeField] protected Vector3 mouseMovePosition;//���ƫ��λ��
    [SerializeField] private float maxDistance;//�����Ļƫ�ƾ���
    [SerializeField] private float distance;//���������ͷ����Ļ�����


    void Start()
    {
        cameraToUse = Camera.main;

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

            // ��ȡ����ͷ����Ļλ��
            Vector3 cameraScreenPosition = cameraToUse.WorldToScreenPoint(transform.position);

            //��ȡ�������Ļλ�� 
            Vector3 characterScreenPosition = cameraToUse.WorldToScreenPoint(player.position);

            // ��������ﵽ����ͷλ�õ�����
            Vector2 directionToMouse = cameraScreenPosition - characterScreenPosition;

            //����ת����float
            distance = directionToMouse.magnitude;

            //�϶�����ͷ
            if(distance<=maxDistance)
                transform.position += mouseMovePosition * cameraMoveSpeed * Time.deltaTime;  
            else
                transform.position=new Vector3(player.position.x,player.position.y,player.position.z-10);

            mousePosition = mouseCurrentPosition;
        }


    }

}
