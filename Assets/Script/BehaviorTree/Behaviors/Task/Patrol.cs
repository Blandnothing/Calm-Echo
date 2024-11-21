using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
namespace NBehaviorTree
{
	public class Patrol :Task
	{
		public delegate void MoveOnPath(List<Vector2> path,float moveSpeed);

		public delegate List<Vector2> FindPath(Vector2Int start,Vector2Int end);

		protected MoveOnPath moveOnPath;
		protected FindPath findPath;

		protected List<Vector2> patrolPath;
		protected Transform self;
		
		protected List<Vector2> path;
		protected float speed;

		protected int currentIndex;
		protected override void OnInitialize()
		{
			currentIndex = 0;
		}
		public Patrol(Transform self,List<Vector2> patrolPath,MoveOnPath moveOnPath,FindPath findPath,float speed)
		{
			this.self = self;
			this.patrolPath =patrolPath ;
			this.moveOnPath = moveOnPath;
			this.findPath = findPath;
			this.speed = speed;
			currentIndex = 0;
		}
		

		protected override EStatus OnExecute()
		{
				var start = (Vector2Int)Vector3Int.FloorToInt(self.position);
				var end = (Vector2Int)Vector3Int.FloorToInt(patrolPath[currentIndex]); 
				path = findPath.Invoke(start,end);
				moveOnPath.Invoke(path,speed);
				if ((Vector2Int)Vector3Int.FloorToInt(self.position)==(Vector2Int)Vector3Int.FloorToInt(patrolPath[currentIndex]))
				{
					currentIndex++;
					currentIndex %= patrolPath.Count;
				}

				return  EStatus.Running;
			
		}

		
		
	}
	
}