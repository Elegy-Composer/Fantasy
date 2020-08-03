
using UnityEngine;
using UnityEngine.Subsystems;

namespace LivingThing
{
    public class LivingThing : MonoBehaviour
    {
        public int attack;
        

        public int defense;

        public float speed;

        public int hp;

        public Status status;

        public LivingThing(int attack, int defense, float speed, int hp)
        {
            this.attack = attack;
            this.defense = defense;
            this.speed = speed;
            this.hp = hp;
            this.status = Status.ALIVE;
        }

        public LivingThing()
        {
            attack = 10;
            defense = 20;
            speed = 10;
            hp = 40;
            status = Status.ALIVE;
        }

        public void attacked(int amount)
        {
            var HealthLoss = amount - defense;
            if (HealthLoss < 0)
            {
                return;
            }

            LoseHealth(HealthLoss);
        }

        private void LoseHealth(int HealthLoss)
        {
            hp -= HealthLoss;
            if (hp <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Debug.Log(name+" is killed");
            status = Status.DEAD;
        }
    }
}