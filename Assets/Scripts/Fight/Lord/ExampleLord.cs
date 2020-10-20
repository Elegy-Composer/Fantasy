using System;
using System.Collections;
using Fight.Model;
using UnityEditor;
using UnityEngine;

namespace Fight.Lord
{
    public class ExampleLord : Lord
    {
        private const int BulletsPerAttack = 5;
        private double _angleOffset;
        private const double Round = Math.PI * 2;
        public ExampleLord(int attack, int defense, int speed, int hp) : base(attack, defense, speed, hp)
        {
            
        }

        private Coroutine attackCoroutine;
        private void Start()
        {
            _angleOffset = 0;
            attackCoroutine = StartCoroutine(MultipleAttacks(9, 1));
        }

        private IEnumerator MultipleAttacks(int rounds, float pauseTime)
        {
            for (var i = 0; i < rounds; i++)
            {
                Attack();
                yield return new WaitForSeconds(pauseTime);
                _angleOffset += Round / rounds;
            }

            StopCoroutine(attackCoroutine);
        }

        public override void Attack()
        {
            var bullet = LoadBullet();
            
            for (var i = 0; i < BulletsPerAttack; i++)
            {
                var currentAngle = _angleOffset + Round / BulletsPerAttack * i;
                var velocity = new Vector2((float) Math.Sin(currentAngle), (float) Math.Cos(currentAngle)).normalized;
                Bullet.Bullet.InitializeBullet(bullet, this, velocity, transform);
            }
        }

        private static GameObject LoadBullet()
        {
            return BulletConfig.LordBulletMapping["Enemy"];
        }
    }
}