using System;

class AStarCompare :IComparable<AStarCompare>
{
	public AStarNode node;
	public float fCost;
	public AStarCompare(AStarNode aStarNode,float fCost)
	{
		this.node = aStarNode;
		this.fCost =fCost;
	}
	public int CompareTo(AStarCompare other)
	{
		return fCost.CompareTo(other.fCost);
	}
}