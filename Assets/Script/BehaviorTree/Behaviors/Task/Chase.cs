using System.Collections.Generic;
using UnityEngine;
namespace NBehaviorTree
{
	public class Chase:Task
	{
		private Transform aim;
		private Transform self;
		private List<Vector2> path;
		

		public delegate void MoveOnPath(List<Vector2> path);

		public delegate List<Vector2> FindPath(Vector2Int start,Vector2Int end);

		private MoveOnPath moveOnPath;
		private FindPath findPath;
		public Chase(Transform self,Transform aim,MoveOnPath moveOnPath,FindPath findPath)
		{
			this.aim = aim;
			this.self = self;
			this.moveOnPath = moveOnPath;
			this.findPath = findPath;
		}
	
		protected override EStatus OnExecute()
		{
			var start = (Vector2Int)Vector3Int.FloorToInt(self.position);
			var end = (Vector2Int)Vector3Int.FloorToInt(aim.position); 
			 path = findPath.Invoke(start,end);
			moveOnPath.Invoke(path);
			if (self.position==aim.position)
			{
				return EStatus.Success;
			}
			return EStatus.Running;
		}
	}
}