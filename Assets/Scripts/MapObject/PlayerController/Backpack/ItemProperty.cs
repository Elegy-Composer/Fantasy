using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapObject.Interactable.Focus;

namespace MapObject.PlayerController.Backpack
{
    public abstract class ItemProperty : Interactable.Interactable
    {
        public string name;
        [TextArea(3, 10)]
        public string description;

        public override void Interact()
        {
            OpenUsePanel();
            YesNoFocusController.YesActionDelegate += UseItem;
            YesNoFocusController.YesActionDelegate += RemoveMe;
        }

        protected void OpenUsePanel()
        {
            GameObject.FindGameObjectWithTag("usepanel").GetComponent<Animator>().SetBool("isUse", true);
        }
        protected void RemoveMe()
        {
            GameObject.FindGameObjectWithTag("backpack").GetComponent<BackpackManager>().ConsumeItem(gameObject);
        }
        protected abstract void UseItem();
        


    }
}