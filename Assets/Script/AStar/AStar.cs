using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

[Serializable]
public class AStar
{
    public AStar(List<Tilemap> maps)
    {
        this.maps = maps;
    }
    [SerializeField]
   public List<Tilemap> maps;
   public static int openListFull=1000;
   private PriorityQueue<AStarCompare> openList=new (openListFull);
   private HashSet<AStarNode> closedList=new ();

  

   class AStarCompare :IComparable<AStarCompare>
   {
       public AStarNode node;
       public float fCost;
       public AStarCompare(AStarNode aStarNode,float fCost)
       {
           this.node = aStarNode;
           this.fCost =fCost;
       }
       public int CompareTo(AStarCompare other)
       {
           return fCost.CompareTo(other.fCost);
       }
   }

   private Dictionary<AStarNode,AStarInfo> Astardic=new();
   
    public List<Vector2> FindPath(Vector2Int start, Vector2Int goal)
    {
        openList = new (openListFull);
        closedList = new ();
        Astardic = new Dictionary<AStarNode,AStarInfo>();
        AStarNode startNode = new AStarNode(start);
        AStarNode goalNode = new AStarNode(goal);

        openList.PushHeap(new AStarCompare(startNode,GetDistance(startNode,goalNode)));
        Astardic.Add(startNode,new AStarInfo(0,GetDistance(startNode,goalNode),null));

        while (!openList.IsEmpty)
        {
            if (openList.IsFull)
            {
                return null;
            }
            AStarNode currentNode = openList.Top.node;
            var value = openList.Top.fCost;
            if (value > Astardic[currentNode].FCost)
            {
                continue;
            }
            openList.PopHeap();
            
            if (currentNode.position == goal)
            {
                return Modify(RetracePath(startNode, currentNode));
            }
            
            closedList.Add(currentNode);
            
            foreach (AStarNode neighbor in GetNeighbors(currentNode))
            {
                if (closedList.Contains(neighbor) || !IsWalkable(neighbor.position))
                {
                    continue;
                }

                float newMovementCostToNeighbor = Astardic[currentNode].GCost + GetDistance(currentNode, neighbor);
                if (!Astardic.ContainsKey(neighbor)||newMovementCostToNeighbor < Astardic[neighbor].GCost )
                {
                    if (Astardic.ContainsKey(neighbor))
                    {
                          Astardic[neighbor].GCost = newMovementCostToNeighbor;
                          Astardic[neighbor].HCost = GetDistance(neighbor, goalNode);
                          Astardic[neighbor].parent = currentNode;
                    }
                    else
                    {
                        Astardic.Add(neighbor,new AStarInfo( newMovementCostToNeighbor,GetDistance(neighbor, goalNode),currentNode));
                    }
                    
                    openList.PushHeap(new (neighbor,Astardic[neighbor].FCost));
                }
            }
        }
        // 未找到路径
        return null; 
    }
    

    // 回溯路径
    private List<Vector2Int> RetracePath(AStarNode startNode, AStarNode endNode)
    {
        
        List<Vector2Int> path = new List<Vector2Int>();
        AStarNode currentNode = endNode;
        if (startNode == endNode)
        {
            path.Add(startNode.position);
            return path;
        }
        while (currentNode != startNode)
        {
            path.Add(currentNode.position);
            currentNode = Astardic[currentNode].parent;
        }
        path.Reverse();
        return path;
    }

    private List<Vector2> Modify(List<Vector2Int> list)
    {
        if (list == null)
        {
            return null;
        }
        List<Vector2> res=new ();
        for (int i = 0; i < list.Count; i++)
        {
            res.Add(list[i]+new Vector2(0.5f,0.5f));
        }
        return res;
    }

    // 获取邻居节点
    private List<AStarNode> GetNeighbors(AStarNode node)
    {
        List<AStarNode> neighbors = new ();

        Vector2Int[] directions = {
            Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right
        };

        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighborPos = node.position + direction;
            var neighbor = new AStarNode(neighborPos);
            neighbors.Add(neighbor);
        }

        return neighbors;
    }

    // 获取或创建节点
 

    // 判断Tile是否可通行
    private bool IsWalkable(Vector2Int position)
    {  
        foreach (Tilemap tilemap in maps)
        {
            TileBase tile = tilemap.GetTile((Vector3Int)position);
            if (tile != null)
            {
                return false;
                
            }
        }
        return true;
    }

    // 计算两个节点之间的距离
    private float GetDistance(AStarNode a, AStarNode b)
    {
        return Vector2.Distance(a.position,b.position);
    }
   
}
   
   

