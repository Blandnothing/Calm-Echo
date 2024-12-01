namespace NBehaviorTree
{
    //选择器
    public class Selector :Sequence
    {
        protected override EStatus OnExecute()
        {
            while(true)
            {
                var s = currentChild.Value.Tick();
                if( s != EStatus.Failure)
                    return s;
                currentChild = currentChild.Next;
                if(currentChild == null)
                    return EStatus.Failure;
            }
        }
    }
}