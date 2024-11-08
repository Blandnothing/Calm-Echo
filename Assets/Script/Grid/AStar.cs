using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AStar:MonoBehaviour
{
    public static AStar Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
      
    }
   public List<Tilemap> maps;
 
   private List<AStarNode> openList=new List<AStarNode>();
   private List<AStarNode> closedList=new List<AStarNode>();
   
   private Dictionary<Vector2Int, AStarNode> allNodes = new Dictionary<Vector2Int, AStarNode>();
   
   
   
    public List<Vector2Int> FindPath(Vector2Int start, Vector2Int goal)
    {
        openList.Clear();
        closedList.Clear();
        AStarNode startNode = GetNode(start);
        AStarNode goalNode = GetNode(goal);

        openList.Add(startNode);

        while (openList.Count > 0)
        {
            AStarNode currentNode = GetLowestFCostNode();

            if (currentNode.position == goal)
            {
                return RetracePath(startNode, currentNode);
            }

            openList.Remove(currentNode);
            closedList.Add(currentNode);

            foreach (AStarNode neighbor in GetNeighbors(currentNode))
            {
                if (closedList.Contains(neighbor) || !IsWalkable(neighbor.position))
                {
                    continue;
                }

                float newMovementCostToNeighbor = currentNode.GCost + GetDistance(currentNode, neighbor);
                if (newMovementCostToNeighbor < neighbor.GCost || !openList.Contains(neighbor))
                {
                    neighbor.GCost = newMovementCostToNeighbor;
                    neighbor.HCost = GetDistance(neighbor, goalNode);
                    neighbor.parent = currentNode;

                    if (!openList.Contains(neighbor))
                    {
                        openList.Add(neighbor);
                    }
                }
            }
        }
    // 未找到路径
        return null; 
    }

    // 获取最小FCost的节点
    private AStarNode GetLowestFCostNode()
    {
        AStarNode lowestFCostNode = openList[0];
        foreach (AStarNode node in openList)
        {
            if (node.FCost < lowestFCostNode.FCost || ((node.FCost -lowestFCostNode.FCost)<0.1f && node.HCost < lowestFCostNode.HCost))
            {
                lowestFCostNode = node;
            }
        }
        return lowestFCostNode;
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
            currentNode = currentNode.parent;
        }
        path.Reverse();
        return path;
    }

    // 获取邻居节点
    private List<AStarNode> GetNeighbors(AStarNode node)
    {
        List<AStarNode> neighbors = new List<AStarNode>();

        Vector2Int[] directions = {
            Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right,Vector2Int.up+Vector2Int.left,Vector2Int.up+Vector2Int.right,Vector2Int.down+Vector2Int.left,Vector2Int.down+Vector2Int.right
        };

        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighborPos = node.position + direction;
            neighbors.Add(GetNode(neighborPos));
        }

        return neighbors;
    }

    // 获取或创建节点
    private AStarNode GetNode(Vector2Int position)
    {
        if (allNodes.TryGetValue(position, out AStarNode node))
        {
            return node;
        }
        else
        {
            node = new AStarNode(position);
            allNodes[position] = node;
            return node;
        }
    }

    // 判断Tile是否可通行
    private bool IsWalkable(Vector2Int position)
    {
        foreach (Tilemap tilemap in maps)
        {
            TileBase tile = tilemap.GetTile((Vector3Int)position);
            if (tile!=null&&tile.name == "wall")
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
   
   

