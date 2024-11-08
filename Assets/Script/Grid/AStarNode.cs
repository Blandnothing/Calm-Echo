

	using UnityEngine;
	using UnityEngine.Animations;
	using System.Collections.Generic;
	using Unity.VisualScripting;

	public class AStarNode
	{
		public AStarNode parent;
		public Vector2Int position;
		// 从起点到此节点的实际成本
		public float GCost;  
		  // 此节点到目标的估算成本
		public float HCost; 
		// 总成本        
		public float FCost => GCost + HCost; 
		public AStarNode(Vector2Int position)
		{
			this.position = position;
		}
	
	}
