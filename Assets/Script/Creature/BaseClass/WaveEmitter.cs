//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class WaveEmitter : MonoBehaviour
//{
//    public GameObject wavePrefab; // ����Ԥ�Ƽ�
//    public float waveInterval = 2.0f; // ���������ļ��ʱ��

//    private void Start()
//    {
//        // ÿ��һ��ʱ�䷢������
//        StartCoroutine(EmitWave());
//    }

//    private IEnumerator EmitWave()
//    {
//        while (true)
//        {
//            // ��������ʵ��
//            GameObject wave = Instantiate(wavePrefab, transform.position, Quaternion.identity);
//            // ���������İ뾶
//            Wave waveComponent = wave.GetComponent<Wave>();
//            if (waveComponent != null)
//            {
//                waveComponent.SetRadius(3.0f);
//            }

//            // �ȴ�ָ���ļ��ʱ����ٷ�����һ��
//            yield return new WaitForSeconds(waveInterval);
//        }
//    }
    
//}



