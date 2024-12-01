//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//// 声波类，用于管理声波的行为
//public class Wave : MonoBehaviour
//{
//    private float radius; // 声波半径
//    private float lifetime = 1.0f; // 声波生存时间

//    public void SetRadius(float newRadius)
//    {
//        radius = newRadius;
//        StartCoroutine(ExpandAndDestroy());
//    }

//    private IEnumerator ExpandAndDestroy()
//    {
//        float startTime = Time.time;

//        // 逐渐扩大声波至指定半径
//        while (Time.time < startTime + lifetime)
//        {
//            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.one * radius, (Time.time - startTime) / lifetime);
//            yield return null;
//        }

//        // 检测接触到的物体
//        DetectWave();
//        // 销毁声波对象
//        Destroy(gameObject);

//    }

//    private void DetectWave()
//    {
//        // 获取所有碰撞体
//        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius);

//        foreach (var collider in hitColliders)
//        {
//            // 检测到WaveReceiver
//            IWaveReceiver receiver = collider.GetComponent<IWaveReceiver>();
//            if (receiver != null)
//            {
//                // 调用接收波的方法
//                receiver.OnReceiveWave(gameObject);
//            }
//        }
//    }
//}
