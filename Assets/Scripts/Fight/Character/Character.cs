
using LivingThing;
using UnityEngine;

namespace Fight.Character
{
    public class Character : LivingThing.LivingThing
    {
        public Character(int attack, int defense, float speed, int hp) : base(attack, defense, speed, hp)
        {
        
        }

        private void Start()
        {
            var control = gameObject.GetComponent<UserControl>();
            control.speed = speed;
            // ReSharper disable once PossibleNullReferenceException
            var zPosition = Camera.main.transform.position.z;
            control.downRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, zPosition));
            control.upLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, zPosition));
        }
    }
}