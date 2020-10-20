using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SceneProgress
{
    public class SceneEvent : MonoBehaviour
    {
        public static SceneEvent Instance { get; protected set; }

        private void Awake()
        {
            Instance = this;
        }

    }
}