using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame
{
    class Weapon
    {

        public int Damage;
        public readonly string Name;


        public Weapon(string name, int damage)
        {

            this.Name = name;
            this.Damage = damage;

        }

    }

}
