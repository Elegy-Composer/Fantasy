using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace LivingThing
{
    public class UserControl : MonoBehaviour
    {

        public Rigidbody2D body;
        public float speed;
        public Vector2 bounds = new Vector2(Mathf.Infinity, Mathf.Infinity);
        private Vector2 _spriteSize;

        private Vector2 _moveVector;

        void Start()
        {
            _spriteSize = transform.GetComponent<Collider2D>().bounds.size / 2;
        }

        void Update()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            _moveVector = new Vector2(x, y);
        }

        void FixedUpdate()
        {
            var futurePosition = body.position + speed * Time.fixedDeltaTime * _moveVector;
            futurePosition.x = Mathf.Clamp(futurePosition.x, -bounds.x + _spriteSize.x, bounds.x - _spriteSize.x);
            futurePosition.y = Mathf.Clamp(futurePosition.y, -bounds.y + _spriteSize.y, bounds.y - _spriteSize.y);
            body.MovePosition(futurePosition);
        }
    }
}