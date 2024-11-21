using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using NBehaviorTree;
using Unity.VisualScripting;
using UnityEngine;

public class TestMonster :Monster
{
    
    public Rigidbody2D rb;
    public Transform playerTransform;
    public List<Vector2> PatrolPath;
    public Vector2 excitePos;
    public Vector2 ExcitePos
    {
        get
        {
            return excitePos;
        }
        set
        {
            if (excitePos != value)
            {
                isToPos = false;
            }
            excitePos = value;
        }
    }
    public Vector2 GetExcitePos()
    {
        return excitePos;
    }
    public int exciteLevel = 0;
    public bool isToPos = false;
    public void SetIsToPos()
    {
        isToPos = true;
    }
    public int maxexciteLevel=4;
    public Dictionary<int,int> levelToRadius=new()
    {
        {1,3},{2,4},{3,5},{4,6}
    };
    public float GetExciteRadius()
    {
        return levelToRadius[exciteLevel];
    }
    public bool isExcite;
    public float exciteTime=6f;
    public float currentExciteTime = 0f;

    public void InitializeExcite()
    {
        currentExciteTime = 0;
        isExcite = false;
        isToPos = false;
    }
    protected override void BuildTree()
    {
        bhTreeBulider
            .PrioritySelector()
            .Conditioner(() =>
            {
                float limitedDistance = 5f;
                var playerPosition = playerTransform.position;
                var monsterPosition = transform.position;
                var distance = Vector3.Distance(playerPosition,monsterPosition);
                if (distance < limitedDistance)
                {
                    InitializeExcite();
                }
                return distance < limitedDistance;
            })
            .Task(new Chase(transform,playerTransform,moveOnPath,FindPath,speed*2))
            .Back()
            .Conditioner(() =>
            {
                if (isExcite&&isToPos)
                {
                    currentExciteTime += Time.deltaTime;
                }
                else
                {
                    currentExciteTime = 0f;
                }
                if (currentExciteTime - exciteTime >= 0f)
                {
                   InitializeExcite();
                }
                
                return isExcite&&isToPos;
            })
            .Task(new ExcitePatrol(transform,moveOnPath,FindPath,speed*1.5f,GetExcitePos,GetExciteRadius))
            .Back()
            .Conditioner(() =>
            {
                return isExcite;
            })
            .Task(new ToPos(transform, excitePos,moveOnPath,FindPath,speed*1.5f,GetExcitePos,SetIsToPos))
            .Back()
            .Conditioner(() =>
            {
                InitializeExcite();
                return true;
            })
            .Task(new Patrol(transform,PatrolPath,moveOnPath,FindPath,speed))
            .Back()
            .Back()
            .End();
    }
    public void moveOnPath(List<Vector2> path,float moveSpeed)
    {
        var length = Time.deltaTime * moveSpeed;
        if (path == null)
        {
            return;
        }
        foreach (var pos in path)
        {
            if (Vector2.Distance(transform.position,pos) <= length)
            {
                var distance = Vector2.Distance(transform.position,pos);
                transform.position = Vector3.MoveTowards(transform.position,pos,distance);
                length -= distance;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position,pos,length);
                length = 0;
                return;
            }
        }
    }
}
    
   
