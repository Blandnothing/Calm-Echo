using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
namespace NBehaviorTree
{
	public class ExcitePatrol:Task
	{
		
		public delegate void MoveOnPath(List<Vector2> path,float moveSpeed);

		public delegate List<Vector2> FindPath(Vector2Int start,Vector2Int end);
		
		public delegate Vector2 GetPos();

		private GetPos GetExcitePos;
		private Func<float> GetExciteRadius;

		protected MoveOnPath moveOnPath;
		protected FindPath findPath;

		private Vector2 excitePos;
		private float exciteRadius;
		
		private Transform self;

		private float speed;

		private Vector2 aim;

		private List<Vector2> path;
		private List<Vector2Int> randomPoint;

		protected override void OnInitialize()
		{
			excitePos = GetExcitePos();
			exciteRadius = GetExciteRadius();
			randomPoint = GetRandomPoint();
			aim = RandomCoordinate();
			
		}

		public ExcitePatrol(Transform transform,MoveOnPath moveOnPath,FindPath findPath,float speed,GetPos GetExcitePos,Func<float> GetExciteRadius)
		{
			this.self = transform;
			this.moveOnPath = moveOnPath;
			this.findPath = findPath;
			this.speed = speed;
			this.GetExcitePos = GetExcitePos;
			this.GetExciteRadius = GetExciteRadius;

		}
		private List<Vector2Int> GetRandomPoint()
		{
			List<Vector2Int> res = new();
			Vector2Int pos = Vector2Int.FloorToInt(excitePos);
			for (int i = pos.x - (int)exciteRadius; i <= pos.x + exciteRadius; i++)
			{
				for (int j = pos.y - (int)exciteRadius; j <= pos.y + exciteRadius; j++)
				{
					var tpos = new Vector2Int(i,j);
					if (Vector2Int.Distance(pos,tpos) <= exciteRadius&&CanWalkMap.instance.IsWalkable(tpos))
					{
						res.Add(tpos);
					} 
				}
			}
			return res;

		}
		public Vector2Int RandomCoordinate()
		{
			return randomPoint[UnityEngine.Random.Range(0,randomPoint.Count)];
		}
		protected override EStatus OnExecute()
		{
			var start = (Vector2Int)Vector3Int.FloorToInt(self.position);
			var end = (Vector2Int)Vector3Int.FloorToInt(aim); 
			path = findPath.Invoke(start,end);
			moveOnPath.Invoke(path,speed);
			if ((Vector2Int)Vector3Int.FloorToInt(self.position)==(Vector2Int)Vector3Int.FloorToInt(aim))
			{
				return EStatus.Success;
			}
			return EStatus.Running;
			
		}
	}
}