using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapObject.PlayerController.Backpack.ItemEffect
{
    public class MasterKey : ItemProperty
    {
        /*public override void Interact()
        {
            OpenUsePanel();            
        }*/
        protected override void UseItem()
        {
            Debug.Log("use the useless masterkey");
        }

    }
}