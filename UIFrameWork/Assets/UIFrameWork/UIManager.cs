using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class UIMessageNode {
    public int message {
        get;
        set;
    }

    public System.Object param {
        get;
        set;
    }

    public LinkedListNode<UIMessageNode> linkNode {
        get {
            if (m_LinkNode == null)
                m_LinkNode = new LinkedListNode<UIMessageNode>(this);
            return m_LinkNode;
        }
    }

    private LinkedListNode<UIMessageNode> m_LinkNode = null;
}

public class UIManager : MonoBehaviour {
    // 保存UI的框架
    private Dictionary<int, UIWindowCenter> m_WndGroup = new Dictionary<int, UIWindowCenter>();
    private ObjectPool<UIMessageNode> m_MessagePool = new ObjectPool<UIMessageNode>();
    private bool m_IsInitMessagePool = false;

    public bool SendMessage(UIEnum window, int message, System.Object param) {
        UIWindowCenter group;
        if (m_WndGroup.TryGetValue((int)window, out group)) {
            if (group == null)
                return false;
            return group.OnSendMessage(message, param);
        }
        return false;
    }

    // isOnce是否是唯一性
    public bool PostMessage(UIEnum window, int message, System.Object param, bool isOnce = true) {
        UIWindowCenter group;
        if (!m_WndGroup.TryGetValue((int)window, out group) || group == null)
            return false;
        group.OnPostMessage(message, param);
        return true;
    }


    internal UIMessageNode CreateMessageNode(int message, System.Object param) {
        if (!m_IsInitMessagePool) {
            m_MessagePool.Init(1, null, null);
            m_IsInitMessagePool = true;
        }
        UIMessageNode ret = m_MessagePool.GetObject();
        ret.message = message;
        ret.param = param;
        return ret;
    }

    internal void DestroyMessageNode(UIMessageNode node) {
        if (node == null)
            return;
        if (!m_IsInitMessagePool) {
            m_MessagePool.Init(1, null, null);
            m_IsInitMessagePool = true;
        }
        node.message = 0;
        node.param = null;
        m_MessagePool.Store(node);
    }
}
