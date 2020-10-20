using UnityEngine;

namespace LivingThing
{
    public class LivingThingController : MonoBehaviour
    {
        public Rigidbody2D body;
        public LivingThing controlled;

        void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                body.MovePosition(body.position + controlled.speed * Time.deltaTime * Vector2.up);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                body.MovePosition(body.position + controlled.speed * Time.deltaTime * Vector2.down);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                body.MovePosition(body.position + controlled.speed * Time.deltaTime * Vector2.left);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                body.MovePosition(body.position + controlled.speed * Time.deltaTime * Vector2.right);
            }
        }
    }
}