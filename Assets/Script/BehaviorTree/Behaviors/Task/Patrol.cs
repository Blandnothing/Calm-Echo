using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace NBehaviorTree
{
	public class Patrol :Task
	{
		public Action partrolMove;
		public Patrol(Action partrolMove)
		{
			this.partrolMove = partrolMove;
		}
		protected override EStatus OnExecute()
		{
			partrolMove.Invoke();
			return EStatus.Success;
		}

		
		
	}
	
}