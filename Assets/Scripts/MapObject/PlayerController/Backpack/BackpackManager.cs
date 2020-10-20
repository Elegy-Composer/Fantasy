using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapObject.Interactable;
using TMPro;

namespace MapObject.PlayerController.Backpack
{
    public class BackpackManager : MonoBehaviour
    {
        private Animator anim;
        public bool backpackIsOpen;

        [SerializeField]
        private int capacity;
        public List<Item> itemList;
        private List<Item> clonedItemList;

        public GameObject itemBlock;
        public List<GameObject> blockList;
        private float blockHeight;
        public RectTransform firstRow;
        public List<int> onScreenBlocks;      

        public TextMeshProUGUI itemInfo;
        public TextMeshProUGUI description;

        private void Start()
        {
            anim = GetComponent<Animator>();
            blockHeight= itemBlock.GetComponent<RectTransform>().sizeDelta.y;
        }

        #region ChangeItem

        public void DisplayItemData() //ui method
        {
            for (int i = 0; i < itemList.Count; i++) 
            {
                //new item obtained
                if (i >= blockList.Count)
                {
                    Debug.Log("add new block");
                    GameObject newBlock = Instantiate(itemBlock,firstRow);
                    float x = newBlock.transform.localPosition.x;
                    float y = newBlock.transform.localPosition.y;
                    y -= i * blockHeight;
                    newBlock.transform.localPosition = new Vector2(x, y);
                    blockList.Add(newBlock);
                }
                blockList[i].GetComponent<ShowItem>().name.text = itemList[i].body.GetComponent<ItemProperty>().name;
                Debug.Log(itemList[i].body.GetComponent<ItemProperty>().name);
                blockList[i].GetComponent<ShowItem>().amount.text = itemList[i].amount.ToString();
            }
            ResetOnScreenBlocks(0);
        }

        public bool AddItem(List<Item> itemsInBox)
        {

            #region Adding Process

            clonedItemList = itemList;//do a copy itemList

            foreach (Item itemInBox in itemsInBox)
            {
                bool alreadyHave = false;

                foreach (Item itemInPack in clonedItemList)
                {
                    if (itemInBox.body == itemInPack.body)//already have the same item
                    {
                        Debug.Log("have same item");

                        Item t = new Item();//replace the old item
                        t.body = itemInBox.body;
                        t.body.GetComponent<ItemProperty>().name = itemInBox.body.GetComponent<ItemProperty>().name;
                        t.amount = (itemInPack.amount + itemInBox.amount);
                        t.body.GetComponent<ItemProperty>().description = itemInBox.body.GetComponent<ItemProperty>().description;
                        clonedItemList[clonedItemList.IndexOf(itemInPack)] = t;

                        alreadyHave = true;
                        break;
                    }
                }
                if (alreadyHave)
                {
                    continue;
                }
                clonedItemList.Add(itemInBox);//add new item
            }

            #endregion

            #region Display Message

            if (clonedItemList.Count > capacity)//check if the backpack is not full, then update the backpack
            {
                itemInfo.text = "backpack is full";
                itemInfo.GetComponentInParent<InfoManager>().ShowInfo();
                return false;
            }

            itemInfo.text = "Get \n";
            foreach (Item itemInBox in itemsInBox)
            {
                itemInfo.text += (itemInBox.body.GetComponent<ItemProperty>().name + " x " + itemInBox.amount.ToString() + "\n");
            }
            itemInfo.GetComponentInParent<InfoManager>().ShowInfo();

            //update backpack
            itemList = clonedItemList;
            DisplayItemData();
            return true;

            #endregion
        }

        public void ConsumeItem(GameObject d_ItemBody)
        {
            int d_Index = -1;
 
            foreach (Item t in itemList)//find the index of the deleted item
            {
                if (t.body == d_ItemBody)
                {
                    d_Index = itemList.IndexOf(t);
                    break;
                }               
            }

            //consume item
            Item d_Item = itemList[d_Index];
            GameObject d_Block = blockList[d_Index];

            if (itemList[d_Index].amount - 1 == 0)
            {
                for (int i = d_Index + 1; i < blockList.Count; i++) //move all down block upward
                {
                    float x = blockList[i].transform.localPosition.x;
                    float y = blockList[i].transform.localPosition.y;
                    y += blockHeight;
                    blockList[i].transform.localPosition = new Vector2(x, y);
                }
                itemList.Remove(d_Item);
                blockList.Remove(d_Block);
                Destroy(d_Block);
                ResetOnScreenBlocks(onScreenBlocks[0]);
            }
            else
            {
                Item t = new Item();
                t.body = d_Item.body;
                t.amount = d_Item.amount - 1;
                itemList[d_Index] = t;
                d_Block.GetComponent<ShowItem>().amount.text = t.amount.ToString();
            }
            if (blockList.Count == 0)
            {
                description.text = "";
            }
        }

        private void ResetOnScreenBlocks(int starter)
        {
            onScreenBlocks = new List<int>();
            float len = blockList.Count < 5 ? blockList.Count : 5;
            for (int i = 0; i < len; i++)
            {
                onScreenBlocks.Add(i+starter);
            }
        }

        #endregion

        #region BackpackActivation

        public void OpenOrCloseBackpack()
        {
            if (backpackIsOpen)//to close
            {
                //go back to original position
            }
            backpackIsOpen = !anim.GetBool("isOpen");
            anim.SetBool("isOpen", backpackIsOpen);
        }

        #endregion

        #region UseItem

        public void PageUp()
        {
            firstRow.localPosition -= new Vector3(0f, blockHeight, 0f);
        }
        public void PageDown()
        {
            firstRow.localPosition += new Vector3(0f, blockHeight, 0f);
        }

        #endregion
    }
}