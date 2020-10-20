using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapObject.Interactable.Focus
{
    public class FocusManager : MonoBehaviour
    {
        [SerializeField]
        private ItemFocusController itemFocus;
        [SerializeField]
        private YesNoFocusController YNFocus;

        public void SwitchToItemFocus()
        {
            FocusController.Instance.enabled = false;
            itemFocus.enabled = true;
        }
        public void SwitchToYNFocus()
        {
            FocusController.Instance.enabled = false;
            YNFocus.enabled = true;

        }
    }
}