using System;

namespace ConsoleGame
{
    class Enemy
    {

        public int Health;
        public readonly string Name;
        public readonly int DamageMax;


        public Enemy(string name, int health, int damageMax)
        {

            this.Name = name;
            this.Health = health;
            this.DamageMax = damageMax;

        }



        public int Attack()
        {

            Random random = new Random();

            int damageDealt = random.Next(1, DamageMax);

            return damageDealt;

        }

    }
}
