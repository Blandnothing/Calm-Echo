using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�����������ӿڣ�����������Ӱ������嶼Ӧ�̳д˽ӿ�
public interface IWaveReceiver
{
    /// <summary>
    /// �Ӵ�������ʱ���ô˺���
    /// </summary>
    /// <param name="transmitter">��������������</param>
    void OnReceiveWave(GameObject transmitter);
}
