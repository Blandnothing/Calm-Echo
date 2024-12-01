using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using NBehaviorTree;
using Unity.VisualScripting;
using UnityEngine;

public class TestMonster : Monster
{
    public Rigidbody2D rb;
    public Transform playerTransform;
    public List<Vector2Int> PatrolPath;
    public int currentPos = 0;
    protected override void BuildTree()
    {
        bhTreeBulider
            .Selector()
                .Conditioner(() =>
            {
                float limitedDistance = 20f;
                var playerPosition = playerTransform.position;
                var monsterPosition = transform.position;
                var distance = Vector3.Distance(playerPosition, monsterPosition);
                return distance < limitedDistance;
            })
                     .Task(new Chase(transform, playerTransform, moveOnPath, FindPath))
                .Back()
                .Sequence()
                    .Task(new GetBack())
                    .Task(new Patrol(PatrolMove))
                .Back()
            .Back()
            .End();
    }
    public void moveOnPath(List<Vector2> path)
    {
        var length = Time.deltaTime * speed;
        if (path == null)
        {
            return;
        }
        foreach (var pos in path)
        {
            if (Vector2.Distance(transform.position, pos) <= length)
            {
                var distance = Vector2.Distance(transform.position, pos);
                transform.position = Vector3.MoveTowards(transform.position, pos, distance);
                length -= distance;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, pos, length);
                length = 0;
                return;
            }
        }
    }

    public void PatrolMove()
    {
        var length = Time.deltaTime * speed;
        while (length > 0)
        {
            if (transform.position != (Vector3Int)PatrolPath[currentPos])
            {
                if (Vector2.Distance(transform.position, PatrolPath[currentPos]) <= length)
                {
                    var distance = Vector2.Distance(transform.position, PatrolPath[currentPos]);
                    transform.position = Vector3.MoveTowards(transform.position, (Vector3Int)PatrolPath[currentPos], distance);
                    length -= distance;
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, (Vector3Int)PatrolPath[currentPos], length);
                    length = 0;
                }

            }
            else
            {
                currentPos++;
                if (currentPos >= PatrolPath.Count)
                {
                    currentPos = 0;
                }
            }

        }

    }
}
