

	using UnityEngine;
	using UnityEngine.Animations;
	using System.Collections.Generic;
	using Unity.VisualScripting;

	public record  AStarNode
	{
		
		public readonly Vector2Int position;
		public AStarNode(Vector2Int position)
		{
			this.position = position;
		}
		
		


	}
	
