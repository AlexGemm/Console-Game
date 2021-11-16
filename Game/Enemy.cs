using System;

namespace ConsoleGame
{
    class Enemy
    {

        public int Health;
        public readonly string Name;

        private int _damageMax;


        public Enemy(string name, int health, int damageMax)
        {

            this.Name = name;
            this.Health = health;
            this._damageMax = damageMax;

        }



        public int Attack()
        {

            Random random = new Random();

            int damageDealt = random.Next(1, _damageMax);


            return damageDealt;

        }

    }
}
