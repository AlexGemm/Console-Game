using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame
{
    class Player
    {

        public int Health;

        private Weapon _playerWeapon;


        public Player(int health)
        {

            this.Health = health;

        }



        public int Attack()
        {

            Random random = new Random();

            int damageDealt = random.Next(1, _playerWeapon.Damage);


            return damageDealt;

        }

        public void Equip(Weapon newWeapon)
        {

            _playerWeapon = newWeapon;

        }

        public string GetWeaponName()
        {

            return _playerWeapon.Name;

        }

    }

}
