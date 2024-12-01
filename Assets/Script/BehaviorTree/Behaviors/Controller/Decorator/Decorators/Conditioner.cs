
using System;

namespace NBehaviorTree
{
    public class Conditioner:Decorator
    {
        private Func<bool> condition;

        public Conditioner(Func<bool> condition)
        {
            this.condition = condition;
        }

        protected override EStatus OnExecute()
        {
            return condition.Invoke() ? child.Tick() : EStatus.Failure;
        }
    }
}