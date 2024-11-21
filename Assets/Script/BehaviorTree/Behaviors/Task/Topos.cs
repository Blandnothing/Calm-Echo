using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace NBehaviorTree
{
	public class ToPos:Task
	{
		
		private Vector2 aim;
		private Transform self;
		private List<Vector2> path;

		private float speed;
		

		public delegate void MoveOnPath(List<Vector2> path,float moveSpeed);

		public delegate List<Vector2> FindPath(Vector2Int start,Vector2Int end);

		public delegate Vector2 GetPos();

		private MoveOnPath moveOnPath;
		private FindPath findPath;
		private GetPos getPos;
		private Action setIsToPos;
		public ToPos(Transform self,in Vector2 aim,MoveOnPath moveOnPath,FindPath findPath,float speed,GetPos getPos,Action setIsToPos)
		{
			this.aim = aim;
			this.self = self;
			this.moveOnPath = moveOnPath;
			this.findPath = findPath;
			this.getPos = getPos;
			this.speed = speed;
			this.setIsToPos = setIsToPos;
		}
		
		protected override EStatus OnExecute()
		{
			aim = getPos.Invoke();
			var start = (Vector2Int)Vector3Int.FloorToInt(self.position);
			var end = (Vector2Int)Vector3Int.FloorToInt(aim); 
			path = findPath.Invoke(start,end);
			moveOnPath.Invoke(path,speed);
			if ((Vector2Int)Vector3Int.FloorToInt(self.position)==(Vector2Int)Vector3Int.FloorToInt(aim))
			{
				setIsToPos.Invoke();
				return EStatus.Success;
			}
			return EStatus.Running;
		}
	}
}