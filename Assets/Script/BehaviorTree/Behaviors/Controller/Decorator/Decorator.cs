namespace NBehaviorTree
{
    public abstract class Decorator:Controller
    {
        protected Behavior child;
        public override void AddChild(Behavior child)
        {
            this.child = child;
        }
    }
}