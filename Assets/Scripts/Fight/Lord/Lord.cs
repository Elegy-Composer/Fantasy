
using UnityEngine.Timeline;

namespace Fight.Lord
{
    
    public abstract class Lord : LivingThing.LivingThing
    {
        protected Lord(int attack, int defense, int hp, int speed) : base(attack, defense, hp, speed) {
    
        }
        public abstract void Attack();
    }
}