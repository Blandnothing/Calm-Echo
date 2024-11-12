using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player;

    [Header("CameraMove Info")]
    [SerializeField] public float cameraMoveSpeed = 0.3f;//镜头移动速度
    [SerializeField] private Vector3 mousePosition; // 上一次鼠标位置，用于计算鼠标移动
    [SerializeField] private Vector3 mouseCurrentPosition;//当前位置
    [SerializeField] protected Vector3 mouseMovePosition;//鼠标偏移位置


    void Start()
    {
        player = GetComponentInParent<Transform>();

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

            //拖动摄像头
            transform.position += mouseMovePosition * cameraMoveSpeed * Time.deltaTime;

            mousePosition = mouseCurrentPosition;
        }
    }

}
