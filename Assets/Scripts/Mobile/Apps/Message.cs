using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Mobile.Apps
{
    public class Message : MonoBehaviour
    {
        public MobileManager TungPhone;
        private MessageAppData data;

        // Use this for initialization
        void Start()
        {
            data = TungPhone.storage.getData<MessageAppData>("message");
        }

        void render()
        {
            string f, text;
            foreach(var m in data.messages)
            {
                f = m.from;
                text = m.message;
            }
        }
    }

    [System.Serializable]
    internal class MessageAppData: AppData
    {
        internal List<TextMessage> messages;
    }

    [System.Serializable]
    internal class TextMessage
    {
        internal string from;
        internal string message;
    }
}