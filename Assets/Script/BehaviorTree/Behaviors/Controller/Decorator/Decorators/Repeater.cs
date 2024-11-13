namespace NBehaviorTree
{
    public class Repeater:Decorator
    {   //当前重复次数
        private int conunter;
        //重复限度
        private int limit;
        public Repeater(int limit)
        {
            this.limit = limit;
        }
        protected override void OnInitialize()
        {   //进入时，将次数清零
            conunter = 0;
        }

        protected override EStatus OnExecute()
        {
            while (true)
            {
                child.Tick();
                if (child.IsRunning)
                    return EStatus.Running;
                if (child.IsFailure)
                    return EStatus.Failure;
                //子节点执行成功，就增加一次计算，达到设定限度才返回成功
                if (++conunter >= limit)
                    return EStatus.Success;
            }
        }
    }
}