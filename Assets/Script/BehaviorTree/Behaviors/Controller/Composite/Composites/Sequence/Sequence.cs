using System.Collections.Generic;

namespace NBehaviorTree
{
    //顺序器
    public class Sequence :Composite
    {
        protected LinkedListNode<Behavior> currentChild;
        protected override void OnInitialize()
        {
            currentChild = children.First;
        }

        protected override EStatus OnExecute()
        {
            while (true)
            {
                    var s = currentChild.Value.Tick();
                            if( s != EStatus.Success)
                                return s;
                           
                            currentChild = currentChild.Next;
                
                            if (currentChild == null)
                            {
                                 return EStatus.Success;
                            }
            }
               
        }
        
    }
}