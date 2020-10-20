using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapObject.PlayerController.Backpack;

namespace MapObject.Interactable.Focus
{
    public abstract class FocusController : MonoBehaviour
    {
        public static FocusController Instance { get; protected set; }
        public BackpackManager backpack;

        protected void Start()
        {
            Instance = this;
            backpack = GameObject.FindGameObjectWithTag("backpack").GetComponent<BackpackManager>();
            #region Another Approach
            /*Debug.Log("at least start");
            FocusController[] focuses=GameObject.FindObjectsOfType<FocusController>();
            foreach (FocusController f in focuses)
            {
                if (f == this)
                {
                    Debug.Log("me");
                    continue;
                }
                else
                {
                    Debug.Log("others");
                    f.gameObject.SetActive(false);
                }
            }
            Debug.Log("i'm the only focus");*/
            #endregion
        }
        protected void OnEnable()
        {
            if (Instance != null)
            {
                Instance.enabled = false;
            }
            Instance = this;
        }

        public Vector2 movement;
        protected int focusedIndex=0;
        public abstract void MoveFocus(); 
    }
}