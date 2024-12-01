//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//// �����࣬���ڹ�����������Ϊ
//public class Wave : MonoBehaviour
//{
//    private float radius; // �����뾶
//    private float lifetime = 1.0f; // ��������ʱ��

//    public void SetRadius(float newRadius)
//    {
//        radius = newRadius;
//        StartCoroutine(ExpandAndDestroy());
//    }

//    private IEnumerator ExpandAndDestroy()
//    {
//        float startTime = Time.time;

//        // ������������ָ���뾶
//        while (Time.time < startTime + lifetime)
//        {
//            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.one * radius, (Time.time - startTime) / lifetime);
//            yield return null;
//        }

//        // ���Ӵ���������
//        DetectWave();
//        // ������������
//        Destroy(gameObject);

//    }

//    private void DetectWave()
//    {
//        // ��ȡ������ײ��
//        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius);

//        foreach (var collider in hitColliders)
//        {
//            // ��⵽WaveReceiver
//            IWaveReceiver receiver = collider.GetComponent<IWaveReceiver>();
//            if (receiver != null)
//            {
//                // ���ý��ղ��ķ���
//                receiver.OnReceiveWave(gameObject);
//            }
//        }
//    }
//}
