using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWindowCenter : MonoBehaviour, IMessageNotify {

    private UIWindow m_Window = null;
    private LinkedList<UIMessageNode> m_PostMessageList = null;

    /// <summary>
    /// Post消息接收器
    /// </summary>
    /// <param name="message"></param>
    /// <param name="param"></param>
    /// <returns></returns>
    public void OnPostMessage(int message, System.Object param) {
       
    }

    /// <summary>
    /// Send消息接收器
    /// </summary>
    /// <param name="message"></param>
    /// <param name="param"></param>
    /// <returns></returns>
    public bool OnSendMessage(int message, System.Object param) {
        bool ret = false;
        var iter = m_Group.GetEnumerator();
        while (iter.MoveNext()) {
            var window = iter.Current.Value;
            if (window != null) {
                if (window.OnMessage(message, param))
                    ret = true;
            }
        }
        iter.Dispose();
        return ret;
    }
}
