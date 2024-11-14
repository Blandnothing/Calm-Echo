using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Ŀ�����壬������ͷҪ����Ķ���
    public Transform target;

    // ����ͷ��Ŀ������֮���ƫ����
    public Vector3 offset = new Vector3(0, 0, -10);

    // ����ͷ�ƶ���ƽ����
    public float smoothSpeed = 0.5f;

    // ����ͷ��ǰ��λ��
    private Vector3 currentCameraPosition;

    // ����ͷĿ���λ��
    private Vector3 cameraTargetPosition;

    // ƽ���ƶ����ٶȱ�������Ҫ�����������ڶ����Ա���SmoothDamp��ʹ�ã�
    private Vector3 velocity = Vector3.zero;

    private CameraMove cameraMove;

    void Start()
    {
        // ��ʼ������ͷ��ǰλ��ΪĿ��λ�ü���ƫ����
        currentCameraPosition = transform.position;
        cameraTargetPosition = target.position + offset;

        cameraMove = GetComponent<CameraMove>();
    }

    void LateUpdate()
    {
        // ÿ֡����Ŀ��λ��
        cameraTargetPosition = target.position + offset;

        // ƽ���ƶ���Ŀ��λ��
        currentCameraPosition = Vector3.SmoothDamp(currentCameraPosition, cameraTargetPosition + cameraMove.CameraOffset(), ref velocity, smoothSpeed);

        // ��������ͷλ��
        transform.position = currentCameraPosition;
    }

}