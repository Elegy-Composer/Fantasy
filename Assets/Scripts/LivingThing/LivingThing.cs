
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

        public string name;

        public LivingThing(string name, int attack, int defense, float speed, int hp)
        {
            this.name = name;
            this.attack = attack;
            this.defense = defense;
            this.speed = speed;
            this.hp = hp;
            this.status = Status.ALIVE;
        }

        public LivingThing()
        {
            name = "example name";
            attack = 10;
            defense = 20;
            speed = 10;
            hp = 40;
            status = Status.ALIVE;
        }
    }
}