using System;
using UnityEngine;

namespace UnityTemplateProjects.Character
{
    public class Character
    {
        public String Name;
        public Sprite Sprite;
        public CharacterType Type;

        public Character(String Name, CharacterType Type)
        {
            this.Name = Name;
        }
    }
}