using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWindow : MonoBehaviour {

    /// <summary>
    /// 消息接收函数
    /// </summary>
    /// <param name="message"></param>
    /// <param name="param"></param>
    public virtual bool OnMessage(int message, System.Object param) {
        return false;
    }
}
