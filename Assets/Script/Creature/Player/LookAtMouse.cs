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
        // 获取鼠标的屏幕位置
        Vector3 mouseScreenPosition = Input.mousePosition;

        // 计算屏幕中心位置
        Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, mouseScreenPosition.z);

        Vector3 characterWorldPosition = transf.position;

        // 将人物的世界位置转换为屏幕位置
        Vector3 characterScreenPosition = cameraToUse.WorldToScreenPoint(characterWorldPosition);

        // 计算从人物到鼠标位置的向量
        Vector2 directionToMouse = (mouseScreenPosition - characterScreenPosition).normalized;

        return directionToMouse;

    }
}
