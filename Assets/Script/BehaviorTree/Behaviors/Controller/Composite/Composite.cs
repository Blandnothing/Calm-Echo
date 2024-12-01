using System.Collections.Generic;

namespace NBehaviorTree
{
    public abstract class Composite :Controller
    {
        protected LinkedList<Behavior> children;

        public Composite()
        {
            children = new LinkedList<Behavior>();
        }

        public override void AddChild(Behavior child)
        {
            children.AddLast(child);
        }
    }
}