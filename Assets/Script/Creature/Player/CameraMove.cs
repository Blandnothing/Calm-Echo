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
    [SerializeField] public float cameraMoveSpeed = 0.3f;//镜头移动速度
    [SerializeField] private Vector3 mousePosition; // 上一次鼠标位置，用于计算鼠标移动
    [SerializeField] private Vector3 mouseCurrentPosition;//当前位置
    [SerializeField] protected Vector3 mouseMovePosition;//鼠标偏移位置
    [SerializeField] private float maxDistance;//最大屏幕偏移距离
    [SerializeField] private float distance;//人物和摄像头的屏幕距离差


    void Start()
    {
        cameraToUse = Camera.main;

        //获取鼠标初始位置
        mousePosition = Input.mousePosition;
    }


    void Update()
    {
        CameraMoveControl();

    }

    ///镜头移动
    private void CameraMoveControl()
    {
        if (Input.mousePosition != mousePosition)
        {
            mouseCurrentPosition = Input.mousePosition;

            //鼠标偏移
            mouseMovePosition = mouseCurrentPosition - mousePosition;

            // 获取摄像头的屏幕位置
            Vector3 cameraScreenPosition = cameraToUse.WorldToScreenPoint(transform.position);

            //获取人物的屏幕位置 
            Vector3 characterScreenPosition = cameraToUse.WorldToScreenPoint(player.position);

            // 计算从人物到摄像头位置的向量
            Vector2 directionToMouse = cameraScreenPosition - characterScreenPosition;

            //向量转换成float
            distance = directionToMouse.magnitude;

            //拖动摄像头
            if(distance<=maxDistance)
                transform.position += mouseMovePosition * cameraMoveSpeed * Time.deltaTime;  
            else
                transform.position=new Vector3(player.position.x,player.position.y,player.position.z-10);

            mousePosition = mouseCurrentPosition;
        }


    }

}
