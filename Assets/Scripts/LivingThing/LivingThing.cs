using System.Runtime.Remoting.Messaging;
using UnityTemplateProjects.LivingThing;

namespace LivingThing
{
    public class LivingThing
    {
        private int attack;
        public int Attack
        {
            get => attack;
            set => attack = value;
        }
        
        private int defense;
        public int Defense
        {
            get => defense;
            set => defense = value;
        }

        private int speed;
       public int Speed
        {
            get => speed;
            set => speed = value;
        }

        private int hp;
        public int Hp
        {
            get => hp;
            set => hp = value;
        }

        public Status status;

        private string name;

        public string Name => name;

        public LivingThing(string name, int attack, int defense, int speed, int hp)
        {
            this.name = name;
            this.attack = attack;
            this.defense = defense;
            this.speed = speed;
            this.hp = hp;
            this.status = Status.ALIVE;
        }
    }
}