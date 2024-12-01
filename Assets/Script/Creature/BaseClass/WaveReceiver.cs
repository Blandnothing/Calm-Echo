//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class WaveReceiver : MonoBehaviour, IWaveReceiver
//{
//    // �߿���ɫ�仯�Ĳ���
//    private Material originalMaterial;
//    private Material whiteMaterial;

//    // ���ڿ��Ʊ߿���ʾ��Coroutine
//    private IEnumerator whiteBorderCoroutine;

//    void Start()
//    {
//        // ��ȡ�����ԭʼ����
//        originalMaterial = GetComponent<Renderer>().material;

//        // ����һ���µĲ��ʣ�������ʾ��ɫ�߿�
//        whiteMaterial = new Material(Shader.Find("Standard"));
//        whiteMaterial.color = Color.red;
//    }

//    // ʵ�ֽӿ��еķ������Ӵ�������ʱ���ô˺���
//    public void OnReceiveWave(GameObject transmitter)
//    {
//        // ��ʾ��ɫ�߿�ͨ���޸���ɫ�����ǲ��ʣ�
//        Color originalColor = GetComponent<SpriteRenderer>().color;
//        GetComponent<SpriteRenderer>().color = Color.white;

//        // ����Ѿ���Coroutine�����У���ֹͣ��
//        if (whiteBorderCoroutine != null)
//        {
//            StopCoroutine(whiteBorderCoroutine);
//        }

//        // ��ʼһ���µ�Coroutine�����Ʊ߿����ʾʱ��
//        whiteBorderCoroutine = ShowWhiteBorderForTime(1.0f, originalColor); // ��ʾ1�벢�ָ�ԭɫ
//        StartCoroutine(whiteBorderCoroutine);
//    }

//    // Coroutine���ڿ��Ʊ߿���ʾʱ�䣨�޸�Ϊ��ӦSpriteRenderer��
//    private IEnumerator ShowWhiteBorderForTime(float duration, Color originalColor)
//    {
//        // �ȴ�ָ����ʱ��
//        yield return new WaitForSeconds(duration);

//        // ʱ�������ָ�ԭʼ��ɫ
//        GetComponent<SpriteRenderer>().color = originalColor;
//    }

//    void OnDestroy()
//    {
//        // ȷ���ڶ�������ʱ�ͷŲ�����Դ
//        if (whiteMaterial != null)
//        {
//            Destroy(whiteMaterial);
//        }
//    }
//}

////�����������ӿڣ�����������Ӱ������嶼Ӧ�̳д˽ӿ�
//public interface IWaveReceiver
//{
//    /// <summary>
//    /// �Ӵ�������ʱ���ô˺���
//    /// </summary>
//    /// <param name="transmitter">��������������</param>
//    void OnReceiveWave(GameObject transmitter);
//}

