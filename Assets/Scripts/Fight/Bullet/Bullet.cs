using System;
using UnityEngine;

namespace Fight.Bullet
{
    public abstract class Bullet : MonoBehaviour
    {
        public Vector2 velocity;
        public LivingThing.LivingThing sender;
        public int attack;
        public Rigidbody2D body;

        public static T CreateComponent<T>(GameObject obj, LivingThing.LivingThing sender, Vector2 velocity) where T:Bullet
        {
            var bullet = obj.AddComponent<T>();
            bullet.velocity = velocity;
            bullet.sender = sender;
            bullet.attack = sender.attack;
            bullet.body = obj.GetComponent<Rigidbody2D>();
            return bullet;
        }
    }
}