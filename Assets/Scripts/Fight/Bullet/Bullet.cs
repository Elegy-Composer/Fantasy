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
        
        public static void InitializeBullet(GameObject prefab, LivingThing.LivingThing sender, Vector2 velocity, Transform t)
        {
            var obj = Instantiate(prefab, t.position, t.rotation);
            var bullet = obj.GetComponent<Bullet>();
            bullet.velocity = velocity;
            bullet.sender = sender;
            bullet.attack = sender.attack;
            bullet.body = obj.GetComponent<Rigidbody2D>();
        }
    }
}