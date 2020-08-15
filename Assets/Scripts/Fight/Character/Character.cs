
using LivingThing;

namespace Fight.Character
{
    public class Character : LivingThing.LivingThing
    {
        public Character(int attack, int defense, float speed, int hp) : base(attack, defense, speed, hp)
        {
        
        }

        private void Start()
        {
            gameObject.GetComponent<UserControl>().speed = speed;
        }
    }
}