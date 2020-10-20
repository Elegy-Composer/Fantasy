using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapObject.Interactable.Focus
{
    public class NoButton : Interactable
    {
        public override void Interact()
        {
            YesNoFocusController.CommitAction(false);
        }
    }
}