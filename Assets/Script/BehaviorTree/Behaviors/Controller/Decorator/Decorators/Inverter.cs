namespace NBehaviorTree
{
    //取反器
    public class Inverter :Decorator
    {
        protected override EStatus OnExecute()
        {
            child.Tick();
            if(child.IsFailure)
                return EStatus.Success;
            if(child.IsSuccess)
                return EStatus.Failure;
            return EStatus.Running;
        }
    }
}