﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapObject.Movement;

namespace MapObject.PlayerController
{
    public class PlayerMovement : MonoBehaviour
    {
        public MovementData move;

        #region Main Method

        void Update()
        {
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