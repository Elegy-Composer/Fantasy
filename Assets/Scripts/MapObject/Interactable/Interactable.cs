using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapObject.Interactable
{
    public abstract class Interactable : MonoBehaviour
    {
        public abstract void Interact();

        [SerializeField]
        protected SpriteRenderer icon;

        public virtual void ShowIcon()
        {
            icon.enabled = true;
        }
        public virtual void HideIcon()
        {
            icon.enabled = false;
        }
    }
}