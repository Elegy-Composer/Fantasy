using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mobile
{
    public class MobileStorage : MonoBehaviour
    {
        public T getData<T>(string AppName) where T: AppData {
            var mobileData = JsonUtility.FromJson<MobileData>("storage.json");
            return (T) mobileData.AppData[AppName];
        }
    }

    public interface AppData
    {

    }

    internal class MobileData
    {
        internal Dictionary<string, AppData> AppData = new Dictionary<string, AppData>();
    }
}
