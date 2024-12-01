using System;
using System.Collections.Generic;
namespace NBehaviorTree
{
    public class BehaviorTreeBuilder
    {
        private readonly Stack<Controller> nodeStack;//构建树结构用的栈
        private readonly BehaviorTree bhTree;//构建的树
        public BehaviorTreeBuilder()
        {
            bhTree = new BehaviorTree(null);//构造一个没有根的树
            nodeStack = new Stack<Controller>();//初始化构建栈
        }
        private void AddBehavior(Controller controller)
        {
            if (bhTree.HaveRoot)//有根节点时，加入构建栈
            {
                nodeStack.Peek().AddChild(controller);
            }
            else 
            {   //当树没根时，新增得节点视为根节点
                bhTree.SetRoot(controller);
            }
            nodeStack.Push(controller);
            
        }

        private void AddBehavior(Task task)
        {
            nodeStack.Peek().AddChild(task);
        }
        public void Tick()
        {
            bhTree.Tick();
        }
        public BehaviorTreeBuilder Back()
        {
            nodeStack.Pop();
            return this;
        }
        public BehaviorTreeBuilder End()
        {
            nodeStack.Clear();
            return this;
        }

        public BehaviorTreeBuilder Sequence()
        {
            AddBehavior(new Sequence());
            return this;
        }

        public BehaviorTreeBuilder Selector()
        {
            AddBehavior(new Selector());
            return this;
        }

        public BehaviorTreeBuilder Task(Task task)
        {
            AddBehavior(task);
            return this;
        }

        public BehaviorTreeBuilder Conditioner(Func<bool> condition)
        {
            AddBehavior(new Conditioner(condition));
            return this;
        }
        
    }
}