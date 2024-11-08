using System.Collections.Generic;
using UnityEngine;
namespace NBehaviorTree
{
	public class Chase:Task
	{
		private Transform aim;
		private Transform self;

		public delegate void MoveOnPath(List<Vector2Int> path);

		private MoveOnPath moveOnPath;
		public Chase(Transform self,Transform aim,MoveOnPath moveOnPath)
		{
			this.aim = aim;
			this.self = self;
			this.moveOnPath = moveOnPath;
		}
	
		protected override EStatus OnExecute()
		{
			var start = (Vector2Int)Vector3Int.RoundToInt(self.position);
			var end = (Vector2Int)Vector3Int.RoundToInt(aim.position);
			var path = AStar.Instance.FindPath(start,end);
			moveOnPath.Invoke(path);
			if (self.position == aim.position)
			{
				return EStatus.Success;
			}
			return EStatus.Running;
		}
	}
}