//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class WaveReceiver : MonoBehaviour, IWaveReceiver
//{
//    // 边框颜色变化的材质
//    private Material originalMaterial;
//    private Material whiteMaterial;

//    // 用于控制边框显示的Coroutine
//    private IEnumerator whiteBorderCoroutine;

//    void Start()
//    {
//        // 获取物体的原始材质
//        originalMaterial = GetComponent<Renderer>().material;

//        // 创建一个新的材质，用于显示白色边框
//        whiteMaterial = new Material(Shader.Find("Standard"));
//        whiteMaterial.color = Color.red;
//    }

//    // 实现接口中的方法，接触到声波时调用此函数
//    public void OnReceiveWave(GameObject transmitter)
//    {
//        // 显示白色边框（通过修改颜色而不是材质）
//        Color originalColor = GetComponent<SpriteRenderer>().color;
//        GetComponent<SpriteRenderer>().color = Color.white;

//        // 如果已经有Coroutine在运行，则停止它
//        if (whiteBorderCoroutine != null)
//        {
//            StopCoroutine(whiteBorderCoroutine);
//        }

//        // 开始一个新的Coroutine来控制边框的显示时间
//        whiteBorderCoroutine = ShowWhiteBorderForTime(1.0f, originalColor); // 显示1秒并恢复原色
//        StartCoroutine(whiteBorderCoroutine);
//    }

//    // Coroutine用于控制边框显示时间（修改为适应SpriteRenderer）
//    private IEnumerator ShowWhiteBorderForTime(float duration, Color originalColor)
//    {
//        // 等待指定的时间
//        yield return new WaitForSeconds(duration);

//        // 时间结束后恢复原始颜色
//        GetComponent<SpriteRenderer>().color = originalColor;
//    }

//    void OnDestroy()
//    {
//        // 确保在对象销毁时释放材质资源
//        if (whiteMaterial != null)
//        {
//            Destroy(whiteMaterial);
//        }
//    }
//}

////声波接收器接口，所有受声波影响的物体都应继承此接口
//public interface IWaveReceiver
//{
//    /// <summary>
//    /// 接触到声波时调用此函数
//    /// </summary>
//    /// <param name="transmitter">发射声波的物体</param>
//    void OnReceiveWave(GameObject transmitter);
//}

