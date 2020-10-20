using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fight.Model
{
    public class BulletConfigSetter : MonoBehaviour
    {
        [Serializable]
        public struct Config
        {
            public string LordName;
            public GameObject BulletPrefab;
        }

        [SerializeField]
        private Config[] configs;


        void Start()
        {
            foreach (var config in configs)
            {
                Dictionary<string, GameObject> mapping = BulletConfig.LordBulletMapping;
                string lordName = config.LordName;
                if (!mapping.ContainsKey(lordName))
                {
                    BulletConfig.LordBulletMapping.Add(lordName, config.BulletPrefab);
                }
            }
        }
    }
}