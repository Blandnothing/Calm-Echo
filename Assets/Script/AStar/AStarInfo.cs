
	public class AStarInfo
	{
		public AStarNode parent;
		public float HCost;
		public float GCost;
		public float FCost => HCost + GCost;
		public AStarInfo(float gCost,float hCost,AStarNode parent)
		{
			this.GCost = gCost;
			this.HCost = hCost;
			this.parent = parent;
		}

	}
