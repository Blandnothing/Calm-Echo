using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse  
{
    public Player player;

    public Camera cameraToUse = Camera.main;

    public Transform transf;

    public LookAtMouse(Player _player,Transform _transform)
    {
        this.player = _player;
        this.transf = _transform;
    }


    public Vector2 IdleControl()
    {
        // ��ȡ������Ļλ��
        Vector3 mouseScreenPosition = Input.mousePosition;

        // ������Ļ����λ��
        Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, mouseScreenPosition.z);

        Vector3 characterWorldPosition = transf.position;

        // �����������λ��ת��Ϊ��Ļλ��
        Vector3 characterScreenPosition = cameraToUse.WorldToScreenPoint(characterWorldPosition);

        // ��������ﵽ���λ�õ�����
        Vector2 directionToMouse = (mouseScreenPosition - characterScreenPosition).normalized;

        return directionToMouse;

    }
}
