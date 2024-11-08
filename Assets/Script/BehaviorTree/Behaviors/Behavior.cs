using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NBehaviorTree
{
    public enum EStatus
    {
        Failure,Success,Running,Initialization
    }
    
    public abstract class Behavior
    {
        protected EStatus status;
        
        public bool IsSuccess => status == EStatus.Success;
        public bool IsFailure => status == EStatus.Failure;
        public bool IsRunning => status == EStatus.Running;
        public bool IsTerminated => IsSuccess || IsFailure;
        
        protected virtual void OnInitialize(){}
        protected abstract EStatus OnExecute();
        protected virtual void OnTerminated(){}

        public EStatus Tick()
        {
            if (!IsRunning)
            {
                OnInitialize();
            }

            status = OnExecute();
            if (!IsRunning)
            {
                OnTerminated();
            }
            return status;
        }
        public void Reset()
        {
            status = EStatus.Initialization;
        }
        
    }
}