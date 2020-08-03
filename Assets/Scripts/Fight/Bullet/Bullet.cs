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
        public int attack;

        public Bullet(LivingThing.LivingThing sender, Vector2 velocity)
        {
            this.velocity = velocity;
            this.sender = sender;
            attack = sender.attack;
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

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("collided");
            var protagonist = other.gameObject.GetComponent<Character.Character>();
            if (protagonist == null) return; // The collider is not a character
            protagonist.attacked(attack);
            Destroy(gameObject);
        }

        private void LookAtVelocity()
        {
            var angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
            body.MoveRotation(angle);
        }
    }
}