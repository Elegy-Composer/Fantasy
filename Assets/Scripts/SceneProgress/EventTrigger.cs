using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


namespace SceneProgress
{
    public class EventTrigger : MonoBehaviour
    {
        [SerializeField]
        protected string eventName;

        [SerializeField]
        protected SceneEvent eventManager;

        private void Start()
        {
            Debug.Log(SceneEvent.Instance);
            eventManager = SceneEvent.Instance;
        }

        protected void StartEvent()
        {
            Debug.Log(eventManager.GetType());
            Debug.Log(eventManager.GetType().GetMethod(eventName));
            eventManager.GetType().GetMethod(eventName).Invoke(eventManager, null);
        }

    }
}