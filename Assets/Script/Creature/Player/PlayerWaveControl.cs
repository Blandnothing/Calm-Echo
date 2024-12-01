using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerWaveControl : MonoBehaviour
{
    private Wave playerWave;
    [SerializeField] private float waveRadius;

    private void Awake()
    {
        SetWaveRadius(waveRadius);
    }

    private void Update()
    {
        if (PlayerManager.instance.player.xInput != 0 || PlayerManager.instance.player.yInput != 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
                 SetWaveRadius(waveRadius * 5);//����ʱ�屶����
            else
                SetWaveRadius(waveRadius * 3);//����ʱ��������
        }
        else
        {
            SetWaveRadius(waveRadius);//��ֹʱ��������
        }        
    }

    //����Ԥ����������뾶(Ҳ���ǳ�ʼ��ֹʱ�İ뾶)
    private void SetWaveRadius(float radius)
    {
        string[] prefabs = AssetDatabase.FindAssets("t:Prefab");

        foreach (string pf in prefabs)
        {
            string path = AssetDatabase.GUIDToAssetPath(pf);
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);

            if (prefab != null)
            {
                if(prefab.GetComponent<Wave>() != null)
                {
                    prefab.GetComponent<Wave>().radius = radius;
                }
            }
        }
    }
}
