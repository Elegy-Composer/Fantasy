using System;
using Fight.Bullet;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;

namespace Fight.Lord
{
    public class ExampleLord : Lord
    {
        public ExampleLord(int attack, int defense, int speed, int hp) : base(attack, defense, speed, hp)
        {
            
        }

        public void Update()
        {
            if (Input.GetKeyDown("o"))
            {
                Debug.Log("attack key pressed");
                Attack();
            }
        }

        public override void Attack()
        {
            var bullet = LoadBullet();
            const double round = Math.PI * 2;
            for (var i = 0; i < 5; i++)
            {
                var currentAngle = round / 5 * i;
                var velocity = new Vector2((float) Math.Sin(currentAngle), (float) Math.Cos(currentAngle)).normalized;
                var t = transform;
                var newBullet = Instantiate(bullet, t.position, t.rotation);
                newBullet.GetComponent<Bullet.Bullet>().velocity = velocity;
            }
        }

        private static GameObject LoadBullet()
        {
            return AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Items/Bullet.prefab");
        }
    }
}