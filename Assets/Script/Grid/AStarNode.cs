

	using UnityEngine;
	using UnityEngine.Animations;
	using System.Collections.Generic;
	using Unity.VisualScripting;

	public class AStarNode
	{
		
		public readonly Vector2Int position;
		public AStarNode(Vector2Int position)
		{
			this.position = position;
		}

		public override bool Equals(object obj)
		{
			if (obj is AStarNode)
			{
				return this.position == ((AStarNode)obj).position;
			}
			else
			{
				return false;
			}
		}

		public override int GetHashCode()
		{
			return this.position.GetHashCode();
		}
		


	}
	
