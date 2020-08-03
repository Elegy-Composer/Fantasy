using System;
using UnityEngine;
using LivingThing;
using UnityEngine.Animations;

namespace Fight.Bullet
{
    public class Bullet : MonoBehaviour
    {
        public Vector2 velocity;
        public LivingThing.LivingThing sender;
        public Rigidbody2D body;

        public Bullet(LivingThing.LivingThing sender, Vector2 velocity)
        {
            this.velocity = velocity;
            this.sender = sender;
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            LookAtVelocity();
            body.MovePosition(body.position + velocity * Time.deltaTime);

            // if (Input.GetKeyDown(KeyCode.A))
            // {
            //     velocity.y *= -1;
            // }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("collided");
            // if (collision.collider.name == "protagonist")
            // {
            //     Component victim = collision.collider.GetComponent<LivingThing.LivingThing>();
            //     Debug.Log(victim);
            //     Debug.Log(sender.attack);
            // }
        }

        private void LookAtVelocity()
        {
            var angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
            body.MoveRotation(angle);
        }
    }
}