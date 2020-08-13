using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapObject.Movement;
using TMPro;

namespace MapObject.PlayerController.PlayerMovement
{
    public class PlayerMovement : MonoBehaviour
    {
        public MovementData move;

        #region Main Method

        void Update()
        {
            #region InteractMovement

            if (CollisionManager.interactObject != null)//has something to interact
            {
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    CollisionManager.interactObject.GetComponent<Interactable.Interactable>().Interact();

                    CollisionManager.interactObject = null;//after interacting 
                    TextMeshProUGUI hint = GameObject.Find("HintText").GetComponent<TextMeshProUGUI>();
                    hint.text = "";                  
                }
            }

            #endregion

            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            move.movement = new Vector2(x, y);
            /*anim.SetFloat("horizontal", movement.x);
            anim.SetFloat("vertical", movement.y);
            anim.SetFloat("speed", movement.sqrMagnitude);*/
        }

        private void FixedUpdate()
        {
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
