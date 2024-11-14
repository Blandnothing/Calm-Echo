using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // 目标物体，即摄像头要跟随的对象
    public Transform target;

    // 摄像头与目标物体之间的偏移量
    public Vector3 offset = new Vector3(0, 0, -10);

    // 摄像头移动的平滑度
    public float smoothSpeed = 0.5f;

    // 摄像头当前的位置
    private Vector3 currentCameraPosition;

    // 摄像头目标的位置
    private Vector3 cameraTargetPosition;

    // 平滑移动的速度变量（需要在类作用域内定义以便在SmoothDamp中使用）
    private Vector3 velocity = Vector3.zero;

    private CameraMove cameraMove;

    void Start()
    {
        // 初始化摄像头当前位置为目标位置加上偏移量
        currentCameraPosition = transform.position;
        cameraTargetPosition = target.position + offset;

        cameraMove = GetComponent<CameraMove>();
    }

    void LateUpdate()
    {
        // 每帧更新目标位置
        cameraTargetPosition = target.position + offset;

        // 平滑移动到目标位置
        currentCameraPosition = Vector3.SmoothDamp(currentCameraPosition, cameraTargetPosition + cameraMove.CameraOffset(), ref velocity, smoothSpeed);

        // 更新摄像头位置
        transform.position = currentCameraPosition;
    }

}