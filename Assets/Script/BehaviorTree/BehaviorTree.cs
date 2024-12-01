
namespace NBehaviorTree{
public class BehaviorTree 
{
    public bool HaveRoot => root != null;
    public Behavior root;

    public BehaviorTree(Behavior root)
    {
        this.root = root;
    }

    public void Tick()
    {
        root.Tick();
    }

    public void SetRoot(Behavior root)
    {
        this.root = root;
    }
}
}

