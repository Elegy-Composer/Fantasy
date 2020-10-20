using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SceneProgress
{
    public class EventTrigger_Dialog : EventTrigger
    {
        public DialogTrigger dialog;
        public int trigger_Index;
        public bool hasTalked;
        public bool happened = false;

        private void Update()
        {
            if (dialog.index > 0)
            {
                hasTalked = true;
            }
            if (dialog.index == 0 && hasTalked && !happened)
            {
                happened = true;
                StartEvent();
            }          
        }
    }
}