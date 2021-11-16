using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGame.Game
{
    class Room
    {

        public List<Enemy> CurrentEnemies;

        public Room(List<Enemy> potentialEnemies, int amount)
        {

            CurrentEnemies = GenerateEnemies(potentialEnemies, amount);

        }

        //Generates an array of enemies to fight using a list of potential enemy types given by the game manager.
        private List<Enemy> GenerateEnemies(List<Enemy> potentialEnemies, int amount)
        {

            List<Enemy> currentEnemies = new List<Enemy>();

            Random random = new Random();
            for (int i = 0; i < amount; i++)
            {
                currentEnemies.Add(potentialEnemies[random.Next(potentialEnemies.Count)]);
            }

            return currentEnemies;

        }

        public void Introduction()
        {
            string introText = "In the room there is a ";

            foreach (Enemy enemy in CurrentEnemies)
            {

                if(CurrentEnemies.IndexOf(enemy) != CurrentEnemies.IndexOf(CurrentEnemies.Last()))
                {
                    introText += enemy.Name + ", ";
                }
                else
                {
                    introText += enemy.Name + ".";
                }

            }

            Console.WriteLine(introText);
        }
    }
}
