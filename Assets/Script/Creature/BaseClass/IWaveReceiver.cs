using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//声波接收器接口，所有受声波影响的物体都应继承此接口
public interface IWaveReceiver
{
    /// <summary>
    /// 接触到声波时调用此函数
    /// </summary>
    /// <param name="transmitter">发射声波的物体</param>
    void OnReceiveWave(GameObject transmitter);
}
