using System.Linq;
namespace NBehaviorTree
{
	public class PrioritySelector:Sequence
	{
		protected override EStatus OnExecute()
		{
			currentChild = children.First;
			while(true)
			{
				var s = currentChild.Value.Tick();
				if (s != EStatus.Failure)
				{
					foreach (var child in children)
					{
						if (child != currentChild.Value)
						{
							child.Reset();
						}
					}
					return s;
				}
				currentChild = currentChild.Next;
				if(currentChild == null) 
					return EStatus.Failure;
			}
		}
		
	}
}