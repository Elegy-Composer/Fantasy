using System;
using UnityEngine;
using LivingThing;
using UnityEngine.Animations;

namespace Fight.Bullet
{
    public class ExampleBullet : Bullet
    {
        private void FixedUpdate()
        {
            LookAtVelocity();
            body.MovePosition(body.position + velocity * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var protagonist = other.gameObject.GetComponent<Character.Character>();
            if (protagonist == null) return; // Return if the collider is not a character
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