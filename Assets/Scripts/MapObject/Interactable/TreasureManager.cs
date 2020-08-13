using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapObject.PlayerController.Backpack;

namespace MapObject.Interactable
{
    public class TreasureManager : Interactable
    {
        public bool isOpen = false;
        public List<Item> itemList;

        public override void Interact()//open the box
        {
            isOpen = true;
            gameObject.tag = "opened";
            BackpackManager backpack = GameObject.Find("Backpack").GetComponent<BackpackManager>();

            foreach (Item itemInBox in itemList)
            {
                bool nextItem=false;

                foreach (Item itemInPack in backpack.itemList)
                {
                    if (itemInBox.body == itemInPack.body)//already have the same item
                    {
                        Debug.Log("have same item");

                        Item t = new Item();//replace the old item
                        t.body = itemInBox.body;
                        t.amount = (itemInPack.amount + itemInBox.amount);
                        backpack.itemList[backpack.itemList.IndexOf(itemInPack)] = t;

                        nextItem = true;
                        break;
                    }
                }
                if (nextItem)
                {
                    continue;
                }
                backpack.itemList.Add(itemInBox);
            }          
        }
    }
}