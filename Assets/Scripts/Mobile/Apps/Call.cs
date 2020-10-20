using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Mobile.Apps
{
    public class Call : MonoBehaviour
    {
        public MobileManager TungPhone;
        private CallAppData data;

        // Use this for initialization
        void Start()
        {
            data = TungPhone.storage.getData<CallAppData>("call");
        }

        void renderContact()
        {
            string n, num;
            foreach (var m in data.contacts)
            {
                n = m.name;
                num = m.number;
            }
        }

        void renderHistory()
        {
            string t, n;
            foreach (var m in data.histories)
            {
                t = m.time;
                n = m.number;
            }
        }
    }

    [System.Serializable]
    internal class CallAppData : AppData
    {
        internal List<Contact> contacts;
        internal List<History> histories;
    }

    [System.Serializable]
    internal class Contact
    {
        internal string name;
        internal string number;
    }

    [System.Serializable]
    internal class History
    {
        internal string number;
        internal string time;
    }
}