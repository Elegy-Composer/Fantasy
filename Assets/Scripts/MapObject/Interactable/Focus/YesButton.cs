using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapObject.Interactable.Focus
{
    public class YesButton : Interactable
    {
        public override void Interact()
        {
            YesNoFocusController.CommitAction(true);
        }
    }
}