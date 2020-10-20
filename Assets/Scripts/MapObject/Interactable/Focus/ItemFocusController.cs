using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MapObject.PlayerController;
using MapObject.PlayerController.Backpack;

namespace MapObject.Interactable.Focus
{
    public class ItemFocusController : FocusController
    {
        private List<Item> itemList;
        private List<GameObject> blockList;
        private List<int> onScreenBlocks;

        public Image m_Image;

        new private void Start()
        {
            base.Start();
        }

        public override void MoveFocus()
        {
            Debug.Log(focusedIndex);

            float m_Movement = movement.y;
            itemList = backpack.itemList;
            blockList = backpack.blockList;
            onScreenBlocks = backpack.onScreenBlocks;

            if (focusedIndex == blockList.Count && focusedIndex != 0) //means the delete item is the last item
            {
                focusedIndex -= 1;
                gameObject.transform.position = blockList[onScreenBlocks[focusedIndex]].transform.position;
            }

            if (blockList.Count == 0)
            {
                m_Image.enabled = false;
                return;
            }
            m_Image.enabled = true;

            //above are conditions that backpack has no item

            CollisionManager.interactObject = itemList[onScreenBlocks[focusedIndex]].body;

            backpack.description.text = itemList[onScreenBlocks[focusedIndex]].body.GetComponent<ItemProperty>().description;

            if (m_Movement == 0f)
            {
                return;
            }

            else if (m_Movement > 0f)
            {
                if (focusedIndex == 0)//at the top block
                {
                    if (onScreenBlocks[focusedIndex] == 0)//if already focus at the first item
                    {
                        return;
                    }
                    backpack.PageUp();
                    //move the firstrow position downward
                }
                focusedIndex--;
                gameObject.transform.position = blockList[onScreenBlocks[focusedIndex]].transform.position;
                //move focus position
            }

            else
            {
                if (focusedIndex == onScreenBlocks.Count - 1)//at the bottom block
                {
                    if (onScreenBlocks[focusedIndex] == blockList.Count - 1)//if already focus at the last item
                    {
                        return;
                    }
                    backpack.PageDown();
                    //move the firstrow position upward
                }
                focusedIndex++;
                gameObject.transform.position = blockList[onScreenBlocks[focusedIndex]].transform.position;
            }
        }
    }
}