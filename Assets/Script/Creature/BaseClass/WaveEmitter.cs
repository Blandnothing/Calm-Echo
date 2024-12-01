//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class WaveEmitter : MonoBehaviour
//{
//    public GameObject wavePrefab; // 声波预制件
//    public float waveInterval = 2.0f; // 发射声波的间隔时间

//    private void Start()
//    {
//        // 每隔一段时间发射声波
//        StartCoroutine(EmitWave());
//    }

//    private IEnumerator EmitWave()
//    {
//        while (true)
//        {
//            // 创建声波实例
//            GameObject wave = Instantiate(wavePrefab, transform.position, Quaternion.identity);
//            // 设置声波的半径
//            Wave waveComponent = wave.GetComponent<Wave>();
//            if (waveComponent != null)
//            {
//                waveComponent.SetRadius(3.0f);
//            }

//            // 等待指定的间隔时间后再发射下一波
//            yield return new WaitForSeconds(waveInterval);
//        }
//    }
    
//}



