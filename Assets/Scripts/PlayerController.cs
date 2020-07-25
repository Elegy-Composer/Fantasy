using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMovement
{
    public class PlayerController : MonoBehaviour
    {

        #region Move variable
        public Rigidbody2D rb; 
        [SerializeField]
        private float moveSpeed;
        private Vector2 movement;

        private bool isFaceRight = true;
        #endregion

        #region Animation variable
        public Animator anim;
        #endregion


        void Update()
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            /*anim.SetFloat("horizontal", movement.x);
            anim.SetFloat("vertical", movement.y);
            anim.SetFloat("speed", movement.sqrMagnitude);*/
        }

        private void FixedUpdate()
        {
            if (isFaceRight && movement.x < 0f || !isFaceRight && movement.x > 0f)
            {
                float x = transform.localScale.x;
                float y = transform.localScale.y;
                float z = transform.localScale.z;
                x *= -1;
                transform.localScale = new Vector3(x, y, z);
                isFaceRight = !isFaceRight;
            }
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
