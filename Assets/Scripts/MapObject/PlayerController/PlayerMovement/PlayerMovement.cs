using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapObject.Movement;
using MapObject.PlayerController.Backpack;
using MapObject.Interactable.Focus;
using TMPro;

namespace MapObject.PlayerController.PlayerMovement
{
    public class PlayerMovement : MonoBehaviour
    {
        public MovementData move;

        private BackpackManager backpack;
        private bool backpackIsOpen;

        public GameObject hint;

        #region Main Method

        private void Start()
        {
            backpack = GameObject.FindGameObjectWithTag("backpack").GetComponent<BackpackManager>();
        }

        void Update()
        {
            #region InteractMovement
            //Debug.Log(CollisionManager.interactObject);
            if (CollisionManager.interactObject != null)//has something to interact
            {
                if (CollisionManager.interactObject.name == "Info")//don't move until close the info panel
                {
                    move.rb.bodyType = RigidbodyType2D.Static;
                }

                if (Input.GetKeyDown(KeyCode.Z))
                {
                    CollisionManager.interactObject.GetComponent<Interactable.Interactable>().Interact();
                    
                    if (CollisionManager.interactObject.tag == "npc" && CollisionManager.interactObject.GetComponent<DialogTrigger>().InteractStarted)
                    {
                        move.rb.bodyType = RigidbodyType2D.Static;
                        Debug.Log("starburst");
                    }
                    else
                        CollisionManager.interactObject = null;//after interacting
                        move.rb.bodyType = RigidbodyType2D.Dynamic;
                    hint.GetComponent<Animator>().enabled = false;
                    hint.GetComponent<TextMeshProUGUI>().text = "";
                }

            }

            #endregion

            #region OpenBackpack
            //can only interact with the backpack???To Do : have to reconsider the logic 
            if ((CollisionManager.interactObject == null || FocusController.Instance.GetComponent<ItemFocusController>() != null) && Input.GetKeyDown(KeyCode.X)) 
            {
                backpack.OpenOrCloseBackpack();
                backpackIsOpen = backpack.backpackIsOpen;
                if (backpackIsOpen)
                {
                    move.rb.bodyType = RigidbodyType2D.Static;
                }
                else
                {
                    CollisionManager.interactObject = null;
                    move.rb.bodyType = RigidbodyType2D.Dynamic;
                }
            }

            #endregion
         
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            if (backpackIsOpen)
            {
                move.rb.bodyType = RigidbodyType2D.Static;
                FocusController.Instance.movement = new Vector2(x, y);//move the focus only
                FocusController.Instance.MoveFocus();
                return;
            }
            move.movement = new Vector2(x, y);
            //Debug.Log(x.ToString() + ", " + y.ToString());
            /*anim.SetFloat("horizontal", movement.x);
            anim.SetFloat("vertical", movement.y);
            anim.SetFloat("speed", movement.sqrMagnitude);*/
        }

        private void FixedUpdate()
        {
            if (move.rb.bodyType == RigidbodyType2D.Static)
            {
                return;//avoid the warning
            }

            if (move.isFacingRight && move.movement.x < 0f || !move.isFacingRight && move.movement.x > 0f)//flip the character
            {
                float x = transform.localScale.x;
                float y = transform.localScale.y;
                float z = transform.localScale.z;
                x *= -1;
                transform.localScale = new Vector3(x, y, z);
                move.isFacingRight = !move.isFacingRight;
            }
            move.rb.MovePosition(move.rb.position + move.movement * move.moveSpeed * Time.fixedDeltaTime);
        }

        #endregion
    }
}
