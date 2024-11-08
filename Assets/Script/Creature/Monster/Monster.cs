using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NBehaviorTree;

public abstract class Monster : Creature,IWaveReceiver
{
    //移动速率
    public float speed;
    protected BehaviorTreeBuilder bhTreeBulider; 
    //具体构造行为树
    protected abstract void BuildTree();
    //接收声波
    public virtual void OnReceiveWave(GameObject transmitter){}
    //被攻击时
    public virtual void OnAttacked(GameObject attacker){}
    //攻击时
    public virtual void OnAttack(GameObject attackObject){}
   
     void Awake()
     {
         bhTreeBulider = new BehaviorTreeBuilder();
     } 
     // Start is called before the first frame update
   private void Start()
   {
      BuildTree();
   }

    // Update is called once per frame
    void Update()
    {
        bhTreeBulider.Tick();
    }
}
