using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEmitter : MonoBehaviour
{
    public GameObject wavePrefab; // ����Ԥ�Ƽ�
    public float waveInterval = 2.0f; // ���������ļ��ʱ��

    private void Start()
    {
        // ÿ��һ��ʱ�䷢������
        StartCoroutine(EmitWave());
    }

    private IEnumerator EmitWave()
    {
        while (true)
        {
            // ��������ʵ��
            GameObject wave = Instantiate(wavePrefab, transform.position - new Vector3(0,1.5f), Quaternion.identity);
            // ���������İ뾶
            Wave waveComponent = wave.GetComponent<Wave>();
            if (waveComponent != null)
            {
                waveComponent.SetRadius();
            }

            // �ȴ�ָ���ļ��ʱ����ٷ�����һ��
            yield return new WaitForSeconds(waveInterval);
        }
    }

}



