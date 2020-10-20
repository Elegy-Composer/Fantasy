using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MapObject.PlayerController;

namespace MapObject.Interactable.Focus
{
    public class YesNoFocusController : FocusController
    {
        [SerializeField]
        private List<GameObject> YesNoButtons;

        public delegate void YesAction();
        public static event YesAction YesActionDelegate;

        new void Start()
        {
            base.Start();
        }

        new private void OnEnable()
        {
            gameObject.GetComponent<Image>().enabled = false;
            focusedIndex = -1;
            base.OnEnable();
        }

        public override void MoveFocus()
        {
            float m_Movement = movement.x;
            
            if (m_Movement == 0)
            {
                return;
            }

            if (focusedIndex == -1)
            {
                gameObject.GetComponent<Image>().enabled = true;
                focusedIndex = 0;
            }

            else if (m_Movement > 0)
            {
                focusedIndex = 1;
            }
            else
            {
                focusedIndex = 0;
            }
            gameObject.transform.position = YesNoButtons[focusedIndex].transform.position;
            CollisionManager.interactObject = YesNoButtons[focusedIndex];
        }

        public static void CommitAction(bool yes)
        {
            if (yes)
            {
                YesActionDelegate();
            }
            YesActionDelegate = null;
            CloseUsePanel();
        }

        private static void CloseUsePanel()
        {
            GameObject.FindGameObjectWithTag("usepanel").GetComponent<Animator>().SetBool("isUse", false);
        }
    }
}