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
                //Pick a random potential enemy and make a clone of it in the current enemies list.
                int picked = random.Next(0, potentialEnemies.Count);

                currentEnemies.Add(new Enemy(potentialEnemies[picked].Name, potentialEnemies[picked].Health, potentialEnemies[picked].DamageMax));
            }

            return currentEnemies;

        }

        public void Introduction()
        {
            string introText = "In the room there is a ";

            //Go through all the enemies in the current room and print them out to the user.
            for (int i = 0; i < CurrentEnemies.Count; i++)
            {
                //Find the last iteration to see when the sentence needs to end.
                if (i == (CurrentEnemies.Count - 1))
                {
                    introText += CurrentEnemies[i].Name + ".";
                }
                else
                {
                    introText += CurrentEnemies[i].Name + ", ";
                }

            }

            Console.WriteLine(introText);
        }
    }
}

