using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LivingThing
{
    public class UserControl : MonoBehaviour
    {

        public Rigidbody2D body;
        public float speed;

        private Vector2 moveVector;

        void Update()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            moveVector = new Vector2(x, y);
        }

        void FixedUpdate()
        {
            body.MovePosition(body.position + moveVector * speed * Time.fixedDeltaTime);
        }
    }
}