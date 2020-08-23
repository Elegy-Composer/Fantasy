using UnityEngine;

namespace LivingThing
{
    public class UserControl : MonoBehaviour
    {

        public Rigidbody2D body;
        public float speed;
        public Vector2 upLeft = new Vector2(Mathf.Infinity, Mathf.Infinity);
        public Vector2 downRight = new Vector2(0, 0);
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
            futurePosition.x = Mathf.Clamp(futurePosition.x, upLeft.x + _spriteSize.x, downRight.x - _spriteSize.x);
            futurePosition.y = Mathf.Clamp(futurePosition.y, upLeft.y + _spriteSize.y, downRight.y - _spriteSize.y);
            body.MovePosition(futurePosition);
        }
    }
}