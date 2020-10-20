using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapObject.PlayerController.Backpack;
using TMPro;

namespace MapObject.Interactable
{
    public class TreasureManager : Interactable
    {
        public Sprite openSprite;
        public bool isOpen = false;
        public List<Item> itemList;

        public override void Interact()//open the box
        {
            #region old code
            /*
            //make sure the box is opened
            isOpen = true;
            gameObject.tag = "opened";
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = openSprite;

            //show item info to player
            TextMeshProUGUI itemsInfo = GameObject.Find("ItemsInfo").GetComponent<TextMeshProUGUI>();
            itemsInfo.text = "Get\n";            

            //access backpack system
            BackpackManager backpack = GameObject.Find("Backpack").GetComponent<BackpackManager>();

            try
            {
                foreach (Item itemInBox in itemList)
                {
                    bool nextItem = false;
                    //show what you got
                    itemsInfo.text += (itemInBox.name + "     x " + itemInBox.amount.ToString() + "\n");

                    /*foreach (Item itemInPack in backpack.itemList)
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
            catch
            {

            }
            itemsInfo.GetComponentInParent<InfoManager>().ShowInfo();
            */
            #endregion

            if (GameObject.Find("Backpack").GetComponent<BackpackManager>().AddItem(itemList))
            {
                isOpen = true;
                gameObject.tag = "opened";
                gameObject.GetComponentInChildren<SpriteRenderer>().sprite = openSprite;
            }
        }
    }
}