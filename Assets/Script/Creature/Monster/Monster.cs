//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using NBehaviorTree;
//using UnityEngine.Tilemaps;

//public abstract class Monster : Creature,IWaveReceiver
//{
//    //移动速率
//    public float speed;
//    protected BehaviorTreeBuilder bhTreeBulider; 
//    //寻路方法
//    private AStar aStar;
//    public List<Tilemap> maps;
//    //具体构造行为树
//    protected abstract void BuildTree();
//    //接收声波
//    public virtual void OnReceiveWave(GameObject transmitter){}
//    //被攻击时
//    public virtual void OnAttacked(GameObject attacker){}
//    //攻击时
//    public virtual void OnAttack(GameObject attackObject){}
    
//    //寻路
//    public virtual List<Vector2> FindPath(Vector2Int start,Vector2Int end)
//    {
//        return aStar.FindPath(start,end);
//    }
   
//     void Awake()
//     {
//         bhTreeBulider = new BehaviorTreeBuilder(); 
//         aStar = new AStar(maps);
//     } 
//     // Start is called before the first frame update
//   private void Start()
//   {
//      BuildTree();
//   }

//    // Update is called once per frame
//    void Update()
//    {
//        bhTreeBulider.Tick();
        
//    }
//}
