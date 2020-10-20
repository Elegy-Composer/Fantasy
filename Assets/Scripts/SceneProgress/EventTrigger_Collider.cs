using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SceneProgress
{
    public class EventTrigger_Collider : EventTrigger
    {
        public string objTag;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == objTag)
            {
                StartEvent();
            }
        }
    }
}