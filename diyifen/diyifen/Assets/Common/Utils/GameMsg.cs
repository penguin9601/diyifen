using System;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class GameMsg : Singleton<GameMsg>
    {
        private struct MsgObj
        {
            public MsgObj(object sender, EventHandler<EventArgs> handler)
            {
                this.sender = sender;
                this.handler = handler;
            }
            public object sender;
            public EventHandler<EventArgs> handler;
        }

        private struct SendObj
        {
            public SendObj(int msgName, EventArgs args)
            {
                this.msgName = msgName;
                this.args = args;
            }
            public int msgName;
            public EventArgs args;
        }

        private Dictionary<int, List<MsgObj>> m_MsgMap = new Dictionary<int, List<MsgObj>>();
        private List<SendObj> m_sendList = new List<SendObj>();

        //注册消息
        public void AddMessage(int msgName, object sender, EventHandler<EventArgs> callBack)
        {
            List<MsgObj> callbacks = null;
            MsgObj newMsgObj = new MsgObj(sender, callBack);

            if (!m_MsgMap.TryGetValue(msgName, out callbacks))
            {
                callbacks = new List<MsgObj>();
                m_MsgMap[msgName] = callbacks;
            }
            else
            {
                if (callbacks.Contains(newMsgObj))
                {
                    Debug.LogWarning("GameMsg.AddMessage duplicate, " + msgName);
                    return;
                }
            }
            callbacks.Add(newMsgObj);
        }

        //移除消息
        public void RemoveMessage(int msgName)
        {
            List<MsgObj> callbacks = null;
            if (m_MsgMap.TryGetValue(msgName, out callbacks))
            {
                m_MsgMap.Remove(msgName);
            }
        }

        //移除指定对象和函数的消息
        public void RemoveMessage(int msgName, object sender, EventHandler<EventArgs> callBack = null)
        {
            List<MsgObj> callbacks = null;
            if (m_MsgMap.TryGetValue(msgName, out callbacks))
            {
                var delList = new List<MsgObj>();
                foreach (MsgObj msgObj in callbacks)
                {
                    if(msgObj.sender == sender)
                    {
                        if(callBack == null)
                        {
                            delList.Add(msgObj);
                        }
                        else if(msgObj.handler.Method.ToString() == callBack.Method.ToString())
                        {
                            delList.Add(msgObj);
                        }
                    }
                }

                foreach (MsgObj msgObj in delList)
                {
                    callbacks.Remove(msgObj);
                }

                if(callbacks.Count == 0)
                {
                    m_MsgMap.Remove(msgName);
                }
            }
        }

        //发送消息
        public void RunMessage(int msgName, EventArgs args = null)
        {
            List<MsgObj> callbacks = null;
            if (m_MsgMap.TryGetValue(msgName, out callbacks))
            {
                foreach (MsgObj msgObj in callbacks)
                {
                    msgObj.handler(msgObj.sender, args);
                }
            }
        }

        //发送消息(下一帧执行)
        public void SendMessage(int msgName, EventArgs args = null)
        {
            var sendObj = new SendObj(msgName, args);
            m_sendList.Add(sendObj);
        }

        
        public void update()
        {
            foreach (SendObj sendObj in m_sendList)
            {
                this.RunMessage(sendObj.msgName, sendObj.args);
            }

            m_sendList.Clear();
        }
    }
}

