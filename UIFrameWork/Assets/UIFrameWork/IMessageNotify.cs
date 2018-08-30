using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 消息接收接口
/// </summary>
public interface IMessageNotify {
    // Post消息接收器
    void OnPostMessage(int message, System.Object param);
    // Send消息接收器
    bool OnSendMessage(int message, System.Object param);
}