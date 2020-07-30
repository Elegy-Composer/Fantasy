using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

namespace Fight.Lord
{
    public class Lord : LivingThing.LivingThing
    {
        public Lord(string name, int attack, int defense, int speed, int hp) : base(name, attack, defense, speed, hp)
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}