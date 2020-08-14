using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MapObject.PlayerController;
using TMPro;

namespace MapObject.Interactable
{
    public class InfoManager : Interactable
    {
        public bool OnScreen=false;

        #region ShowMethod

        public void ShowInfo()
        {
            OnScreen = true;
            gameObject.GetComponent<Image>().enabled = true;
            GetComponent<Animator>().Play("Get_Item_Info_Pop_Out");
        }

        private void Update()
        {
            if (OnScreen)
            {
                CollisionManager.interactObject = gameObject;
            }
        }

        #endregion

        #region HideMethod

        public override void Interact()//when player press z than disappear
        {
            OnScreen = false;
            GetComponent<Animator>().Play("Get_Item_Info_Hide");
        }

        public void HideInfo()
        {           
            TextMeshProUGUI[] textList= GetComponentsInChildren<TextMeshProUGUI>();//delete all active text
            foreach (TextMeshProUGUI t in textList)
            {
                t.text = "";
            }
            gameObject.GetComponent<Image>().enabled = false;
        }

        #endregion

    }
}